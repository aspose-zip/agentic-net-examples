// HOW-TO: Compress and Extract LZIP Archive in C# Using Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string inputFilePath = "input.txt";
            string archivePath = "output/archive.lz";
            string extractDir = "extracted";
            string extractedFilePath = Path.Combine(extractDir, Path.GetFileName(inputFilePath));

            // Validate input file
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory for the archive exists
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            // Compress the input file into an LZIP archive
            using (LzipArchive compressArchive = new LzipArchive())
            {
                compressArchive.SetSource(inputFilePath);
                compressArchive.Save(archivePath);
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Decompress the LZIP archive to the output file
            using (LzipArchive decompressArchive = new LzipArchive(archivePath))
            {
                decompressArchive.Extract(extractedFilePath);
            }

            Console.WriteLine("Compression and extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically compress a log file into an LZIP archive before sending it to a remote server in a .NET application.
 * 2. When you want to verify that a newly created LZIP archive can be immediately decompressed and the original file restored within the same C# process.
 * 3. When you are building a backup utility that stores configuration files as LZIP archives and then extracts them for validation or restoration.
 * 4. When you need to integrate LZIP compression and extraction into a CI/CD pipeline to reduce artifact size and ensure integrity using Aspose.Zip for .NET.
 * 5. When you are developing a cross‑platform tool that handles LZIP archives for both archiving and quick extraction of user‑uploaded files in a C# service.
 */
