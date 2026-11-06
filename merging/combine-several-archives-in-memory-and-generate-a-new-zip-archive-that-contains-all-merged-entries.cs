// HOW-TO: Combine Multiple ZIP Files into One Archive Using Aspose.Zip C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string dataDir = "Data" + Path.DirectorySeparatorChar;
            string[] sourceArchives = new string[]
            {
                dataDir + "archive1.zip",
                dataDir + "archive2.zip",
                dataDir + "archive3.zip"
            };
            string outputPath = dataDir + "combined.zip";

            // Validate input files
            foreach (string srcPath in sourceArchives)
            {
                if (!File.Exists(srcPath))
                {
                    Console.Error.WriteLine($"File not found: {srcPath}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // List to hold streams that must stay open until the archive is saved
            List<Stream> openEntryStreams = new List<Stream>();

            // Create a new empty archive
            using (Archive combinedArchive = new Archive())
            {
                // Iterate over each source archive and copy its entries
                foreach (string srcPath in sourceArchives)
                {
                    using (Archive srcArchive = new Archive(srcPath))
                    {
                        foreach (ArchiveEntry entry in srcArchive.Entries)
                        {
                            // Open the source entry stream
                            Stream entryStream = entry.Open();
                            // Add the entry to the combined archive using the same name
                            combinedArchive.CreateEntry(entry.Name, entryStream);
                            // Keep the stream alive until after Save
                            openEntryStreams.Add(entryStream);
                        }
                    }
                }

                // Save the combined archive to the output path
                combinedArchive.Save(outputPath);
            }

            // Dispose all entry streams after the archive has been saved
            foreach (Stream s in openEntryStreams)
            {
                s.Dispose();
            }

            Console.WriteLine("Archives merged successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to merge several project backup ZIPs into a single archive for easier distribution.
 * 2. When an application must combine user‑uploaded ZIP packages into one downloadable bundle without writing intermediate files to disk.
 * 3. When a deployment script has to consolidate multiple module ZIPs into a single package before uploading to a server.
 * 4. When a data‑processing pipeline aggregates logs stored in separate ZIP archives into one archive for archival storage.
 * 5. When a cloud service needs to programmatically join multiple compressed datasets into a single ZIP to reduce API calls.
 */
