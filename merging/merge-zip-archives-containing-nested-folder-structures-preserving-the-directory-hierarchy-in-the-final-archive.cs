// HOW-TO: Merge Multiple ZIP Files While Preserving Folder Structure in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP archive paths
            string inputPath1 = @"C:\Data\Archive1.zip";
            string inputPath2 = @"C:\Data\Archive2.zip";

            // Hardcoded output ZIP archive path
            string outputPath = @"C:\Data\Merged.zip";

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

            // Create the destination archive
            using (Archive mergedArchive = new Archive())
            {
                // Array of source archive paths
                string[] sourceArchives = new string[] { inputPath1, inputPath2 };

                foreach (string srcPath in sourceArchives)
                {
                    // Open source archive
                    using (Archive srcArchive = new Archive(srcPath))
                    {
                        foreach (ArchiveEntry srcEntry in srcArchive.Entries)
                        {
                            // Open source entry stream
                            using (Stream srcStream = srcEntry.Open())
                            {
                                // Add entry to merged archive preserving the entry name (including folder hierarchy)
                                mergedArchive.CreateEntry(srcEntry.Name, srcStream);
                            }
                        }
                    }
                }

                // Save merged archive to the output path
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
 * 1. When you need to combine several project backup ZIPs into a single archive without losing the original sub‑folder organization.
 * 2. When deploying a software release that consists of multiple component ZIPs and you want a unified installer package that keeps each component’s directory layout.
 * 3. When aggregating logs or data exports stored in separate ZIP archives into one archive for easier transfer while maintaining their nested folder hierarchy.
 * 4. When creating a consolidated archive of user‑generated content from different sources, ensuring each user's folder structure remains intact.
 * 5. When automating the preparation of a large data set for cloud upload, merging multiple zipped datasets while preserving their internal directory structures.
 */
