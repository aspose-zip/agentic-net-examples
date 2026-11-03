// HOW-TO: Convert a ZIP Archive to 7z with LZMA2 Compression in C# (Aspose.ZIP for .NET)
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
        try
        {
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath));

            List<Stream> openStreams = new List<Stream>();

            using (Archive zipArchive = new Archive(inputZipPath))
            using (SevenZipArchive sevenZip = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings())))
            {
                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    if (zipEntry.IsDirectory)
                    {
                        continue;
                    }

                    Stream entryStream = zipEntry.Open();
                    openStreams.Add(entryStream);
                    sevenZip.CreateEntry(zipEntry.Name, entryStream);
                }

                sevenZip.Save(output7zPath);
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
 * 1. When you need to reduce the size of an existing ZIP package for faster download by converting it to a 7z file using LZMA2 compression.
 * 2. When a .NET application must migrate legacy ZIP backups to the more efficient 7z format while preserving each file as a separate compressed entry.
 * 3. When you want to integrate Aspose.Zip into a build pipeline to automatically re‑compress generated ZIP artifacts into 7z for long‑term storage.
 * 4. When a client requires delivery of files in 7z format for compatibility with their extraction tools, and you have only the original ZIP source.
 * 5. When you need to programmatically convert user‑uploaded ZIP archives to 7z with high‑ratio LZMA2 compression before archiving them in a cloud repository.
 */
