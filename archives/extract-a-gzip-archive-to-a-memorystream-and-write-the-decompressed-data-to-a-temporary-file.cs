// HOW-TO: Extract Gzip Archive to MemoryStream and Save to Temp File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input GZIP file path
            string inputPath = "sample.gz";

            // Temporary file to store decompressed data
            string tempFilePath = Path.GetTempFileName();

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the directory for the temporary file exists
            Directory.CreateDirectory(Path.GetDirectoryName(tempFilePath));

            // Open the GZIP archive and extract its content to a MemoryStream
            using (GzipArchive archive = new GzipArchive(File.OpenRead(inputPath)))
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (Stream decompressedStream = archive.Open())
                    {
                        decompressedStream.CopyTo(memoryStream);
                    }

                    // Reset the position of the MemoryStream before writing to file
                    memoryStream.Position = 0;

                    // Write the decompressed data from MemoryStream to the temporary file
                    using (FileStream outputFileStream = File.Create(tempFilePath))
                    {
                        memoryStream.CopyTo(outputFileStream);
                    }

                    Console.WriteLine($"Decompressed data written to: {tempFilePath}");
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
 * 1. When you need to decompress a received .gz log file in memory before writing it to a temporary location for further processing.
 * 2. When a web service returns a GZIP‑compressed payload and you must extract it to a MemoryStream to validate its contents before saving it locally.
 * 3. When performing unit tests that require extracting sample data from a GZIP archive without polluting the project directory, using a temporary file for isolation.
 * 4. When integrating with legacy systems that provide compressed configuration files and you need to decompress them on the fly and store them temporarily for parsing.
 * 5. When building a background job that processes large GZIP archives, extracting each file to a MemoryStream first to control memory usage and then writing the result to a temp file for downstream tools.
 */
