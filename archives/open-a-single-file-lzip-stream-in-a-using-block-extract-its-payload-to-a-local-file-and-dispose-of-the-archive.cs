// HOW-TO: Extract a Single-File LZIP Archive to Disk in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input and output paths
            string inputPath = @"C:\Data\sample.lz";
            string outputPath = @"C:\Data\output\sample.txt";

            // Validate input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Decompress LZIP archive and extract payload
            using (LzipArchive archive = new LzipArchive(inputPath))
            {
                using (FileStream extracted = File.Create(outputPath))
                {
                    archive.Extract(extracted);
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
 * 1. When you receive a .lzip file from a Linux system and need to programmatically decompress it to a text file in a Windows C# application.
 * 2. When an automated data pipeline stores logs in LZIP format and you must extract each payload to a processing folder using .NET.
 * 3. When a backup utility creates single‑file LZIP archives and your C# service must restore the original files to their original location.
 * 4. When you need to validate that a downloaded LZIP archive exists, create the output directory, and safely extract its contents without leaving open handles.
 * 5. When integrating legacy compression formats into a modern C# project, you need a simple using‑block pattern to open, extract, and dispose of an LZIP archive.
 */
