// HOW-TO: Decompress XZ Archive and Save Payload to File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "multi_check.xz";
            string outputPath = "output/payload.bin";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Open the XZ archive and extract its single entry
            using (XzArchive archive = new XzArchive(inputPath))
            {
                using (FileStream extracted = File.Create(outputPath))
                {
                    archive.Extract(extracted);
                }
            }

            Console.WriteLine("Decompression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically extract a single file from an XZ‑compressed backup and store it on disk using C#.
 * 2. When an application must verify the existence of an XZ archive before attempting decompression to avoid runtime errors.
 * 3. When you want to ensure the output directory is created automatically before writing the extracted payload.
 * 4. When you need to catch and log decompression exceptions from Aspose.Zip.Xz to diagnose corrupted or unsupported XZ files.
 * 5. When integrating Aspose.Zip into a .NET service that processes XZ archives received from external systems.
 */
