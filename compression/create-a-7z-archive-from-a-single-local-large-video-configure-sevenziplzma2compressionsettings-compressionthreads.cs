// HOW-TO: Create Single-Threaded 7z Archive From Large Video In C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Videos\largeVideo.mp4";
            string outputPath = @"C:\Archives\singleThread.7z";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();
            compressionSettings.CompressionThreads = 1;

            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings);

            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                using (FileStream inputStream = File.OpenRead(inputPath))
                {
                    archive.CreateEntry(Path.GetFileName(inputPath), inputStream);
                    archive.Save(outputPath);
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
 * 1. When you need to compress a huge video file into a 7z archive while limiting CPU usage to a single thread in a C# application.
 * 2. When you want to generate a reproducible 7z package for distribution that uses LZMA2 compression with a fixed thread count to ensure consistent performance across machines.
 * 3. When building an automated backup script that archives media files into 7z format and must run on servers with limited parallel processing resources.
 * 4. When integrating Aspose.Zip into a video processing pipeline and you must control the number of compression threads to avoid overloading the system.
 * 5. When creating a single-threaded 7z archive for compliance or testing purposes where deterministic compression settings are required.
 */
