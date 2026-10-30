// HOW-TO: Extract Single File From LZIP Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string inputPath = "sample.lz";
            string outputPath = "extracted.txt";

            // Verify input file exists
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

            // Open LZIP archive and extract its single entry
            using (LzipArchive archive = new LzipArchive(inputPath))
            {
                using (FileStream extracted = File.Create(outputPath))
                {
                    archive.Extract(extracted);
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a .lz compressed log file from a Linux system and need to programmatically extract its contents in a C# application.
 * 2. When a data pipeline stores intermediate results as a single‑file LZIP archive and you must unpack it on a Windows server using Aspose.Zip.
 * 3. When an automated deployment script includes configuration files packaged in LZIP format and you want to extract them safely within a .NET service.
 * 4. When a desktop utility processes user‑uploaded LZIP archives and you need to read the sole payload without manually handling streams.
 * 5. When a backup solution creates LZIP archives for single documents and you require a reliable C# method to restore the original file.
 */
