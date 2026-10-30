// HOW-TO: Extract Single File From XZ Archive And Log Byte Count In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "doc_archive.xz";
            string outputPath = "recovered.bin";
            string reportPath = "report.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? string.Empty);

            string reportDir = Path.GetDirectoryName(reportPath);
            Directory.CreateDirectory(reportDir ?? string.Empty);

            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);

                using (MemoryStream memory = new MemoryStream())
                {
                    archive.Extract(memory);
                    byte[] data = memory.ToArray();
                    int byteCount = data.Length;

                    File.WriteAllBytes(outputPath, data);
                    File.WriteAllText(reportPath, $"Recovered byte count: {byteCount}");
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
 * 1. When you receive a compressed .xz file containing a single binary payload and need to programmatically decompress it in a .NET application while tracking the size of the recovered data.
 * 2. When an automated data pipeline must extract a configuration or firmware blob from an XZ archive and store it as a file for later processing.
 * 3. When you want to generate a simple text report that records how many bytes were extracted from an XZ compressed archive for auditing or logging purposes.
 * 4. When a desktop utility built with C# has to ensure the output directory exists before writing the decompressed content from an XZ archive.
 * 5. When integrating Aspose.Zip XZ support into a backup restoration tool that restores a single file from an .xz archive and verifies its integrity by checking the byte count.
 */
