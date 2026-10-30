// HOW-TO: Compress a JSON File to GZIP and Save to Temporary Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input JSON file path
            string inputPath = @"C:\Temp\sample.json";
            // Hardcoded output GZIP file path in a temporary directory
            string outputPath = @"C:\Temp\sample.json.gz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Compress the JSON file into a GZIP archive
            using (GzipArchive archive = new GzipArchive())
            {
                // Set the source file to be compressed
                archive.SetSource(inputPath);
                // Save the compressed .gz file
                archive.Save(outputPath);
            }

            Console.WriteLine($"Compressed file saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a large JSON configuration before uploading it to a cloud storage service.
 * 2. When you want to create a GZIP backup of API response data for efficient archival on a Windows server.
 * 3. When you must transmit JSON logs over a network with limited bandwidth by compressing them into a .gz file.
 * 4. When you are building a scheduled job that compresses temporary JSON reports to free disk space.
 * 5. When you need to prepare a JSON payload for a third‑party system that only accepts GZIP‑compressed files.
 */
