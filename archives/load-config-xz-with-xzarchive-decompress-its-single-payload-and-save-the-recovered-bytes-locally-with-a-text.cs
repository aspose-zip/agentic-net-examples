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
            string inputPath = "config.xz";
            string outputDirectory = "output";
            string outputFilePath = Path.Combine(outputDirectory, "config.txt");
            string reportFilePath = Path.Combine(outputDirectory, "report.txt");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Decompress the XZ archive and save the extracted file
            using (XzArchive archive = new XzArchive(inputPath))
            {
                using (FileStream extracted = File.Create(outputFilePath))
                {
                    archive.Extract(extracted);
                }
            }

            // Get the size of the recovered file
            long recoveredByteCount = new FileInfo(outputFilePath).Length;

            // Write a text report with the recovered byte count
            string reportContent = $"Recovered byte count: {recoveredByteCount}";
            File.WriteAllText(reportFilePath, reportContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unpack a compressed configuration file (config.xz) during application startup and store the original text for further processing.
 * 2. When a deployment script must extract a single XZ‑compressed payload and verify the extraction size by creating a simple text report.
 * 3. When you want to programmatically read a .xz archive using Aspose.Zip.Xz in C# and save the extracted content to a known location on disk.
 * 4. When you need to log the exact number of bytes recovered from an XZ archive to aid in troubleshooting data integrity issues.
 * 5. When an automated build pipeline requires extracting a compressed resource and documenting its size without using external command‑line tools.
 */
