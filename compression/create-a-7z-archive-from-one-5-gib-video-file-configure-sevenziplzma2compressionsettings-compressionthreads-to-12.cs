// HOW-TO: Create 7z Archive From Large Video With 12 Compression Threads In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\large_video.mp4";
            string outputPath = @"C:\Output\parallel.7z";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();
            compressionSettings.CompressionThreads = 12;

            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings);

            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                using (FileStream sourceStream = File.OpenRead(inputPath))
                {
                    string entryName = Path.GetFileName(inputPath);
                    archive.CreateEntry(entryName, sourceStream);
                }

                archive.Save(outputPath);
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
 * 1. When you need to compress a multi‑gigabyte video into a 7z file quickly by utilizing multiple CPU cores in a C# application.
 * 2. When you want to ensure a consistent compression setting (LZMA2 with 12 threads) for all entries added to a 7z archive in .NET.
 * 3. When you have to programmatically create a 7z backup of large media assets on a server without manual archiving tools.
 * 4. When you are building an automated pipeline that archives high‑resolution video files for storage optimization using Aspose.Zip for .NET.
 * 5. When you must generate a 7z archive in code and control the number of compression threads to balance performance and resource usage.
 */
