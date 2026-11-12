// HOW-TO: Extract GZIP Archive to Stream and Rename File with Timestamp in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "data/input.gz";
            string outputDirectory = "output";
            string extractedFileName = "extracted.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Full path for the extracted file
            string extractedFilePath = Path.Combine(outputDirectory, extractedFileName);

            // Open the GZIP archive and extract its content
            using (GzipArchive archive = new GzipArchive(inputPath))
            {
                using (Stream unpacked = archive.Open())
                {
                    using (FileStream extracted = File.Create(extractedFilePath))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = unpacked.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            extracted.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }

            // Rename the extracted file based on the current timestamp
            string timestamp = DateTime.Now.ToString("yyyyMMddHHmmss");
            string newFileName = $"extracted_{timestamp}.txt";
            string newFilePath = Path.Combine(outputDirectory, newFileName);
            File.Move(extractedFilePath, newFilePath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to decompress a .gz log file on a server and store it with a unique timestamped name to avoid overwriting previous extracts.
 * 2. When an automated ETL pipeline must read compressed data, extract it to a memory stream, and save the result with a time‑based filename for audit tracking.
 * 3. When a desktop application processes user‑uploaded GZIP reports and renames the extracted text files according to the current date and time for easy organization.
 * 4. When a scheduled job extracts backup files from GZIP archives and appends a timestamp to the filename to maintain version history.
 * 5. When a microservice receives a compressed payload, extracts its content to a file stream, and creates a timestamped file name for downstream processing.
 */
