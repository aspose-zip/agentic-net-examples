// HOW-TO: Batch Convert RAR Archives to TAR.GZ with Buffered Streams in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing RAR files
            string inputDirectory = @"C:\InputRar";
            // Hardcoded output directory for TAR.GZ files
            string outputDirectory = @"C:\OutputTarGz";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Get all .rar files in the input directory
            string[] rarFiles = Directory.GetFiles(inputDirectory, "*.rar");
            foreach (string rarPath in rarFiles)
            {
                // Verify the RAR file exists
                if (!File.Exists(rarPath))
                {
                    Console.Error.WriteLine($"File not found: {rarPath}");
                    continue;
                }

                // Determine output TAR.GZ file path
                string baseName = Path.GetFileNameWithoutExtension(rarPath);
                string tarGzPath = Path.Combine(outputDirectory, baseName + ".tar.gz");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(tarGzPath));

                // Open the RAR archive for reading
                using (FileStream rarStream = File.OpenRead(rarPath))
                using (RarArchive rarArchive = new RarArchive(rarStream))
                using (TarArchive tarArchive = new TarArchive())
                {
                    // Iterate through each entry in the RAR archive
                    foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                    {
                        // Skip directories
                        if (rarEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Open the entry stream
                        using (Stream entryStream = rarEntry.Open())
                        {
                            // Copy entry data into a memory buffer
                            using (MemoryStream buffer = new MemoryStream())
                            {
                                entryStream.CopyTo(buffer);
                                buffer.Position = 0;

                                // Add the buffered data as a new entry in the TAR archive
                                tarArchive.CreateEntry(rarEntry.Name, buffer);
                            }
                        }
                    }

                    // Save the TAR archive compressed with GZIP
                    tarArchive.SaveGzipped(tarGzPath);
                }

                Console.WriteLine($"Converted '{rarPath}' to '{tarGzPath}'.");
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
 * 1. When you need to migrate legacy RAR backups to TAR.GZ for compatibility with Linux systems.
 * 2. When you want to automate the conversion of multiple RAR files in a folder to compressed TAR archives without loading entire files into memory.
 * 3. When you must preserve the original directory structure while extracting RAR entries and re‑packing them into a single .tar.gz file.
 * 4. When you are building a C# utility that processes user‑uploaded RAR archives and stores them as TAR.GZ for long‑term archival storage.
 * 5. When you require a reliable way to batch‑process RAR archives on Windows and output gzip‑compressed TAR files for downstream data pipelines.
 */
