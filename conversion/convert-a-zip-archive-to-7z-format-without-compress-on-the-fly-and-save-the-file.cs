// HOW-TO: Convert ZIP Archive To 7Z Format Without Recompressing In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.zip";
        string outputPath = "output.7z";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Archive zipArchive = new Archive(inputPath))
            {
                using (SevenZipArchive sevenZip = new SevenZipArchive())
                {
                    foreach (ArchiveEntry entry in zipArchive.Entries)
                    {
                        if (entry.IsDirectory)
                        {
                            continue;
                        }

                        using (Stream entryStream = entry.Open())
                        {
                            sevenZip.CreateEntry(entry.Name, entryStream);
                        }
                    }

                    sevenZip.Save(outputPath);
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
 * 1. When you need to package existing ZIP files into 7Z for distribution while preserving the original file sizes and avoiding additional compression overhead.
 * 2. When a .NET application must migrate legacy ZIP backups to the more efficient 7Z format without altering the stored data.
 * 3. When integrating with a system that only accepts 7Z archives, you can convert incoming ZIP uploads on the fly without recompressing each entry.
 * 4. When automating archival processes, you can batch‑convert multiple ZIP archives to 7Z to reduce storage costs while keeping extraction speed unchanged.
 * 5. When creating a downloadable bundle, you can transform a ZIP collection into a 7Z file to meet user expectations for modern archive formats without re‑encoding the contents.
 */
