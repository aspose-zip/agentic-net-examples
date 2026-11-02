// HOW-TO: Create 7z Archive with LZMA2 Compression Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing files to be added to the archive
            string inputDir = @"C:\Data\Files";

            // Hardcoded output path for the 7z archive
            string outputPath = @"C:\Output\archive.7z";

            // Verify that the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure LZMA2 compression for all entries
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings());

            // Create the 7z archive with the specified compression settings
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
 * 1. When you need to bundle a folder of files into a single 7z file with high compression for backup or distribution.
 * 2. When you want to programmatically generate a 7z archive in a .NET application without using external tools.
 * 3. When you must ensure all entries use the same LZMA2 compression settings for consistent archive size and performance.
 * 4. When you need to save the resulting 7z archive to a specific location on the file system for later retrieval.
 * 5. When you want to automate the creation of compressed archives as part of a build or deployment pipeline in C#.
 */
