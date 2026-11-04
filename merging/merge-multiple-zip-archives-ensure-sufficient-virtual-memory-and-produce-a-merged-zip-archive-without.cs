// HOW-TO: Merge Multiple ZIP Files into One Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP archive paths
            string inputArchivePath1 = "Data/Archive1.zip";
            string inputArchivePath2 = "Data/Archive2.zip";
            string inputArchivePath3 = "Data/Archive3.zip";

            // Verify each input archive exists
            if (!File.Exists(inputArchivePath1))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath1}");
                return;
            }
            if (!File.Exists(inputArchivePath2))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath2}");
                return;
            }
            if (!File.Exists(inputArchivePath3))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath3}");
                return;
            }

            // Hardcoded output ZIP archive path
            string outputArchivePath = "Output/Merged.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // List of source archive paths
            List<string> sourceArchives = new List<string>();
            sourceArchives.Add(inputArchivePath1);
            sourceArchives.Add(inputArchivePath2);
            sourceArchives.Add(inputArchivePath3);

            // Create the target archive
            using (Archive targetArchive = new Archive())
            {
                // Keep track of memory streams for each entry to dispose after saving
                List<MemoryStream> entryStreams = new List<MemoryStream>();

                // Iterate over each source archive
                foreach (string srcPath in sourceArchives)
                {
                    using (Archive sourceArchive = new Archive(srcPath))
                    {
                        // Iterate over each entry in the source archive
                        foreach (ArchiveEntry sourceEntry in sourceArchive.Entries)
                        {
                            // Extract entry content into a memory stream
                            MemoryStream entryStream = new MemoryStream();
                            sourceEntry.Extract(entryStream);
                            entryStream.Position = 0;

                            // Add the entry to the target archive with the same name
                            targetArchive.CreateEntry(sourceEntry.Name, entryStream);

                            // Store the stream for later disposal
                            entryStreams.Add(entryStream);
                        }
                    }
                }

                // Save the merged archive
                targetArchive.Save(outputArchivePath);

                // Dispose all entry memory streams
                foreach (MemoryStream ms in entryStreams)
                {
                    ms.Dispose();
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
 * 1. When you need to combine several project backup ZIPs into a single downloadable package without creating temporary files on disk.
 * 2. When a cloud service must consolidate user‑uploaded ZIP archives into one archive while managing memory usage efficiently.
 * 3. When an automated build pipeline has to merge artifact ZIPs from different stages into a final release bundle.
 * 4. When a desktop application wants to bundle selected document collections stored as separate ZIPs into one portable archive for offline sharing.
 * 5. When a data migration tool must combine multiple archived data sets into a single ZIP while ensuring virtual memory limits are respected.
 */
