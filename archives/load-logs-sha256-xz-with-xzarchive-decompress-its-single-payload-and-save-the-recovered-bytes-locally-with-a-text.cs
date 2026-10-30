// HOW-TO: Decompress XZ Archive and Generate Byte Count Report in C# (Aspose.ZIP for .NET)
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
            string inputPath = "logs_sha256.xz";
            string outputPath = "logs_sha256.bin";
            string reportPath = "recovery_report.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string reportDir = Path.GetDirectoryName(reportPath);
            if (!string.IsNullOrEmpty(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }

            // Decompress the XZ file
            using (XzArchive archive = new XzArchive(inputPath))
            {
                using (FileStream extracted = File.Create(outputPath))
                {
                    archive.Extract(extracted);
                }
            }

            // Determine recovered byte count
            long recoveredBytes;
            using (FileStream resultStream = File.OpenRead(outputPath))
            {
                recoveredBytes = resultStream.Length;
            }

            // Write a text report with the byte count
            string reportContent = $"Recovered byte count: {recoveredBytes}";
            File.WriteAllText(reportPath, reportContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a single compressed log file in XZ format and verify how many bytes were recovered.
 * 2. When you want to automate the decompression of XZ archives on a server and store the raw binary output for further analysis.
 * 3. When you must create a simple text report that records the size of the extracted data for auditing or monitoring purposes.
 * 4. When integrating Aspose.Zip XzArchive into a .NET application to handle large SHA‑256 checksum logs without manual command‑line tools.
 * 5. When building a backup validation script that confirms the integrity of recovered files by comparing the reported byte count to expected values.
 */
