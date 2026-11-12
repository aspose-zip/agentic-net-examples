// HOW-TO: Extract CSV Files from TAR.GZ and Merge with ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Gzip;
using Aspose.Zip.Tar;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string tarGzPath = "input.tar.gz";
            string zipPath = "input.zip";
            string outputPath = "combined.zip";

            if (!File.Exists(tarGzPath))
            {
                Console.Error.WriteLine($"File not found: {tarGzPath}");
                return;
            }
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Stream> openStreams = new List<Stream>();

            using (Archive combinedArchive = new Archive())
            {
                using (FileStream tarGzStream = File.OpenRead(tarGzPath))
                using (GzipArchive gzip = new GzipArchive(tarGzStream))
                using (Stream decompressed = gzip.Open())
                using (MemoryStream tarMemory = new MemoryStream())
                {
                    decompressed.CopyTo(tarMemory);
                    tarMemory.Position = 0;

                    using (TarArchive tarArchive = new TarArchive(tarMemory))
                    {
                        foreach (TarEntry tarEntry in tarArchive.Entries)
                        {
                            if (tarEntry.Name.EndsWith(".csv", StringComparison.OrdinalIgnoreCase))
                            {
                                Stream entryStream = tarEntry.Open();
                                openStreams.Add(entryStream);
                                combinedArchive.CreateEntry(tarEntry.Name, entryStream);
                            }
                        }
                    }
                }

                using (Archive sourceZip = new Archive(zipPath))
                {
                    foreach (ArchiveEntry zipEntry in sourceZip.Entries)
                    {
                        Stream entryStream = zipEntry.Open();
                        openStreams.Add(entryStream);
                        combinedArchive.CreateEntry(zipEntry.Name, entryStream);
                    }
                }

                combinedArchive.Save(outputPath, new ArchiveSaveOptions());
            }

            foreach (Stream s in openStreams)
            {
                s.Dispose();
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
 * 1. When you need to pull only CSV reports from a compressed tar.gz backup and combine them with existing files in a zip for downstream processing.
 * 2. When a data pipeline receives daily tar.gz archives of logs and you must extract specific CSV datasets and bundle them with other resources into a single zip for distribution.
 * 3. When migrating legacy archives that store CSV data in tar.gz format and you want to create a consolidated zip package for easy upload to cloud storage.
 * 4. When automating a build step that gathers CSV configuration files from a tar.gz source and merges them with assets already packaged in a zip to produce a final deployment archive.
 * 5. When generating a combined archive for end‑users that includes selected CSV files from a tar.gz source alongside other zipped documents, simplifying download and extraction.
 */
