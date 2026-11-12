// HOW-TO: Extract Single File From XZ Archive And Generate Byte Count Report In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "data/video_archive.xz";
            string outputDirectory = "output";
            string outputFilePath = Path.Combine(outputDirectory, "video_recovered.bin");
            string reportFilePath = Path.Combine(outputDirectory, "video_report.txt");

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Decompress the XZ archive to a file
            using (XzArchive archive = new XzArchive(inputPath))
            {
                using (FileStream extractedStream = File.Create(outputFilePath))
                {
                    archive.Extract(extractedStream);
                }
            }

            // Get the size of the recovered file
            FileInfo recoveredInfo = new FileInfo(outputFilePath);
            long recoveredByteCount = recoveredInfo.Length;

            // Write a text report with the byte count
            using (StreamWriter writer = new StreamWriter(reportFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine($"Recovered byte count: {recoveredByteCount}");
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
 * 1. When you need to decompress a downloaded .xz video backup and store the raw binary for further processing.
 * 2. When a media pipeline receives compressed video data in XZ format and you must extract it and log the size for validation.
 * 3. When archiving large video files for distribution, you may need to programmatically unpack the XZ archive and record the recovered byte count for audit purposes.
 * 4. When integrating with a legacy system that supplies video streams as a single XZ payload, you can extract the stream and generate a report to confirm integrity.
 * 5. When building a C# utility that monitors storage usage, extracting an XZ‑compressed video and documenting its uncompressed size helps track disk consumption.
 */
