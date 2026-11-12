// HOW-TO: Extract Single XZ Stream to File and Log Byte Count in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "archive1.xz";
            string extractedPath = "output\\payload.bin";
            string reportPath = "output\\report.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string extractedDir = Path.GetDirectoryName(extractedPath);
            if (!string.IsNullOrEmpty(extractedDir))
            {
                Directory.CreateDirectory(extractedDir);
            }

            using (XzArchive archive = new XzArchive(inputPath))
            {
                using (FileStream extractedStream = File.Create(extractedPath))
                {
                    archive.Extract(extractedStream);
                }
            }

            long byteCount = new FileInfo(extractedPath).Length;

            string reportDir = Path.GetDirectoryName(reportPath);
            if (!string.IsNullOrEmpty(reportDir))
            {
                Directory.CreateDirectory(reportDir);
            }

            using (StreamWriter writer = new StreamWriter(reportPath, false))
            {
                writer.WriteLine($"Extracted byte count: {byteCount}");
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
 * 1. When you need to decompress a .xz file received from a Linux server and store the raw payload on Windows for further processing.
 * 2. When you want to automate extraction of a single XZ stream in a .NET application and keep a record of how many bytes were recovered.
 * 3. When a backup system delivers compressed binary data in XZ format and you must verify the extracted size for integrity checks.
 * 4. When integrating Aspose.Zip XZ support into a C# service that extracts firmware images and generates a simple text report.
 * 5. When creating a batch job that unpacks large XZ archives and logs the extracted byte count for auditing or monitoring purposes.
 */
