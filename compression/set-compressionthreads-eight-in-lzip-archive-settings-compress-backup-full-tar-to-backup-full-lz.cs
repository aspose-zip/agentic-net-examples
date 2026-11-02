// HOW-TO: Compress TAR to LZ with Eight Threads Using Aspose.Zip C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\backup_full.tar";
            string outputPath = @"C:\Data\backup_full.lz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Lzip archive with settings and compress the file
            LzipArchiveSettings settings = new LzipArchiveSettings(6, 8192);
            using (LzipArchive archive = new LzipArchive(settings))
            {
                // Set source file to compress
                archive.SetSource(inputPath);

                // Save compressed archive
                archive.Save(outputPath);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a large TAR backup for faster network transfer by creating an LZIP archive with multiple compression threads in a C# application.
 * 2. When you want to automate nightly backup compression on a Windows server using Aspose.Zip to generate LZ files with optimized multithreaded performance.
 * 3. When you are building a .NET utility that prepares data archives for long‑term storage and requires LZIP format with configurable thread count.
 * 4. When you must ensure the output directory exists before creating a compressed LZ archive from an existing TAR file in a C# script.
 * 5. When you need to handle missing source files gracefully while compressing TAR archives to LZ format in a production‑grade .NET program.
 */
