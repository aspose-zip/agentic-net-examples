// HOW-TO: Extract GZIP Archive Entry to Memory Stream and Save to File in C# (Aspose.ZIP for .NET)
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
            string inputPath = "data\\sample.gz";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputPath = "output\\extracted.bin";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Extract archive entry to memory stream
            using (MemoryStream ms = new MemoryStream())
            {
                using (GzipArchive archive = new GzipArchive(File.OpenRead(inputPath)))
                {
                    using (Stream entryStream = archive.Open())
                    {
                        entryStream.CopyTo(ms);
                    }
                    Console.WriteLine($"Archive name: {archive.Name}");
                }

                // Write memory stream content to file
                ms.Position = 0;
                using (FileStream outStream = File.Create(outputPath))
                {
                    ms.CopyTo(outStream);
                }
            }

            Console.WriteLine($"Extracted content saved to {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to read a compressed .gz file into memory for further processing before persisting the uncompressed data to disk.
 * 2. When a web service returns a GZIP payload and you must extract the content into a stream for validation and then store it as a binary file.
 * 3. When you want to programmatically unpack a nested archive in a build pipeline, loading it into a MemoryStream to avoid locking the source file while writing the result.
 * 4. When you are developing a backup utility that reads compressed logs, extracts them in memory, and writes the raw logs to a designated output folder.
 * 5. When you need to verify the integrity of a GZIP archive by extracting its entry to a stream and comparing the resulting file against an expected checksum.
 */
