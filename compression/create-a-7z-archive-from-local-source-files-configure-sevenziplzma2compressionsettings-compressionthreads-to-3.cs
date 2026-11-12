// HOW-TO: Create 7z Archive With LZMA2 Using 3 Threads In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing files to archive
            string inputDir = @"C:\Data\Source";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Hardcoded output archive path
            string outputPath = @"C:\Data\parallel.7z";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure LZMA2 compression with 3 threads
            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();
            compressionSettings.CompressionThreads = 3;

            // Create entry settings using the compression settings
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings);

            // Create the 7z archive with the specified entry settings
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                // Add all files from the input directory to the archive
                archive.CreateEntries(inputDir);

                // Save the archive to the specified output path
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
 * 1. When you need to compress a large set of files into a 7z archive while limiting CPU usage by specifying three compression threads in a C# application.
 * 2. When you want to automate backup of a folder on Windows and generate a high‑performance LZMA2 7z file using Aspose.Zip for .NET.
 * 3. When you are building a deployment tool that packages source files into a single 7z archive with controlled multithreaded compression to speed up the process.
 * 4. When you need to create a portable archive for distribution and want to fine‑tune the compression thread count to balance speed and resource consumption.
 * 5. When you are integrating file archiving into a .NET service and require programmatic creation of a 7z archive with specific entry settings such as LZMA2 compression and thread count.
 */
