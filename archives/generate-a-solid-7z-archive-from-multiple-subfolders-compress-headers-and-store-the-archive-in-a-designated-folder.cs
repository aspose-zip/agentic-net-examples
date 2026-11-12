// HOW-TO: Create Solid 7z Archive From Multiple Subfolders In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define source folder containing multiple subfolders
            string sourceFolder = @"C:\Data\Source";

            // Define output folder and archive file name
            string outputFolder = @"C:\Data\Output";
            string archivePath = Path.Combine(outputFolder, "solidArchive.7z");

            // Verify source folder exists
            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            // Configure LZMA2 compression
            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();

            // Enable solid mode for the archive
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings, null) { Solid = true };

            // Create the solid 7z archive from all files in the source folder (including subfolders)
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(sourceFolder);
                archive.Save(archivePath);
            }

            Console.WriteLine($"Solid 7z archive created at {archivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a large directory tree into a single compressed 7z file for efficient storage or transfer.
 * 2. When you want to improve compression ratios by using solid mode across all files in several subfolders.
 * 3. When you must generate a 7z archive programmatically in a .NET application and place it in a specific output directory.
 * 4. When you need to ensure the archive includes all nested folders without manually adding each file.
 * 5. When you require a reliable way to create a solid LZMA2‑compressed archive for backup or deployment pipelines.
 */
