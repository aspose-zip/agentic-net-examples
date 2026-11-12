// HOW-TO: Extract ZIP Archive to Directory and Release Resources in C# (Aspose.ZIP for .NET)
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
            string inputPath = "C:\\Data\\archive.zip";
            // Hardcoded output directory path
            string outputPath = "C:\\Data\\Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the ZIP archive for reading
            using (FileStream zipFile = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Load the archive
                using (Archive archive = new Archive(zipFile))
                {
                    // Extract all entries to the output directory
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
 * 1. When you need to unpack a downloaded .zip package into a local folder before processing its contents.
 * 2. When a desktop application must read a compressed data bundle and extract all files to a working directory while ensuring the file handle is properly closed.
 * 3. When a server‑side service receives a ZIP upload and must extract it to a temporary location for further analysis without leaking resources.
 * 4. When automating deployment scripts that pull a ZIP archive of assets and need to expand them into the target directory safely.
 * 5. When migrating legacy data stored in ZIP archives and you require a simple C# routine to extract the files and free the archive stream.
 */
