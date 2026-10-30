// HOW-TO: Extract All Files From a CAB Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CAB file and output directory
            string inputPath = "sample.cab";
            string outputFolder = "ExtractedFiles";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Open the CAB archive
            using (CabArchive archive = new CabArchive(inputPath))
            {
                // Iterate over each entry in the archive
                foreach (CabEntry entry in archive.Entries)
                {
                    // Build full path for the extracted entry
                    string entryOutputPath = Path.Combine(outputFolder, entry.Name);

                    // Ensure the directory for the entry exists
                    Directory.CreateDirectory(Path.GetDirectoryName(entryOutputPath));

                    // Extract the entry to the specified path
                    entry.Extract(entryOutputPath);
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
 * 1. When you need to unpack driver packages delivered as .cab files so you can inspect or modify individual files before installation.
 * 2. When a deployment script must extract configuration files from a CAB archive to a temporary directory for further processing.
 * 3. When building a migration tool that reads legacy Windows CAB archives and copies their contents to a new location on a server.
 * 4. When automating the extraction of resources bundled in a CAB file as part of a CI/CD pipeline to run tests on each extracted file.
 * 5. When creating a utility that extracts all entries from a CAB archive to a user‑specified folder for backup or analysis purposes.
 */
