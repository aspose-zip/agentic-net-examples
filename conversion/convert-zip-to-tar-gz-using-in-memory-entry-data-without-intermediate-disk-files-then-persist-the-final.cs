// HOW-TO: Convert ZIP Archive to TAR.GZ In Memory Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        string zipPath = "input.zip";
        string outputPath = "output.tar.gz";

        if (!File.Exists(zipPath))
        {
            Console.Error.WriteLine($"File not found: {zipPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            List<MemoryStream> entryStreams = new List<MemoryStream>();

            using (Archive zipArchive = new Archive(zipPath))
            {
                using (TarArchive tarArchive = new TarArchive())
                {
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        using (Stream zipEntryStream = zipEntry.Open())
                        {
                            MemoryStream memoryStream = new MemoryStream();
                            zipEntryStream.CopyTo(memoryStream);
                            memoryStream.Position = 0;
                            entryStreams.Add(memoryStream);
                            tarArchive.CreateEntry(zipEntry.Name, memoryStream);
                        }
                    }

                    using (GzipArchive gzipArchive = new GzipArchive())
                    {
                        gzipArchive.SetSource(tarArchive);
                        gzipArchive.Save(outputPath);
                    }
                }
            }

            foreach (MemoryStream ms in entryStreams)
            {
                ms.Dispose();
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
 * 1. When you need to repackage a downloaded ZIP file as a TAR.GZ for deployment to a Linux server without writing temporary files to disk.
 * 2. When a cloud function must transform user‑uploaded ZIP archives into compressed TAR streams for storage in an object bucket while keeping memory usage low.
 * 3. When an automated build pipeline has to convert artifact ZIP packages into TAR.GZ format for compatibility with legacy Unix tools without creating intermediate files.
 * 4. When a desktop application wants to compress selected ZIP entries into a single TAR.GZ archive for backup while ensuring all data stays in memory for security reasons.
 * 5. When a microservice processes incoming ZIP payloads and needs to forward them as TAR.GZ to another service that only accepts tarball streams.
 */
