// HOW-TO: Extract All Files from a CAB Archive to a Directory in C# (Aspose.ZIP for .NET)
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
            string outputPath = @"C:\Data\CabExportDirectory";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
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
 * 1. When you need to unpack driver installation packages (.cab) on a Windows server using C#.
 * 2. When a deployment script must extract resources from a CAB file into a temporary folder before processing them.
 * 3. When an application reads a CAB archive received from a third‑party vendor and stores its contents for further analysis.
 * 4. When you automate the migration of legacy CAB‑packed assets to a new file system structure in a .NET service.
 * 5. When a build pipeline extracts bundled documentation or binaries from a CAB archive to include them in a release package.
 */
