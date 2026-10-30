// HOW-TO: Decompress XZ Archive and Generate Byte Count Report in C# (Aspose.ZIP for .NET)
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
            string inputPath = "largefile.xz";
            string outputDataPath = "decompressed_output.bin";
            string reportPath = "decompression_report.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            string outputDataDir = Path.GetDirectoryName(outputDataPath);
            if (!string.IsNullOrEmpty(outputDataDir))
            {
                Directory.CreateDirectory(outputDataDir);
            }

            string reportDir = Path.GetDirectoryName(reportPath);
            if (!string.IsNullOrEmpty(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }

            // Decompress the XZ archive
            using (XzArchive archive = new XzArchive(inputPath))
            {
                using (FileStream extracted = File.Create(outputDataPath))
                {
                    archive.Extract(extracted);
                }
            }

            // Get the size of the recovered data
            long recoveredBytes = new FileInfo(outputDataPath).Length;

            // Write a text report with the byte count
            using (StreamWriter writer = new StreamWriter(reportPath))
            {
                writer.WriteLine($"Recovered byte count: {recoveredBytes}");
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
 * 1. When you need to extract a large .xz compressed data file and save the raw binary for further processing.
 * 2. When you must verify the integrity of decompressed data by logging the exact number of bytes recovered.
 * 3. When an application automates nightly extraction of backup archives stored in XZ format and records extraction metrics.
 * 4. When a data pipeline requires converting a single‑payload XZ archive into a usable binary file before feeding it to downstream services.
 * 5. When you want to create a simple audit trail that documents how many bytes were extracted from each compressed archive.
 */
