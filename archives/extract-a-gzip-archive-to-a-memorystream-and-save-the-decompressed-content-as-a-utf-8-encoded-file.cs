// HOW-TO: Extract GZIP Archive to MemoryStream and Save as UTF-8 File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.gz";
            string outputPath = "output\\decompressed.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Extract GZIP archive to a memory stream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (GzipArchive gzipArchive = new GzipArchive(File.OpenRead(inputPath)))
                {
                    using (Stream decompressedStream = gzipArchive.Open())
                    {
                        decompressedStream.CopyTo(memoryStream);
                    }
                }

                // Reset stream position before reading
                memoryStream.Position = 0;

                // Write decompressed content to a UTF-8 encoded file
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
                {
                    using (StreamReader reader = new StreamReader(memoryStream, Encoding.UTF8))
                    {
                        string content = reader.ReadToEnd();
                        writer.Write(content);
                    }
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
 * 1. When you receive a .gz log file from a remote server and need to decompress it in memory before writing the text as UTF-8 to a local file.
 * 2. When a web service returns GZIP-compressed JSON payloads and you must extract the content to a MemoryStream for further processing and then store it as a UTF-8 file.
 * 3. When an application archives configuration files with GZIP to reduce size and later needs to read and save the uncompressed data as a UTF-8 text file on disk.
 * 4. When you want to validate the integrity of a GZIP archive by extracting it to memory and comparing the UTF-8 output with expected content.
 * 5. When a batch job processes multiple .gz reports, decompresses each into a MemoryStream, and writes the results as UTF-8 encoded files for downstream analytics.
 */
