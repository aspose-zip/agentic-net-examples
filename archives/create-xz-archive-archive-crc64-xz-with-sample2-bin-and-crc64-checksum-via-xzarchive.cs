// HOW-TO: Create XZ Archive With CRC64 Checksum Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample2.bin";
            string outputPath = @"C:\Data\archive_crc64.xz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create XZ archive with CRC64 checksum (handled internally by XzArchive)
            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("XZ archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a binary file into an XZ archive with built‑in CRC64 integrity verification for reliable storage or transfer.
 * 2. When you want to generate an XZ file programmatically in a .NET application without manually handling checksum calculation.
 * 3. When you are preparing data backups that require the high compression ratio of XZ and the error‑detecting capabilities of CRC64.
 * 4. When you need to integrate XZ compression into a build pipeline that processes large binary assets on Windows.
 * 5. When you must ensure that a downloaded or transmitted binary can be validated automatically by the archive’s CRC64 before extraction.
 */
