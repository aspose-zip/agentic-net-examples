// HOW-TO: Create LZ4 Archive with Block Checksum in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.txt";
            string outputPath = "output.lz4";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // Create LZ4 archive and compress the file
            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine($"LZ4 archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a log file while ensuring data integrity by storing block checksums in the LZ4 archive.
 * 2. When integrating fast compression into a .NET application that must verify each compressed block during later extraction.
 * 3. When sending large binary payloads over a network and want the receiver to detect corrupted blocks using LZ4 block checksums.
 * 4. When archiving configuration files for backup and require quick decompression with built‑in checksum verification in C#.
 * 5. When building a custom deployment package that leverages LZ4’s speed and needs block‑level error detection for reliable installs.
 */
