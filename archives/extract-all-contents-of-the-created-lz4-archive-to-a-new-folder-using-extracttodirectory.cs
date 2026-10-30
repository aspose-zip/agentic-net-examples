// HOW-TO: Extract All Files From LZ4 Archive To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input .lz4 archive and output directory paths
            string inputPath = "sample.lz4";
            string outputPath = "Extracted";

            // Verify that the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the LZ4 archive and extract all entries to the output directory
            using (Lz4Archive archive = new Lz4Archive(inputPath))
            {
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
 * 1. When you need to unpack a downloaded .lz4 data package on a server for further processing in a C# application.
 * 2. When you want to automate the extraction of backup archives compressed with LZ4 before restoring files to a new location.
 * 3. When a deployment script must decompress LZ4 bundles containing configuration files into a target directory during installation.
 * 4. When you are building a log aggregation tool that reads compressed .lz4 log archives and extracts them for analysis.
 * 5. When you need to validate the contents of an LZ4 archive by extracting all entries to a temporary folder for testing.
 */
