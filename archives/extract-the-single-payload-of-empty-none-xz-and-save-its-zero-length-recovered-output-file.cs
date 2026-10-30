// HOW-TO: Extract Single Payload From XZ Archive To File In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "empty_none.xz";
            string outputPath = "output/empty_none_extracted.bin";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the XZ archive
            using (XzArchive archive = new XzArchive(inputPath))
            {
                // Create the output file stream
                using (FileStream extracted = File.Create(outputPath))
                {
                    // Extract the single payload (zero-length) to the output file
                    archive.Extract(extracted);
                }
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
 * 1. When you need to programmatically extract the only file from an XZ compressed archive in a .NET application.
 * 2. When you must verify that an XZ archive contains a zero‑length payload and recreate the original empty file.
 * 3. When automating a build pipeline that extracts configuration files packaged as single‑payload XZ archives.
 * 4. When handling firmware updates delivered as XZ archives that contain a single binary blob to be written to disk.
 * 5. When creating a utility that checks the integrity of XZ archives by extracting their payload without loading the entire archive into memory.
 */
