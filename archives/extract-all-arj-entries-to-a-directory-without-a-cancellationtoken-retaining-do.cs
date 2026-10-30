// HOW-TO: Extract All ARJ Archive Entries To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.arj";
            string outputPath = "ExtractedFiles";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory and its parent exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            // Open ARJ archive and extract all entries preserving directory structure
            using (ArjArchive archive = new ArjArchive(inputPath))
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
 * 1. When you need to unpack legacy ARJ backup files onto a server for further processing in a .NET application.
 * 2. When a desktop utility must automatically extract downloaded ARJ packages into a specific folder without user interaction.
 * 3. When migrating old software assets stored in ARJ archives to a new file system while preserving the original folder hierarchy.
 * 4. When a batch job processes multiple ARJ archives and writes their contents to a common output directory for indexing.
 * 5. When troubleshooting a corrupted ARJ archive by extracting its entries to a temporary location for inspection.
 */
