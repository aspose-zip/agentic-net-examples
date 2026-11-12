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
            // Define source directory containing files to archive
            string sourceDir = "C:\\SourceFiles";
            if (!Directory.Exists(sourceDir))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDir}");
                return;
            }

            // Define output 7z file path
            string outputPath = "C:\\Output\\parallel.7z";
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure LZMA2 compression with thread count equal to processor count
            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();
            compressionSettings.CompressionThreads = Environment.ProcessorCount;

            // Create entry settings using the configured compression settings
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings);

            // Create the 7z archive with the specified entry settings
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                // Add all files from the source directory to the archive
                archive.CreateEntries(sourceDir);
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
 * 1. When you need to compress a large folder into a 7z file using all CPU cores for faster processing in a C# application.
 * 2. When you want to generate a portable 7z archive for backup or distribution while programmatically setting the LZMA2 thread count.
 * 3. When building an automated build pipeline that packages build artifacts into a high‑performance 7z archive on Windows.
 * 4. When creating a desktop utility that archives user‑selected files with optimal multi‑threaded compression to reduce archive creation time.
 * 5. When implementing a server‑side service that compresses uploaded files into a 7z archive using the machine’s processor count for maximum efficiency.
 */
