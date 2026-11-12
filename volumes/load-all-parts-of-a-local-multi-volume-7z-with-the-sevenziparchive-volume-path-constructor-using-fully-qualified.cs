// HOW-TO: Extract Multi‑Volume 7z Archive Using Fully Qualified Paths In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded full paths to each 7z volume
            string[] volumePaths = new string[]
            {
                @"C:\Archives\sample.7z.001",
                @"C:\Archives\sample.7z.002",
                @"C:\Archives\sample.7z.003"
            };

            // Verify that every volume file exists
            foreach (string volumePath in volumePaths)
            {
                if (!File.Exists(volumePath))
                {
                    Console.Error.WriteLine($"File not found: {volumePath}");
                    return;
                }
            }

            // Output directory for extraction
            string outputPath = @"C:\extracted_7z";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            // Load the multi‑volume 7z archive using the volume‑path constructor
            using (SevenZipArchive archive = new SevenZipArchive(volumePaths))
            {
                // Extract all entries to the specified directory
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you receive a split 7z backup across several .001, .002 files and need to programmatically combine and extract its contents in a .NET application.
 * 2. When automating deployment scripts that must unpack large multi‑volume archives stored on a server using absolute file paths.
 * 3. When building a file‑recovery tool that validates each volume exists before extracting the full archive to a target folder.
 * 4. When creating a batch process that extracts archived logs from a multi‑part 7z package into a central directory for analysis.
 * 5. When integrating Aspose.Zip into a C# service that handles user‑uploaded split archives and extracts them to a predefined extraction directory.
 */
