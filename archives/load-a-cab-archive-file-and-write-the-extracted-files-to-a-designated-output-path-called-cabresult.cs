// HOW-TO: Extract Files From A CAB Archive To A Folder In C# (Aspose.ZIP for .NET)
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
            // Hardcoded output directory for extracted files
            string outputPath = @"C:\Data\CabResult";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the CAB archive and extract its contents
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (CabArchive archive = new CabArchive(fs))
                {
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
 * 1. When you need to unpack a Windows cabinet (.cab) file on a server to access its drivers or resources.
 * 2. When a deployment script must extract installation files from a CAB package to a temporary directory before running setup.
 * 3. When migrating legacy software that distributes updates as CAB archives and you need to programmatically retrieve the contained files.
 * 4. When building a .NET utility that validates the contents of a CAB archive by extracting them to a known location for inspection.
 * 5. When automating the extraction of multiple CAB files in a batch process to a designated output folder for further processing.
 */
