// HOW-TO: Merge Multiple ZIP Files Into One Archive And Release Resources In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file paths
            string inputPath1 = "input1.zip";
            string inputPath2 = "input2.zip";

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

            // Hardcoded output ZIP file path
            string outputPath = "output/merged.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the output archive
            using (Archive outputArchive = new Archive())
            {
                // Process first input archive
                using (Archive inputArchive1 = new Archive(inputPath1))
                {
                    foreach (ArchiveEntry entry in inputArchive1.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            // Add entry to the output archive
                            outputArchive.CreateEntry(entry.Name, entryStream);
                        }
                    }
                }

                // Process second input archive
                using (Archive inputArchive2 = new Archive(inputPath2))
                {
                    foreach (ArchiveEntry entry in inputArchive2.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            // Add entry to the output archive
                            outputArchive.CreateEntry(entry.Name, entryStream);
                        }
                    }
                }

                // Save the merged archive to disk
                outputArchive.Save(outputPath);
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
 * 1. When you need to combine several independent ZIP packages into a single distributable archive for deployment.
 * 2. When consolidating backup files from multiple sources into one compressed file to simplify storage management.
 * 3. When creating a unified resource bundle from separate module archives for a .NET application.
 * 4. When merging user‑uploaded zip files on a server before sending a combined download link.
 * 5. When combining log archives from different services into one archive while ensuring all file handles are properly released.
 */
