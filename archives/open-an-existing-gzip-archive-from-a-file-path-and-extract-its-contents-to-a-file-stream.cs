// HOW-TO: Extract Gzip Archive To File Stream In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = "C:\\Data\\";
            string inputFileName = "sample.gz";
            string outputFileName = "extracted.txt";

            string inputPath = dataDir + inputFileName;
            string outputPath = dataDir + outputFileName;

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the GZIP archive and extract its contents
            using (var archive = new GzipArchive(inputPath))
            using (var extracted = File.Create(outputPath))
            {
                Stream unpacked = archive.Open();

                byte[] b = new byte[4096];
                int bytesRead;
                while (0 < (bytesRead = unpacked.Read(b, 0, b.Length)))
                {
                    extracted.Write(b, 0, bytesRead);
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
 * 1. When you need to decompress a .gz log file received from a server and save the plain text to a local directory for analysis.
 * 2. When an application must read a compressed configuration file at runtime and write the uncompressed content to a temporary file for further processing.
 * 3. When a data pipeline receives Gzip‑compressed CSV files and you need to extract them to disk before loading them into a database.
 * 4. When you want to programmatically unpack a Gzip backup archive and store the restored file in a specific folder using C#.
 * 5. When a Windows service processes incoming .gz reports and must extract each report to a file stream for downstream services to consume.
 */
