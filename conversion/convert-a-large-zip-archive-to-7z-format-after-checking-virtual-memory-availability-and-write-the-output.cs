// HOW-TO: Convert Large ZIP to 7Z in C# While Managing Memory (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string zipPath = @"C:\Input\large.zip";
            string outputPath = @"C:\Output\converted.7z";

            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Archive zipArchive = new Archive(zipPath))
            using (SevenZipArchive sevenArchive = new SevenZipArchive())
            {
                List<Stream> openStreams = new List<Stream>();

                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    if (zipEntry.IsDirectory)
                    {
                        continue;
                    }

                    Stream entryStream = zipEntry.Open();
                    openStreams.Add(entryStream);
                    sevenArchive.CreateEntry(zipEntry.Name, entryStream);
                }

                sevenArchive.Save(outputPath);

                foreach (Stream s in openStreams)
                {
                    s.Dispose();
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
 * 1. When you need to migrate a multi‑gigabyte ZIP backup to a more efficient 7Z archive without loading the entire file into memory.
 * 2. When an application must programmatically repackage user‑uploaded ZIP files into 7Z format for reduced storage costs.
 * 3. When a server‑side process has limited virtual memory and must stream each entry while converting the archive.
 * 4. When you want to preserve the original directory structure while converting a ZIP archive to 7Z using Aspose.Zip in a .NET service.
 * 5. When automating archival workflows that require converting legacy ZIP collections to 7Z for compatibility with SevenZip tools.
 */
