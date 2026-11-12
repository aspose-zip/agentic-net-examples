// HOW-TO: Create and Extract Zstandard Compressed CPIO Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;
using Aspose.Zip.Zstandard;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputFilePath = @"C:\Data\input.txt";
            string archivePath = @"C:\Data\archive.cpio.zst";
            string extractDirectory = @"C:\Data\extracted";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));
            Directory.CreateDirectory(extractDirectory);

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Create CPIO archive and add the input file as an entry
            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntry("input.txt", inputFilePath);
                // Save the archive using Zstandard compression
                archive.SaveZstandard(archivePath);
            }

            // Decompress the Zstandard-compressed CPIO archive
            using (ZstandardArchive zstdArchive = new ZstandardArchive(archivePath))
            {
                // Extract the entry to a file in the extraction directory
                string extractedFilePath = Path.Combine(extractDirectory, "input.txt");
                using (FileStream extractedStream = File.Create(extractedFilePath))
                {
                    zstdArchive.Extract(extractedStream);
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
 * 1. When you need to package a configuration file into a CPIO archive and reduce its size with Zstandard before transferring it over a network.
 * 2. When you want to store log files in a compressed CPIO container to save disk space on a Windows server.
 * 3. When a deployment script must create a portable CPIO archive, compress it with Zstandard, and later extract specific files during installation.
 * 4. When integrating legacy Unix CPIO archives into a .NET application that requires fast Zstandard decompression for quick data access.
 * 5. When backing up small text files into a single compressed archive for archival compliance while using Aspose.Zip for .NET.
 */
