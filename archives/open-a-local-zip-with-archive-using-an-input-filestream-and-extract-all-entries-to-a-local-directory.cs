// HOW-TO: Extract All Files From a ZIP Using FileStream in C# (Aspose.ZIP for .NET)
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

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ZIP file with a FileStream
            using (FileStream zipFile = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Load the archive from the stream
                using (Archive archive = new Archive(zipFile))
                {
                    // Extract all entries to the output directory
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
 * 1. When you need to programmatically unpack a downloaded ZIP archive on a Windows server without loading the entire file into memory.
 * 2. When you want to extract the contents of a backup ZIP file to a specific folder as part of an automated deployment script.
 * 3. When processing user‑uploaded ZIP packages in a desktop application and you must write the extracted files to a local directory.
 * 4. When migrating legacy data stored in compressed archives and require a reliable C# method to extract them using a FileStream.
 * 5. When building a scheduled task that reads a ZIP from a network share and extracts all entries to a processing directory.
 */
