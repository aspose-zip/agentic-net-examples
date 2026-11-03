// HOW-TO: Convert TAR Archive To ZIP File Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.tar";
            string outputPath = "archive.zip";

            // Verify input TAR file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // Open the source TAR archive
            using (TarArchive tarArchive = new TarArchive(inputPath))
            {
                // Create a new ZIP archive
                using (Archive zipArchive = new Archive())
                {
                    // Iterate through TAR entries and add them to ZIP
                    foreach (TarEntry tarEntry in tarArchive.Entries)
                    {
                        // Skip directory entries; file entries will create necessary folders
                        if (tarEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Open the TAR entry as a stream
                        using (Stream entryStream = tarEntry.Open())
                        {
                            // Add entry to ZIP archive with the same relative path
                            zipArchive.CreateEntry(tarEntry.Name, entryStream);
                        }
                    }

                    // Save the ZIP archive to the output path
                    zipArchive.Save(outputPath);
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
 * 1. When you need to migrate legacy .tar backups to a .zip format for compatibility with Windows tools.
 * 2. When a CI/CD pipeline must repackage tar‑packed artifacts into zip files before publishing to a NuGet feed.
 * 3. When an application receives user‑uploaded .tar archives and must store them as .zip to reduce storage costs.
 * 4. When you want to automate the conversion of server‑generated tar logs into zip archives for easier email attachment.
 * 5. When a cross‑platform deployment script requires converting tar bundles into zip archives for use with .NET deployment utilities.
 */
