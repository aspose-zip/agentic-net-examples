// HOW-TO: Extract Lzip Archive To File Stream In C# Using Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "C:\\Data\\sample.lz";
            string outputPath = "C:\\Data\\extracted.txt";

            // Verify that the input Lzip archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the Lzip archive
            using (LzipArchive archive = new LzipArchive(inputPath))
            {
                // Create the output file stream
                using (FileStream extracted = File.Create(outputPath))
                {
                    // Extract the archive contents to the output stream
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
 * 1. When you need to read a compressed .lz file and save its uncompressed data to a local text file in a .NET application.
 * 2. When a batch job processes incoming Lzip logs and extracts them to a directory for further analysis.
 * 3. When a desktop utility must open user‑provided .lz archives and write the extracted content to a temporary stream for preview.
 * 4. When an automated deployment script extracts configuration files packaged as Lzip before copying them to the target server.
 * 5. When a data migration tool reads legacy Lzip backups and writes the raw files to a new storage location.
 */
