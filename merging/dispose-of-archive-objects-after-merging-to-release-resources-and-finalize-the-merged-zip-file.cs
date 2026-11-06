// HOW-TO: Merge Two ZIP Files and Properly Dispose Archives in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "input1.zip";
            string inputPath2 = "input2.zip";
            string outputPath = "merged.zip";

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
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open source archives and create destination archive
            using (Archive sourceArchive1 = new Archive(inputPath1))
            using (Archive sourceArchive2 = new Archive(inputPath2))
            using (Archive destinationArchive = new Archive())
            {
                // Copy entries from the first archive
                foreach (ArchiveEntry sourceEntry in sourceArchive1.Entries)
                {
                    using (Stream sourceStream = sourceEntry.Open())
                    {
                        destinationArchive.CreateEntry(sourceEntry.Name, sourceStream);
                    }
                }

                // Copy entries from the second archive, handling duplicate names
                foreach (ArchiveEntry sourceEntry in sourceArchive2.Entries)
                {
                    string entryName = sourceEntry.Name;
                    if (destinationArchive.Entries.Any(e => e.Name == entryName))
                    {
                        // Simple rename to avoid conflict
                        string nameWithoutExt = Path.GetFileNameWithoutExtension(entryName);
                        string ext = Path.GetExtension(entryName);
                        entryName = $"{nameWithoutExt}_2{ext}";
                    }

                    using (Stream sourceStream = sourceEntry.Open())
                    {
                        destinationArchive.CreateEntry(entryName, sourceStream);
                    }
                }

                // Save the merged archive
                destinationArchive.Save(outputPath);
            }

            Console.WriteLine($"Merged archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine multiple ZIP packages into a single archive while ensuring file handles are released to avoid locking issues.
 * 2. When an application must programmatically merge backup archives on a server and guarantee that the resulting ZIP is finalized before further processing.
 * 3. When you are building a deployment tool that consolidates plugin bundles into one ZIP and must clean up resources to prevent memory leaks.
 * 4. When integrating third‑party ZIP files into a larger package and need deterministic disposal of the source archives to maintain file system stability.
 * 5. When automating document archiving workflows that require merging user‑uploaded ZIPs and ensuring the merged file is safely written and closed.
 */
