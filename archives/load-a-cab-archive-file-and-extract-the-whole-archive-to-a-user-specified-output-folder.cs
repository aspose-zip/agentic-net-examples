// HOW-TO: Extract All Files From CAB Archive To Folder In C# (Aspose.ZIP for .NET)
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
            string outputPath = @"C:\Data\Extracted";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Ensure the output directory itself exists
            Directory.CreateDirectory(outputPath);

            // Open the CAB archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            using (CabArchive archive = new CabArchive(fs))
            {
                // Extract all entries to the output directory
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
 * 1. When you need to unpack a Windows CAB installer to access its individual components in a .NET application.
 * 2. When a deployment script must programmatically extract driver packages stored in a CAB file to a target directory.
 * 3. When migrating legacy software assets and you have to bulk‑extract files from CAB archives for analysis or backup.
 * 4. When building a custom installer that reads configuration files from a CAB and writes them to a user‑specified output folder.
 * 5. When automating the extraction of compressed resources such as fonts or images packaged in a CAB archive during a CI/CD pipeline.
 */
