// HOW-TO: Extract File From GZIP Archive To Local Path In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputGzipPath = @"C:\Data\sample.gz";
            string extractOutputPath = @"C:\Data\extracted\file.txt";

            if (!File.Exists(inputGzipPath))
            {
                Console.Error.WriteLine($"File not found: {inputGzipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(extractOutputPath));

            using (GzipArchive gzipArchive = new GzipArchive(inputGzipPath))
            {
                using (Stream decompressed = gzipArchive.Open())
                {
                    using (FileStream outputFile = File.Create(extractOutputPath))
                    {
                        byte[] buffer = new byte[8192];
                        int bytesRead;
                        while ((bytesRead = decompressed.Read(buffer, 0, buffer.Length)) > 0)
                        {
                            outputFile.Write(buffer, 0, bytesRead);
                        }
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
 * 1. When you receive a .gz compressed log file from a Linux server and need to programmatically extract its contents to a Windows directory using C#.
 * 2. When an automated build pipeline generates a tar.gz package of deployment assets and you must unpack a specific configuration file before deployment.
 * 3. When a desktop application allows users to import data from a GZIP-compressed backup and you need to decompress it to a temporary file for further processing.
 * 4. When migrating legacy archives stored as .gz files to a new system and you require a .NET solution to extract each archive’s payload without external tools.
 * 5. When creating a utility that validates the integrity of downloaded GZIP files by extracting them and comparing the resulting file against expected content.
 */
