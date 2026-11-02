// HOW-TO: Create 7z Archive With Single-Thread LZMA2 Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output archive paths
            string inputDir = "Data";
            string outputPath = "output/parallel.7z";

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure LZMA2 compression with a single thread
            SevenZipLZMA2CompressionSettings lzma2Settings = new SevenZipLZMA2CompressionSettings();
            lzma2Settings.CompressionThreads = 1;

            // Apply the compression settings to entry settings
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(lzma2Settings);

            // Create the 7z archive, add all files from the input directory, and save it
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(inputDir);
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
 * 1. When you need to package a folder of files into a 7z archive using Aspose.Zip while limiting CPU usage to a single thread.
 * 2. When you want to generate a high‑ratio LZMA2‑compressed 7z file for backup purposes without affecting other parallel processes.
 * 3. When your application must create a 7z archive on the fly and you need to control the compression thread count for predictable performance.
 * 4. When deploying software that requires a reproducible 7z archive size and you want to enforce single‑thread compression to ensure consistent results.
 * 5. When integrating Aspose.Zip into a .NET service that creates archives from user‑uploaded files and you must minimize resource consumption during compression.
 */
