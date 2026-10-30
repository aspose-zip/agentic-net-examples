// HOW-TO: Extract All Files From CAB Archive To Directory In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input.cab";
            string outputPath = "OutputCab\\";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the CAB archive and extract all entries
            using (CabArchive archive = new CabArchive(inputPath))
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
 * 1. When you need to unpack a Windows driver CAB package during an automated installation script.
 * 2. When a deployment tool must extract bundled resources from a CAB file to a temporary folder before processing them.
 * 3. When a backup utility restores files stored in a CAB archive to their original directory structure on a server.
 * 4. When a software updater reads a CAB update bundle and extracts its contents to apply patches programmatically.
 * 5. When a migration script moves data from legacy CAB-compressed archives into a new file system hierarchy for analysis.
 */
