// HOW-TO: Create and Verify LZ4 Archive from Binary File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.bin";
            string archivePath = "output.lz4";
            string extractDir = "extracted";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory for archive exists
            string archiveDir = Path.GetDirectoryName(archivePath);
            if (!string.IsNullOrEmpty(archiveDir))
            {
                Directory.CreateDirectory(archiveDir);
            }

            // Create LZ4 archive from the binary file
            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(archivePath);
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract all contents to verify data
            using (Lz4Archive archive = new Lz4Archive(archivePath))
            {
                archive.Extract(extractDir);
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
 * 1. When you need to compress large binary logs into a lightweight LZ4 archive before sending them over the network.
 * 2. When you want to package a compiled executable or DLL into an LZ4 file for fast distribution and later integrity checking.
 * 3. When you must store sensor data snapshots in a space‑efficient format and later extract them for analysis in a .NET application.
 * 4. When you are implementing a backup routine that compresses configuration files into LZ4 archives and verifies the backup by extracting the contents.
 * 5. When you are testing the performance of LZ4 compression in C# by creating an archive from a sample file and confirming the data can be correctly decompressed.
 */
