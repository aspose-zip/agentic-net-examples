// HOW-TO: Combine Multiple ZIP Files Into One Archive In C# Without Temporary Files (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded source archive paths
            string[] sourcePaths = {
                @"C:\Data\source1.zip",
                @"C:\Data\source2.zip"
            };

            // Hardcoded output archive path
            string outputPath = @"C:\Data\combined.zip";

            // Validate each source archive exists
            foreach (string srcPath in sourcePaths)
            {
                if (!File.Exists(srcPath))
                {
                    Console.Error.WriteLine($"File not found: {srcPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Create the output ZIP archive
            using (Archive outputArchive = new Archive())
            {
                // Iterate over each source archive
                foreach (string srcPath in sourcePaths)
                {
                    // Open source archive for reading
                    using (Archive inputArchive = new Archive(srcPath))
                    {
                        // Copy each entry from source to output without intermediate storage
                        foreach (ArchiveEntry entry in inputArchive.Entries)
                        {
                            using (Stream entryStream = entry.Open())
                            {
                                // Preserve original entry name
                                outputArchive.CreateEntry(entry.Name, entryStream);
                            }
                        }
                    }
                }

                // Save the combined archive to the output file
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    outputArchive.Save(outStream);
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
 * 1. When you need to merge several backup ZIP archives into a single package for easier distribution without using extra disk space.
 * 2. When a cloud service must bundle multiple user‑uploaded ZIP files into one archive before uploading to storage, avoiding intermediate extraction.
 * 3. When an application creates separate module ZIPs during build and later combines them into a single deployment package without writing temporary files.
 * 4. When a data migration tool consolidates archived logs from different sources into one ZIP to simplify archival and retrieval.
 * 5. When a reporting system aggregates compressed document bundles from various departments into a single ZIP for secure emailing, keeping the process memory‑efficient.
 */
