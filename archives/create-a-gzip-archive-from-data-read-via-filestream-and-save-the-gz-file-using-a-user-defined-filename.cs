// HOW-TO: Create GZIP Archive from FileStream and Save with Custom Name in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file path
            string inputPath = "input.txt";
            // Hardcoded output GZIP file path (user-defined filename)
            string outputPath = "output.gz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create output directory if needed
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the input file stream and compress it into a GZIP archive
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            using (GzipArchive archive = new GzipArchive())
            {
                // Set the source of the archive to the input stream
                archive.SetSource(inputStream);
                // Save the compressed data to the specified .gz file
                archive.Save(outputPath);
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
 * 1. When you need to compress a log file on the server before uploading it to a cloud storage service.
 * 2. When you want to reduce the size of a large text report before emailing it as an attachment.
 * 3. When you must generate a .gz backup of configuration files with a user‑specified filename for automated scripts.
 * 4. When you are building a data pipeline that streams raw CSV data and stores it as a compressed GZIP file for later analysis.
 * 5. When you need to create a portable, compressed archive of user‑generated content to meet bandwidth constraints in a desktop application.
 */
