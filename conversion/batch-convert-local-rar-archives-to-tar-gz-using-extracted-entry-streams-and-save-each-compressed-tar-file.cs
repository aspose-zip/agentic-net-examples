// HOW-TO: Batch Convert RAR Files to TAR.GZ Archives in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output directories
            string inputDir = @"C:\InputRar";
            string outputDir = @"C:\OutputTarGz";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure output base directory exists
            Directory.CreateDirectory(outputDir);

            // Get all RAR files in the input directory
            string[] rarFiles = Directory.GetFiles(inputDir, "*.rar");

            foreach (string rarPath in rarFiles)
            {
                // Validate each RAR file
                if (!File.Exists(rarPath))
                {
                    Console.Error.WriteLine($"File not found: {rarPath}");
                    continue;
                }

                // Determine output TAR.GZ path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(rarPath);
                string outputTarGzPath = Path.Combine(outputDir, fileNameWithoutExt + ".tar.gz");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

                // Open RAR archive, create TAR archive, and convert entries
                using (FileStream rarStream = File.OpenRead(rarPath))
                using (RarArchive rarArchive = new RarArchive(rarStream))
                using (TarArchive tarArchive = new TarArchive())
                {
                    foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                    {
                        // Skip directories inside the RAR
                        if (rarEntry.IsDirectory)
                            continue;

                        // Extract entry to a memory stream
                        using (MemoryStream entryStream = new MemoryStream())
                        {
                            rarEntry.Extract(entryStream);
                            entryStream.Position = 0;

                            // Add the extracted entry to the TAR archive
                            tarArchive.CreateEntry(rarEntry.Name, entryStream);
                        }
                    }

                    // Save the TAR archive as a gzipped file
                    tarArchive.SaveGzipped(outputTarGzPath);
                }
            }
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate a collection of legacy RAR backups to the more portable TAR.GZ format for Linux‑based systems using C#.
 * 2. When an automated nightly job must unpack multiple RAR archives, repackage their contents into compressed TAR files, and store them in a central output folder.
 * 3. When a cloud‑deployment pipeline requires converting user‑uploaded RAR uploads into TAR.GZ archives before further processing or storage.
 * 4. When you want to replace directory‑based extraction with stream‑based conversion to reduce disk I/O while transforming many RAR archives to TAR.GZ in a .NET application.
 * 5. When a data‑archiving tool must ensure each RAR archive is validated, its files are filtered (excluding directories), and the resulting TAR.GZ files are saved with matching names.
 */
