// HOW-TO: Merge Two ZIP Files While Preserving Entry Names In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"C:\Data\source1.zip";
            string inputPath2 = @"C:\Data\source2.zip";
            string outputPath = @"C:\Data\merged.zip";

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new empty archive for the merged result
            using (Archive mergedArchive = new Archive())
            {
                // Process first source archive
                using (Archive sourceArchive1 = new Archive(inputPath1))
                {
                    foreach (ArchiveEntry entry in sourceArchive1.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream buffer = new MemoryStream();
                            entryStream.CopyTo(buffer);
                            buffer.Position = 0;
                            mergedArchive.CreateEntry(entry.Name, buffer);
                        }
                    }
                }

                // Process second source archive
                using (Archive sourceArchive2 = new Archive(inputPath2))
                {
                    foreach (ArchiveEntry entry in sourceArchive2.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream buffer = new MemoryStream();
                            entryStream.CopyTo(buffer);
                            buffer.Position = 0;
                            mergedArchive.CreateEntry(entry.Name, buffer);
                        }
                    }
                }

                // Save the merged archive
                mergedArchive.Save(outputPath);
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
 * 1. When you need to combine multiple backup ZIP archives into a single archive without losing the original file names.
 * 2. When an application must consolidate reports generated in separate ZIP packages while keeping each report's path intact.
 * 3. When a deployment script merges resource bundles from different modules into one ZIP for distribution, preserving their entry names.
 * 4. When a data‑processing pipeline extracts files from several ZIP sources, stores them in memory, and then creates a unified archive that retains the original filenames.
 * 5. When you want to programmatically join user‑uploaded ZIP files on a server, ensuring the merged archive reflects the exact entry names from each source.
 */
