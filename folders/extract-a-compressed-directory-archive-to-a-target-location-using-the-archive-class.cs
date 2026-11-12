// HOW-TO: Extract a ZIP Archive to a Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
                    // Extract all entries to the target directory
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
 * 1. When you need to programmatically unpack a downloaded ZIP file into a specific directory on a Windows server using C#.
 * 2. When an application must automatically extract bundled resources from a ZIP archive during installation or first‑run setup.
 * 3. When you want to read a ZIP file from a stream and extract all its entries without using the built‑in System.IO.Compression library.
 * 4. When a background service processes incoming ZIP reports and stores the extracted files in a predefined folder for further analysis.
 * 5. When you have to ensure the output directory exists and handle missing archive errors while extracting compressed data in a .NET application.
 */
