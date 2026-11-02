// HOW-TO: Create 7z Archive of Audio Files with 16-Thread LZMA2 Compression in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing audio files
            string inputDirectory = @"C:\AudioFiles";
            // Hardcoded output archive path
            string outputArchive = @"C:\Archives\parallel.7z";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchive));

            // Configure LZMA2 compression with 16 threads
            SevenZipLZMA2CompressionSettings lzma2Settings = new SevenZipLZMA2CompressionSettings();
            lzma2Settings.CompressionThreads = 16;

            // Apply compression settings to entry settings
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(lzma2Settings);

            // Create the 7z archive with the specified entry settings
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                // Add all files from the input directory to the archive
                archive.CreateEntries(inputDirectory);

                // Save the archive to the specified path
                archive.Save(outputArchive);
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
 * 1. When you need to bundle a large collection of music tracks into a single 7z file while maximizing CPU utilization with 16 compression threads.
 * 2. When you want to automate the creation of a high-performance archive for backup or distribution of audio assets in a .NET application.
 * 3. When you must ensure the output archive uses LZMA2 compression settings that are explicitly configured per entry for consistent compression results.
 * 4. When you are preparing audio files for upload to a server and need a smaller, multi-threaded compressed package to reduce transfer time.
 * 5. When you are integrating Aspose.Zip into a build pipeline to compress generated sound files in parallel for faster build artifacts.
 */
