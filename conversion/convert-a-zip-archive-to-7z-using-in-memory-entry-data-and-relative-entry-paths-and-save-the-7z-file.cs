// HOW-TO: Convert ZIP Archive to 7z Using In-Memory Streams in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.zip";
            string outputPath = "output.7z";

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
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        using (MemoryStream entryData = new MemoryStream())
                        {
                            zipEntry.Extract(entryData);
                            entryData.Position = 0;
                            sevenZip.CreateEntry(zipEntry.Name, entryData);
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
 * 1. When you need to repackage files from a ZIP file into a 7z archive to achieve higher compression without writing temporary files to disk.
 * 2. When a cloud service receives ZIP uploads and must store them as 7z for standardized storage while processing the data entirely in memory.
 * 3. When migrating legacy backup archives from ZIP to 7z format in an automated C# pipeline without extracting the contents to the file system.
 * 4. When building a .NET application that consolidates user‑uploaded ZIP content into a single 7z package for download, preserving relative entry paths.
 * 5. When performing on‑the‑fly conversion of ZIP archives to 7z in a sandboxed environment where disk I/O must be minimized.
 */
