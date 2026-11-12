// HOW-TO: Compress Large CSV File to LZIP Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CSV file and output LZIP archive paths
            string inputPath = @"C:\Data\large_dataset.csv";
            string outputPath = @"C:\Export\large_dataset.lz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create LZIP archive, set source file, and save the compressed archive
            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);
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
 * 1. When you need to reduce the size of a massive CSV dataset before transferring it over a network or storing it in limited‑space storage, you can use this code to create an LZIP archive.
 * 2. When an automated data‑export job must generate a compressed file in a specific export directory for downstream processing pipelines, this snippet handles the compression and folder creation.
 * 3. When you want to ensure a CSV backup is saved in a portable, high‑compression format that can be decompressed with standard LZIP tools, the code provides a simple C# solution.
 * 4. When integrating data archiving into a Windows service that periodically compresses log or analytics CSV files, this example shows how to verify the source file and produce a .lz file safely.
 * 5. When a developer needs to programmatically compress a CSV file without relying on external command‑line utilities, the LzipArchive class lets you perform the operation entirely within .NET.
 */
