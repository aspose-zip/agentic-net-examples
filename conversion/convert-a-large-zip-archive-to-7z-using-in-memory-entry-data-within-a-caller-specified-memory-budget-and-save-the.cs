// HOW-TO: Convert Large ZIP Archive to 7z In-Memory Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP and output 7z paths
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            // Validate input ZIP file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(output7zPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Create a new 7z archive
                using (SevenZipArchive sevenZip = new SevenZipArchive())
                {
                    // Iterate over each entry in the ZIP archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Skip directories
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Read entry data into a memory stream
                        using (MemoryStream entryData = new MemoryStream())
                        {
                            using (Stream entryStream = zipEntry.Open())
                            {
                                entryStream.CopyTo(entryData);
                            }

                            // Reset stream position for reading
                            entryData.Position = 0;

                            // Add entry to the 7z archive
                            sevenZip.CreateEntry(zipEntry.Name, entryData);
                        }
                    }

                    // Save the 7z archive to the specified output path
                    sevenZip.Save(output7zPath);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to shrink a massive ZIP file into a more compact 7z archive without writing intermediate files to disk.
 * 2. When an application must repackage user‑uploaded ZIP bundles into 7z format while staying within a predefined memory budget.
 * 3. When a server‑side service converts legacy ZIP backups to 7z for better compression before storing them in cloud storage.
 * 4. When a .NET utility processes large archives in memory to avoid I/O overhead during format migration using Aspose.Zip.
 * 5. When a build pipeline transforms packaged assets from ZIP to 7z to reduce artifact size for faster deployment.
 */
