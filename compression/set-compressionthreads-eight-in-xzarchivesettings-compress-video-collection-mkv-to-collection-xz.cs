// HOW-TO: Compress MKV Video to XZ Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\video_collection.mkv";
            string outputPath = @"C:\Data\collection.xz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create XZ archive, add source file, and save
            using (XzArchive archive = new XzArchive())
            {
                // Specify the file to compress
                archive.SetSource(inputPath);

                // Save the compressed XZ archive
                archive.Save(outputPath);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to shrink a large MKV video file before uploading it to cloud storage to save bandwidth and storage costs.
 * 2. When you want to bundle a single video into an XZ archive for secure distribution over a low‑speed network.
 * 3. When your C# application must programmatically compress user‑generated video content to stay within server storage quotas.
 * 4. When building a surveillance system that archives recorded footage into XZ files for long‑term retention and easy extraction later.
 * 5. When automating the preparation of video assets for archival in a version‑controlled repository using Aspose.Zip’s XZ compression.
 */
