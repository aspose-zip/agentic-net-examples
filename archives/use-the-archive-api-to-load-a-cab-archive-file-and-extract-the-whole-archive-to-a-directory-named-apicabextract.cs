// HOW-TO: Extract All Files From a CAB Archive to a Folder in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.cab";

            // Hardcoded output directory path
            string outputPath = "ApiCabExtract";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the CAB archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                // Load the CAB archive
                using (CabArchive archive = new CabArchive(fs))
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
 * 1. When you need to unpack driver installation packages (CAB files) on a Windows system using C#.
 * 2. When a deployment tool must programmatically extract all resources from a CAB archive to a temporary directory before processing.
 * 3. When automating the migration of legacy CAB-compressed assets to a new file structure in a .NET application.
 * 4. When building a backup restoration script that reads a CAB backup file and restores its contents to a specified folder.
 * 5. When creating a CI/CD pipeline step that validates the contents of a CAB archive by extracting it to a workspace for further analysis.
 */
