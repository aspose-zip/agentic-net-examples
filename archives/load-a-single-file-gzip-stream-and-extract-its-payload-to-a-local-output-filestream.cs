// HOW-TO: Extract Payload from GZIP File to Disk Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string outputPath = "output/payload.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the GZIP archive and extract its payload
            using (GzipArchive archive = new GzipArchive(inputPath))
            {
                using (Stream decompressedStream = archive.Open())
                {
                    using (FileStream outputFile = File.Create(outputPath))
                    {
                        byte[] buffer = new byte[4096];
                        int bytesRead;
                        while ((bytesRead = decompressedStream.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputFile.Write(buffer, 0, bytesRead);
                        }
                    }
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
 * 1. When you receive a .gz log file from a server and need to decompress it to a readable text file in a .NET application.
 * 2. When you want to programmatically extract a single compressed payload from a GZIP archive to store it locally for further processing.
 * 3. When integrating a data pipeline that consumes gzip‑compressed CSV files and must write the uncompressed content to a file system.
 * 4. When building a backup restoration tool that reads a GZIP backup snapshot and saves the original file contents to a specified directory.
 * 5. When automating the extraction of compressed configuration files delivered over HTTP before applying them to an application.
 */
