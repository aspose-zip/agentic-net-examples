// HOW-TO: Create Gzipped CPIO Archive and Extract It Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputFilePath = "input.txt";
            string cpioGzPath = "archive.cpio.gz";
            string extractedCpioPath = "extracted.cpio";

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(cpioGzPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(extractedCpioPath) ?? ".");

            // Create CPIO archive and save it gzipped
            using (CpioArchive archive = new CpioArchive())
            {
                // Add entry to the archive; entry name inside archive is "file.txt"
                archive.CreateEntry("file.txt", inputFilePath);
                // Save the archive with GZIP compression
                archive.SaveGzipped(cpioGzPath);
            }

            // Decompress the GZIP wrapper to obtain the original CPIO file
            using (GzipArchive gzipArchive = new GzipArchive(cpioGzPath))
            {
                using (FileStream extracted = File.Create(extractedCpioPath))
                {
                    using (Stream unpacked = gzipArchive.Open())
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

            Console.WriteLine("CPIO archive created, gzipped, and decompressed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a file into a CPIO archive, compress it with GZIP for efficient storage or transmission, and later retrieve the original CPIO file in a .NET application.
 * 2. When deploying software to Unix-like systems that require CPIO archives, you can generate the archive, compress it to reduce size, and then decompress it on the target machine using C#.
 * 3. When backing up configuration files and want to store them as a gzipped CPIO container to meet legacy archive standards while still using modern .NET code.
 * 4. When integrating with tools that only accept gzipped CPIO streams, you can create the archive, apply GZIP compression, and later strip the GZIP layer to feed the raw CPIO to those tools.
 * 5. When automating a build pipeline that needs to create a compressed CPIO package for firmware updates and then verify the package by extracting the gzip wrapper before flashing.
 */
