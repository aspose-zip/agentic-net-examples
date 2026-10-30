// HOW-TO: Decompress Zstandard CPIO Archive and Generate Extraction Report in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip.Zstandard;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "archive.cpio.zst";
            string decompressedPath = "archive.cpio";
            string reportPath = "extracted_report.txt";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory for decompressed file exists
            string decompressedDir = Path.GetDirectoryName(decompressedPath);
            Directory.CreateDirectory(decompressedDir ?? ".");

            // Decompress Zstandard archive to a file
            using (ZstandardArchive zstArchive = new ZstandardArchive(inputPath))
            {
                using (FileStream outputStream = File.Create(decompressedPath))
                {
                    zstArchive.Extract(outputStream);
                }
            }

            // Gather information for report
            List<string> reportLines = new List<string>();
            reportLines.Add("Decompression Report");
            reportLines.Add("====================");
            reportLines.Add($"Input Zstandard file: {inputPath}");
            reportLines.Add($"Decompressed output file: {decompressedPath}");
            reportLines.Add($"File size (bytes): {new FileInfo(decompressedPath).Length}");

            // Ensure output directory for report exists
            string reportDir = Path.GetDirectoryName(reportPath);
            Directory.CreateDirectory(reportDir ?? ".");

            // Write report
            using (StreamWriter writer = new StreamWriter(reportPath, false))
            {
                foreach (string line in reportLines)
                {
                    writer.WriteLine(line);
                }
            }

            Console.WriteLine("Decompression completed. Report saved to: " + reportPath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a .cpio.zst file from a Linux build system and need to decompress it on a Windows .NET service.
 * 2. When you want to automate the extraction of a Zstandard‑compressed CPIO payload as part of a CI/CD pipeline.
 * 3. When you must create a simple text log of the decompressed file size and paths for audit or debugging purposes.
 * 4. When you need to ensure the output directories exist before writing the decompressed CPIO file and report file in a cross‑platform application.
 * 5. When you are building a migration tool that reads legacy CPIO archives packaged with Zstandard compression and records the extraction details for downstream processing.
 */
