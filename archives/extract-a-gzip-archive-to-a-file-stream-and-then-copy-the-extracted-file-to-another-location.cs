// HOW-TO: Extract GZIP Archive to File Stream and Copy File in C# (Aspose.ZIP for .NET)
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
            string inputPath = "sample.gz";
            string extractedPath = "extracted.txt";
            string copyPath = "copy.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(extractedPath));
            Directory.CreateDirectory(Path.GetDirectoryName(copyPath));

            // Open the GZIP archive and extract its content to a file
            using (GzipArchive archive = new GzipArchive(inputPath))
            {
                using (FileStream extractedStream = File.Create(extractedPath))
                {
                    using (Stream unpacked = archive.Open())
                    {
                        byte[] buffer = new byte[81920];
                        int bytesRead;
                        while ((bytesRead = unpacked.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            extractedStream.Write(buffer, 0, bytesRead);
                        }
                    }
                }
            }

            // Copy the extracted file to another location
            using (FileStream sourceStream = File.OpenRead(extractedPath))
            {
                using (FileStream destinationStream = File.Create(copyPath))
                {
                    byte[] buffer = new byte[81920];
                    int bytesRead;
                    while ((bytesRead = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        destinationStream.Write(buffer, 0, bytesRead);
                    }
                }
            }

            Console.WriteLine("Extraction and copy completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to decompress a .gz log file on a server and then move the resulting text file to a processing directory.
 * 2. When an application must read a compressed configuration file, extract its contents to a temporary location, and then duplicate it for backup purposes.
 * 3. When a batch job processes incoming GZIP data streams, extracts the payload to a file, and copies it to another folder for further analysis.
 * 4. When you want to programmatically unpack a downloaded GZIP archive and create a second copy for archival storage without loading the entire file into memory.
 * 5. When a .NET service extracts a compressed report, writes it to disk, and then copies the report to a shared network location for user access.
 */
