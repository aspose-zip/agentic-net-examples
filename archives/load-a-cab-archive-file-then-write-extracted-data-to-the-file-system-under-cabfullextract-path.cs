// HOW-TO: Extract All Files From a CAB Archive To a Folder In C# (Aspose.ZIP for .NET)
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

            // Hardcoded output directory for extraction
            string outputPath = @"C:\Data\CabFullExtract";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
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
 * 1. When you need to unpack a Windows CAB driver package during an automated installation script.
 * 2. When a backup utility must restore files from a CAB archive to their original directory structure.
 * 3. When a deployment tool extracts bundled resources from a CAB file onto a target machine before configuration.
 * 4. When a software updater reads a CAB update bundle and writes its contents to a temporary folder for validation.
 * 5. When a data migration process pulls files from a CAB archive and saves them to a network share for further processing.
 */
