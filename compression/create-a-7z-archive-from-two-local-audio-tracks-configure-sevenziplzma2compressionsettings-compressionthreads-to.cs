// HOW-TO: Create 7z Archive of Two MP3 Files with 10 Compression Threads in C# (Aspose.ZIP for .NET)
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
            string inputPath1 = @"C:\Audio\track1.mp3";
            string inputPath2 = @"C:\Audio\track2.mp3";

            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            string outputPath = @"C:\Archives\highThread10.7z";

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            SevenZipLZMA2CompressionSettings lzma2Settings = new SevenZipLZMA2CompressionSettings();
            lzma2Settings.CompressionThreads = 10;

            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(lzma2Settings);

            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                using (FileStream fs1 = new FileStream(inputPath1, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry(Path.GetFileName(inputPath1), fs1);
                }
                using (FileStream fs2 = new FileStream(inputPath2, FileMode.Open, FileAccess.Read))
                {
                    archive.CreateEntry(Path.GetFileName(inputPath2), fs2);
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
 * 1. When you need to bundle multiple audio tracks into a single 7z file for easier distribution while maximizing CPU utilization with ten compression threads in a C# application.
 * 2. When you want to create a high‑performance LZMA2‑compressed archive of media files on a server that supports multi‑threaded compression using Aspose.Zip for .NET.
 * 3. When you are building a backup tool that stores selected MP3 files in a 7z container and you wish to control the number of threads to speed up the compression process.
 * 4. When you need to programmatically generate a 7z archive of music files for a desktop app and ensure the archive is created with specific entry settings for consistent compression behavior.
 * 5. When you are automating the packaging of audio assets for deployment and want to use Aspose.Zip’s SevenZipEntrySettings to set compression threads and save the archive to a predefined location.
 */
