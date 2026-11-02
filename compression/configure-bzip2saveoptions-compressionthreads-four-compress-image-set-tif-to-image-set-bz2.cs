// HOW-TO: Compress TIFF to BZ2 with 4 Threads Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\image_set.tif";
            string outputPath = @"C:\Data\image_set.bz2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Bzip2 archive, set source file, configure options, and save
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);

                Bzip2SaveOptions options = new Bzip2SaveOptions();
                options.CompressionThreads = 4;

                archive.Save(outputPath, options);
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
 * 1. When you need to reduce the storage size of large TIFF images before uploading them to a cloud backup service, you can compress them to BZ2 using multiple threads in C#.
 * 2. When building a .NET application that processes medical imaging files and must archive them efficiently for long‑term retention, this code creates a Bzip2 archive with configurable thread count.
 * 3. When a batch job must prepare high‑resolution scans for transmission over limited bandwidth, using Aspose.Zip to compress each TIFF into a .bz2 file speeds up the transfer.
 * 4. When integrating a document management system that stores original TIFF files but requires compressed archives for archival compliance, the example shows how to generate BZ2 files programmatically.
 * 5. When optimizing a server‑side service that generates reports as TIFF images and needs to free disk space quickly, setting CompressionThreads to four enables faster parallel Bzip2 compression in C#.
 */
