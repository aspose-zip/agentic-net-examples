// HOW-TO: Create 7z Archive With LZMA2 Multi‑Thread Compression In C# (Aspose.ZIP for .NET)
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
            // Input image files
            string inputPath1 = "image1.jpg";
            string inputPath2 = "image2.png";
            string inputPath3 = "image3.bmp";

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
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Output archive path
            string outputPath = "output/parallel.7z";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure LZMA2 compression with 2 threads
            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();
            compressionSettings.CompressionThreads = 2;

            // Create entry settings using the compression settings
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings);

            // Create the 7z archive and add entries
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntry(Path.GetFileName(inputPath1), inputPath1);
                archive.CreateEntry(Path.GetFileName(inputPath2), inputPath2);
                archive.CreateEntry(Path.GetFileName(inputPath3), inputPath3);

                // Save the archive
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
 * 1. When you need to bundle several image files into a single 7z archive for easier distribution while limiting CPU usage to two compression threads.
 * 2. When you want to generate a compressed backup of JPEG, PNG, and BMP assets in a .NET application using Aspose.Zip’s LZMA2 settings.
 * 3. When you are building a deployment package that must meet size constraints and you need to fine‑tune compression parallelism for faster archive creation.
 * 4. When you need to programmatically create a multi‑threaded 7z archive on a server to reduce processing time compared to single‑threaded compression.
 * 5. When you are integrating image resources into a game or mobile app and want to compress them into a single 7z file with predictable thread usage.
 */
