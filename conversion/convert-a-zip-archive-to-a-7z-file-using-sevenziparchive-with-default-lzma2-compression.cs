// HOW-TO: Convert ZIP Archive to 7z with LZMA2 Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        string inputZipPath = "input.zip";
        string output7zPath = "output.7z";

        try
        {
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath));

            using (Archive zipArchive = new Archive(inputZipPath))
            {
                using (SevenZipArchive sevenZip = new SevenZipArchive(
                    new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings())))
                {
                    List<Stream> openStreams = new List<Stream>();

                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        if (!zipEntry.IsDirectory)
                        {
                            Stream entryStream = zipEntry.Open();
                            openStreams.Add(entryStream);
                            sevenZip.CreateEntry(zipEntry.Name, entryStream);
                        }
                    }

                    sevenZip.Save(output7zPath);

                    foreach (Stream s in openStreams)
                    {
                        s.Dispose();
                    }
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
 * 1. When you need to shrink a collection of files packaged as a ZIP into a smaller 7z file for faster downloads or reduced storage costs.
 * 2. When your application must convert user‑uploaded ZIP archives to 7z format to maintain a consistent compression standard across all stored assets.
 * 3. When migrating legacy backup archives from ZIP to 7z to take advantage of LZMA2’s higher compression ratio using Aspose.Zip in a .NET service.
 * 4. When automating a build pipeline that receives ZIP artifacts and must repack them as 7z files before publishing to a release repository.
 * 5. When integrating with a third‑party system that only accepts 7z archives, requiring on‑the‑fly conversion of incoming ZIP files in a C# application.
 */
