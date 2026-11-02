// HOW-TO: Create 7z Archive With Custom Thread Count Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing mixed files
            string inputDir = @"C:\InputFiles";
            // Hardcoded output archive path
            string outputPath = @"C:\Output\parallel.7z";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Caller-selected positive thread count for compression
            int compressionThreads = 4; // example thread count

            // Configure LZMA2 compression settings
            SevenZipLZMA2CompressionSettings lzma2Settings = new SevenZipLZMA2CompressionSettings();
            lzma2Settings.CompressionThreads = compressionThreads;

            // Apply compression settings to entry settings
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(lzma2Settings);

            // Create 7z archive with the specified entry settings
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                // Add all files from the input directory
                archive.CreateEntries(inputDir);
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
 * 1. When you need to compress a folder of mixed file types into a 7z archive while controlling the number of CPU threads for faster performance.
 * 2. When you want to generate a 7z backup of logs, images, and documents on a Windows server using Aspose.Zip and specify parallel compression.
 * 3. When an application must create a portable 7z package for distribution and optimize compression speed by setting a positive thread count.
 * 4. When you are building a batch job that archives daily reports into a 7z file and need to limit CPU usage by configuring compression threads.
 * 5. When you need to programmatically archive mixed content into a 7z file in C# and ensure the output directory is created automatically.
 */
