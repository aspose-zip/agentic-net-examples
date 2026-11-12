// HOW-TO: Extract All Files From a CAB Archive to a Directory in C# (Aspose.ZIP for .NET)
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
            string outputPath = @"C:\Temp\ExtractedCab";

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
                using (CabArchive archive = new CabArchive(fs))
                {
                    // Extract all entries to the output directory
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
 * 1. When you need to unpack driver installation files packaged in a CAB archive for analysis or deployment.
 * 2. When you want to programmatically extract Windows update components stored in a CAB file to a temporary folder before processing.
 * 3. When you are building a migration tool that reads legacy CAB archives and moves their contents to a new location.
 * 4. When you need to automate the extraction of compressed resources from a CAB file during a build or CI pipeline.
 * 5. When you are creating a utility that validates the integrity of a CAB archive by extracting its entries to a sandbox directory.
 */
