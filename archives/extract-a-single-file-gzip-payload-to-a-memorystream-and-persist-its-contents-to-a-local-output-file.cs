// HOW-TO: Extract GZIP File to MemoryStream and Save as Local File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.gz";
            string outputPath = "extracted.txt";

            // Verify that the input GZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (if any)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Extract the GZIP payload into a memory stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GzipArchive gzipArchive = new GzipArchive(File.OpenRead(inputPath)))
                {
                    using (Stream decompressed = gzipArchive.Open())
                    {
                        decompressed.CopyTo(memoryStream);
                    }
                }

                // Reset the memory stream position before writing to file
                memoryStream.Position = 0;

                // Persist the extracted data to the output file
                using (FileStream fileStream = File.Create(outputPath))
                {
                    memoryStream.CopyTo(fileStream);
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a compressed .gz log file from a remote server and need to decompress it in memory before writing the plain text to a local file.
 * 2. When a .NET application must process a single‑file GZIP payload without extracting the entire archive to disk, using a MemoryStream for temporary storage.
 * 3. When you want to validate the contents of a GZIP archive by loading it into memory first, then persisting the result to a specific output path.
 * 4. When integrating with an API that returns GZIP‑compressed data and you need to decompress the response and save it as a file on the client machine.
 * 5. When automating a data pipeline that extracts compressed configuration files, reads them in memory for further processing, and finally writes the uncompressed version to a designated folder.
 */
