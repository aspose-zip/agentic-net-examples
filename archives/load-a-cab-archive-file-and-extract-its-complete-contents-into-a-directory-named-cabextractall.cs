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
            string inputPath = "sample.cab";

            // Hardcoded output directory path
            string outputPath = "CabExtractAll";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Ensure the extraction directory exists
            Directory.CreateDirectory(outputPath);

            // Open the CAB archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            using (CabArchive archive = new CabArchive(fs))
            {
                // Extract all entries to the specified directory
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
 * 1. When you need to unpack a Windows installer CAB file to inspect or modify its contents programmatically in a C# application.
 * 2. When automating deployment scripts that must extract driver packages stored as CAB archives before copying files to target machines.
 * 3. When building a backup utility that restores files from a CAB archive into a specific directory on a server.
 * 4. When creating a migration tool that reads legacy CAB-compressed resources and writes them to a new folder structure using .NET.
 * 5. When testing or debugging embedded resources in a CAB file by extracting all entries to a local directory for analysis.
 */
