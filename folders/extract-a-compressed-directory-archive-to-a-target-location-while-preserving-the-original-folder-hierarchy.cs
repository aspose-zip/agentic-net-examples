// HOW-TO: Extract ZIP Archive to Folder While Preserving Directory Structure in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP archive path
            string inputPath = @"C:\Data\archive.zip";
            // Hardcoded output directory path
            string outputPath = @"C:\Data\Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the ZIP archive for reading
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Load the archive using Aspose.Zip
                using (Archive archive = new Archive(zipStream))
                {
                    // Extract all entries preserving folder hierarchy
                    archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a downloaded ZIP file into a specific directory while keeping its original subfolders intact.
 * 2. When a deployment script must extract packaged resources on a server without flattening the folder hierarchy.
 * 3. When an application processes user‑uploaded ZIP archives and must recreate the exact folder layout on disk.
 * 4. When automating backup restoration that involves extracting a compressed archive to its original structure.
 * 5. When integrating third‑party data bundles that are delivered as ZIP files and require hierarchical extraction for further processing.
 */
