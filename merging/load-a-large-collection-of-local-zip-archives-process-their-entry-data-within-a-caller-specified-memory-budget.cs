// HOW-TO: Merge Multiple ZIP Files into One Archive with Duplicate Name Handling in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded data directory
            string dataDir = @"C:\Data\";

            // Input ZIP archive paths
            string[] inputArchives = new string[]
            {
                dataDir + "archive1.zip",
                dataDir + "archive2.zip",
                dataDir + "archive3.zip"
                // Add more paths as needed
            };

            // Verify each input archive exists
            foreach (string inputPath in inputArchives)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Output merged ZIP path
            string outputPath = dataDir + "merged.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Track entry names to handle collisions
            HashSet<string> existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Create a new empty archive for merging
            using (Archive mergedArchive = new Archive())
            {
                // Process each source archive
                foreach (string inputPath in inputArchives)
                {
                    using (Archive sourceArchive = new Archive(inputPath))
                    {
                        foreach (ArchiveEntry sourceEntry in sourceArchive.Entries)
                        {
                            // Determine a unique entry name
                            string originalName = sourceEntry.Name;
                            string finalName = originalName;
                            int duplicateIndex = 1;
                            while (existingNames.Contains(finalName))
                            {
                                string nameWithoutExt = Path.GetFileNameWithoutExtension(originalName);
                                string ext = Path.GetExtension(originalName);
                                finalName = $"{nameWithoutExt}_{duplicateIndex}{ext}";
                                duplicateIndex++;
                            }
                            existingNames.Add(finalName);

                            // Extract entry content to a memory stream
                            using (MemoryStream entryStream = new MemoryStream())
                            {
                                sourceEntry.Extract(entryStream);
                                entryStream.Position = 0;

                                // Add the entry to the merged archive
                                mergedArchive.CreateEntry(finalName, entryStream);
                            }
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
 * 1. When you need to combine dozens of log‑file ZIP archives into a single package while ensuring files with the same name are renamed to avoid overwriting.
 * 2. When a backup system must consolidate multiple user‑generated ZIP backups into one archive without exceeding a predefined memory limit.
 * 3. When an application processes large sets of compressed data sets and must produce a merged ZIP for distribution, handling entry‑name collisions automatically.
 * 4. When you are building a deployment tool that gathers resources from several module ZIPs into one installer archive while preserving all unique files.
 * 5. When a data‑migration script has to read many source ZIPs, merge their contents, and create a single archive without losing any duplicate‑named entries.
 */
