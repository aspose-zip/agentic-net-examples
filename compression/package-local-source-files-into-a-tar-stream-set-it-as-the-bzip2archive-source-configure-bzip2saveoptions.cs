// HOW-TO: Create Bzip2 Compressed TAR Archive With Multi‑Threading In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define source directory containing files to be archived
            string sourceDirectory = "C:\\Data";
            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            // Prepare TAR archive and add files
            using (TarArchive tarArchive = new TarArchive())
            {
                string[] sourceFiles = Directory.GetFiles(sourceDirectory);
                foreach (string filePath in sourceFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    tarArchive.CreateEntry(entryName, filePath);
                }

                // Prepare Bzip2 archive, set TAR as its source
                using (Bzip2Archive bzip2Archive = new Bzip2Archive())
                {
                    bzip2Archive.SetSource(tarArchive);

                    // Configure Bzip2 save options with 2 compression threads
                    Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                    saveOptions.CompressionThreads = 2;

                    // Define output path and ensure directory exists
                    string outputPath = "C:\\Output\\parallel.tar.bz2";
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Save the compressed TAR.BZ2 archive
                    bzip2Archive.Save(outputPath, saveOptions);
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
 * 1. When you need to bundle a set of files from a local folder into a single TAR archive and compress it with Bzip2 to reduce storage size while preserving Unix‑style metadata.
 * 2. When you want to generate a .tar.bz2 backup of application data on a Windows server using C# and control the number of compression threads for faster processing.
 * 3. When you are implementing a cross‑platform deployment package that must be compressed with Bzip2, and you need to create the TAR stream programmatically before compression.
 * 4. When you need to automate archival of log files into a Bzip2‑compressed TAR file with parallel compression to minimize CPU bottlenecks.
 * 5. When you are building a .NET utility that creates compressed archives for transfer over limited‑bandwidth networks, and you want to specify two compression threads for optimal performance.
 */
