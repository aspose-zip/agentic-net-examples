// HOW-TO: Create GZIP Archive Using Using Block for Proper Disposal in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "input.txt";
            string outputPath = "output.gz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? Directory.GetCurrentDirectory());

            // Create GZIP archive, set source file, and save the archive
            using (GzipArchive archive = new GzipArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine($"GZIP archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a log file into a .gz archive before uploading it to a remote server.
 * 2. When you want to shrink a large text report so it can be emailed as an attachment without exceeding size limits.
 * 3. When you must generate a GZIP file that is compatible with Unix command‑line tools for downstream processing.
 * 4. When you are building an automated backup routine that stores files in GZIP format to save disk space.
 * 5. When you require deterministic resource cleanup by wrapping the GzipArchive creation in a using statement.
 */
