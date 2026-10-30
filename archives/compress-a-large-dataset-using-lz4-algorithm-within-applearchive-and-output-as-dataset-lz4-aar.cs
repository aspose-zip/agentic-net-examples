// HOW-TO: Compress Large Dataset to LZ4 AppleArchive (.aar) Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input directory containing the large dataset
            string inputPath = @"C:\Data\LargeDataset";
            // Output file path for the compressed AppleArchive
            string outputPath = @"C:\Output\dataset_lz4.aar";

            // Verify that the input directory exists
            if (!Directory.Exists(inputPath))
            {
                Console.Error.WriteLine($"Directory not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Create LZ4 archive and compress the dataset
            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine($"Dataset compressed successfully to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce storage space for a massive data folder before transferring it to a remote server, you can compress it into an LZ4 AppleArchive (.aar) using C#.
 * 2. When building a backup solution that requires fast compression and decompression of large scientific datasets, this code creates a .aar file with LZ4 compression.
 * 3. When preparing data for distribution to mobile or macOS applications that accept AppleArchive format, you can package the dataset with LZ4 to minimize download size.
 * 4. When automating a nightly pipeline that archives log files and analytics data, the Lz4Archive class lets you generate a compact .aar file directly from a directory.
 * 5. When integrating Aspose.Zip LZ4 compression into a .NET service that streams large datasets to clients, this example shows how to create the compressed archive on the fly.
 */
