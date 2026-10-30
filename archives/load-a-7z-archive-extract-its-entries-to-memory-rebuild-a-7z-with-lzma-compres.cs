// HOW-TO: Rebuild 7z Archive with LZMA Compression from Memory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.7z";
        string outputPath = "output.7z";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (SevenZipArchive sourceArchive = new SevenZipArchive(inputPath))
            {
                List<Tuple<string, byte[]>> extractedEntries = new List<Tuple<string, byte[]>>();
                foreach (SevenZipArchiveEntry entry in sourceArchive.Entries)
                {
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        entry.Extract(memoryStream);
                        byte[] data = memoryStream.ToArray();
                        extractedEntries.Add(new Tuple<string, byte[]>(entry.Name, data));
                    }
                }

                using (SevenZipArchive newArchive = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipLZMACompressionSettings())))
                {
                    foreach (Tuple<string, byte[]> item in extractedEntries)
                    {
                        using (MemoryStream entryStream = new MemoryStream(item.Item2))
                        {
                            newArchive.CreateEntry(item.Item1, entryStream);
                        }
                    }

                    newArchive.Save(outputPath);
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
 * 1. When you need to read an existing 7z file, modify its contents in memory, and save a new 7z archive using LZMA compression for better size reduction in a C# application.
 * 2. When a backup system must repackage extracted files from a 7z archive into a fresh archive with consistent compression settings without writing intermediate files to disk.
 * 3. When you want to validate or re‑compress files from a third‑party 7z package before distributing them to clients, ensuring they are compressed with Aspose’s LZMA algorithm.
 * 4. When an automated pipeline extracts resources from a 7z bundle, processes them in memory, and then creates a new 7z archive to be uploaded to cloud storage.
 * 5. When a security tool needs to decompress a 7z archive, inspect each entry in memory, and rebuild a clean archive with LZMA compression to eliminate potential malicious metadata.
 */
