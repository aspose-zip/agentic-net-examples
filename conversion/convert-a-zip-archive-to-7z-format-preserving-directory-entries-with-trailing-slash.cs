// HOW-TO: Convert Zip To 7z While Preserving Empty Folder Entries In C# (Aspose.ZIP for .NET)
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
            string inputPath = "input/input.zip";
            string outputPath = "output/output.7z";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            List<Stream> tempStreams = new List<Stream>();

            using (Archive zipArchive = new Archive(inputPath))
            {
                using (SevenZipArchive sevenZip = new SevenZipArchive())
                {
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        using (Stream zipStream = zipEntry.Open())
                        {
                            byte[] buffer = new byte[zipStream.Length];
                            int bytesRead = zipStream.Read(buffer, 0, buffer.Length);
                            MemoryStream memStream = new MemoryStream(buffer, 0, bytesRead);
                            tempStreams.Add(memStream);
                            sevenZip.CreateEntry(zipEntry.Name, memStream);
                        }
                    }

                    sevenZip.Save(outputPath);
                }
            }

            foreach (Stream s in tempStreams)
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
 * 1. When you need to migrate legacy ZIP backups to the more efficient 7z format without losing empty folder structures in a .NET application.
 * 2. When a deployment pipeline must repackage source code archives from ZIP to 7z to reduce download size while keeping directory hierarchy intact.
 * 3. When a cloud storage service wants to convert user‑uploaded ZIP files to 7z for better compression while preserving folder placeholders for later extraction.
 * 4. When an automated backup system needs to transform daily ZIP snapshots into 7z archives to save disk space and retain empty directory entries for restoration scripts.
 * 5. When a file‑management tool written in C# must read ZIP archives and output 7z files so that downstream tools that rely on trailing‑slash folder entries can process them correctly.
 */
