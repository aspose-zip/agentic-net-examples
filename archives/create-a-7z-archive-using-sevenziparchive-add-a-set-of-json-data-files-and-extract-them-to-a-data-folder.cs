// HOW-TO: Create and Extract a 7z Archive of JSON Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Paths (hardcoded)
            string inputFolder = "InputData";
            string archivePath = "ArchiveData.7z";
            string extractFolder = "ExtractedData";

            // Validate input folder
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure output directory for the archive file exists
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath) ?? string.Empty);

            // Create a 7z archive and add all JSON files from the input folder
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                // Add entries from the specified directory (includes all files)
                archive.CreateEntries(inputFolder);
                // Save the archive to the specified path
                archive.Save(archivePath);
            }

            // Ensure the extraction directory exists
            Directory.CreateDirectory(extractFolder);

            // Open the created archive and extract its contents to the extraction folder
            using (SevenZipArchive archive = new SevenZipArchive(archivePath))
            {
                archive.ExtractToDirectory(extractFolder);
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
 * 1. When you need to bundle multiple JSON configuration files into a single 7z archive for easier distribution or backup in a .NET application.
 * 2. When you want to programmatically compress a folder of data files before uploading them to a cloud storage service using C#.
 * 3. When you have to extract archived JSON datasets to a specific directory for processing or analysis in an automated workflow.
 * 4. When you need to ensure that a set of JSON logs are archived and later restored without manual file handling in a Windows service.
 * 5. When you are building a deployment script that packages JSON resources into a 7z file and then unpacks them on the target machine during installation.
 */
