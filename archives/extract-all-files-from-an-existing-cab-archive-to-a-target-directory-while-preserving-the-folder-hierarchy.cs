// HOW-TO: Extract All Files From CAB Archive Preserving Folder Structure In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CAB archive path
            string inputPath = @"C:\Archives\sample.cab";
            // Hardcoded output directory path
            string outputPath = @"C:\Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the CAB archive and extract all entries preserving hierarchy
            using (CabArchive archive = new CabArchive(inputPath))
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
 * 1. When you need to unpack a Windows installer CAB file to a deployment folder while keeping its original directory layout using C#.
 * 2. When a build script must programmatically extract resources from a CAB archive into a staging directory before packaging them into an installer.
 * 3. When a migration tool has to read legacy CAB backups and restore their files to the correct subfolders on a new server using .NET.
 * 4. When an automated test suite validates that all files inside a CAB archive can be extracted correctly without losing hierarchy.
 * 5. When a desktop application offers users the ability to browse and extract the contents of a downloaded CAB package into a chosen folder.
 */
