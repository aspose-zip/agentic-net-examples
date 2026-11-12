// HOW-TO: Extract Entire CAB Archive to Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CAB file path
            string inputPath = @"C:\Data\sample.cab";

            // Hardcoded output directory path
            string outputPath = @"C:\Data\CabExtractionFolder";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Ensure the extraction folder exists
            Directory.CreateDirectory(outputPath);

            // Open the CAB archive and extract its contents
            using (FileStream fs = File.OpenRead(inputPath))
            using (CabArchive archive = new CabArchive(fs))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a Windows driver CAB file during automated software installation.
 * 2. When you want to programmatically extract bundled resources from a CAB package for a desktop application.
 * 3. When a build pipeline must decompress a CAB archive containing configuration files before deployment.
 * 4. When you are creating a migration tool that reads legacy CAB backups and writes their contents to a new directory.
 * 5. When you need to validate the contents of a CAB archive by extracting it to a temporary folder for inspection.
 */
