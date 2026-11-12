// HOW-TO: Merge Two ZIP Files into a Compressed Archive Using C# (Aspose.ZIP for .NET)
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
            string inputPath1 = "C:\\Data\\archive1.zip";
            string inputPath2 = "C:\\Data\\archive2.zip";
            string outputPath = "C:\\Data\\merged.zip";

            // Verify input files exist
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

            // Create a new archive to hold merged entries
            using (Archive mergedArchive = new Archive())
            {
                // Copy entries from the first archive
                using (Archive archive1 = new Archive(inputPath1))
                {
                    foreach (ArchiveEntry entry in archive1.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream tempStream = new MemoryStream();
                            entryStream.CopyTo(tempStream);
                            tempStream.Position = 0;
                            mergedArchive.CreateEntry(entry.Name, tempStream);
                        }
                    }
                }

                // Copy entries from the second archive
                using (Archive archive2 = new Archive(inputPath2))
                {
                    foreach (ArchiveEntry entry in archive2.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream tempStream = new MemoryStream();
                            entryStream.CopyTo(tempStream);
                            tempStream.Position = 0;
                            mergedArchive.CreateEntry(entry.Name, tempStream);
                        }
                    }
                }

                // Save the merged archive with default compression (enabled)
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
 * 1. When you need to combine multiple backup ZIP files into a single compressed package for easier distribution.
 * 2. When consolidating separate module archives into one deployment bundle while preserving compression to reduce download size.
 * 3. When aggregating logs stored in different ZIP archives into a single archive for centralized analysis.
 * 4. When merging user‑generated content archives before uploading them to cloud storage to minimize storage costs.
 * 5. When creating a combined installer that includes resources from two existing ZIP packages without losing compression efficiency.
 */
