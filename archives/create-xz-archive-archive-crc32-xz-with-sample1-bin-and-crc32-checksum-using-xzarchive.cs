// HOW-TO: Create XZ Archive With CRC32 Checksum In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\sample1.bin";
            string outputPath = @"C:\Data\archive_crc32.xz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create an XZ archive, set the source file, and save the archive
            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to compress a binary file for efficient storage or transfer while ensuring data integrity with a built‑in CRC32 check, you can generate an XZ archive using Aspose.Zip in C#.
 * 2. When deploying software updates that include large payloads, you can package each payload into an XZ file with CRC32 verification to guarantee the files are not corrupted during download.
 * 3. When creating automated backups of configuration or log files on Windows servers, you can use this code to archive them into a compact XZ format that includes a checksum for later validation.
 * 4. When sending scientific data sets or sensor recordings to a remote analysis service, you can compress the raw .bin files into an XZ archive with CRC32 to reduce bandwidth usage and detect transmission errors.
 * 5. When integrating file compression into a .NET application that must comply with standards requiring CRC32 validation, you can employ the XzArchive class to produce compliant XZ archives on the fly.
 */
