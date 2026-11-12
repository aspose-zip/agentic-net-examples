// HOW-TO: Extract Local ZIP File To Folder Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = @"C:\Data\sample.zip";

            // Hardcoded output directory path
            string outputPath = @"C:\Data\Extracted";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the ZIP file stream and extract its contents
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a downloaded ZIP archive on a server to process its individual files.
 * 2. When a desktop application must read a packaged set of resources and place them in a working directory for further manipulation.
 * 3. When an automated build script extracts compiled assets from a ZIP before publishing them to a deployment folder.
 * 4. When a data ingestion pipeline receives compressed data batches and must decompress them to a staging area for analysis.
 * 5. When a backup restoration tool restores files from a ZIP archive to their original locations on a Windows machine.
 */
