// HOW-TO: Compress Large TIFF to BZ2 Using Seven Threads in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\large_image.tif";
            string outputPath = @"C:\Data\large_image.bz2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Bzip2 archive, set source file, and configure save options
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);

                Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                // Set the number of compression threads to seven
                saveOptions.CompressionThreads = 7;

                // Save the compressed file using the specified options
                archive.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce the storage size of high‑resolution TIFF images before uploading them to a cloud backup service, you can use this code to create a BZ2 archive with multithreaded compression.
 * 2. When processing large medical or satellite images in a C# application, this snippet lets you compress the files quickly by leveraging seven parallel threads with Aspose.Zip Bzip2.
 * 3. When a batch job must prepare image assets for distribution over limited‑bandwidth networks, the code generates a .bz2 file that can be decompressed on any standard Bzip2 client.
 * 4. When integrating file‑size optimization into an automated document‑management workflow, you can compress TIFF files on the fly using Aspose.Zip’s Bzip2SaveOptions and control the thread count for performance tuning.
 * 5. When building a desktop utility that archives large graphics files while keeping CPU usage balanced, this example shows how to set the number of compression threads to seven for efficient resource utilization.
 */
