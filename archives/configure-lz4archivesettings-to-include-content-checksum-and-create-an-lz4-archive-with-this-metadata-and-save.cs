// HOW-TO: Create LZ4 Archive with Content Checksum Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\InputFolder";
            string outputPath = @"C:\Data\OutputFolder\compressed.lz4";

            if (!Directory.Exists(inputPath))
            {
                Console.Error.WriteLine($"Directory not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("LZ4 archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a folder into an LZ4 file while preserving a checksum for data integrity verification.
 * 2. When you want to generate a lightweight LZ4 archive in a .NET application for fast transmission over a network.
 * 3. When you must store compressed backup data on disk with metadata that can be validated during extraction.
 * 4. When you are building a C# utility that creates LZ4 archives for large log files and requires a checksum to detect corruption.
 * 5. When you integrate Aspose.Zip into an automated pipeline to archive processed files with built‑in content verification.
 */
