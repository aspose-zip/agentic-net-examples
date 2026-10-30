// HOW-TO: Extract Gzip Archive to File Stream Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.gz";
        string outputPath = "output.txt";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        string outputDir = Path.GetDirectoryName(outputPath);
        Directory.CreateDirectory(outputDir ?? ".");

        try
        {
            using (GzipArchive archive = new GzipArchive(inputPath))
            {
                using (FileStream extracted = File.Create(outputPath))
                {
                    using (Stream unpacked = archive.Open())
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = unpacked.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            extracted.Write(buffer, 0, bytesRead);
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
 * 1. When you need to decompress a .gz log file received from a Linux server and save its contents as a plain text file in a .NET application.
 * 2. When your application processes uploaded Gzip backups and must extract them directly to a target directory without loading the entire file into memory.
 * 3. When you want to read a compressed configuration file on the fly and write the uncompressed data to a temporary file for further processing.
 * 4. When integrating a data pipeline that receives Gzip-compressed CSV streams and you must write the decompressed output to disk using Aspose.Zip.
 * 5. When automating the extraction of Gzip archives in a Windows service and need reliable error handling with using blocks to ensure streams are closed.
 */
