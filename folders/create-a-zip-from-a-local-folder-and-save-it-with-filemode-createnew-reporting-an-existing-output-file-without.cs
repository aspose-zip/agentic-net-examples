// HOW-TO: Create ZIP From Folder Without Overwriting Existing File In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input folder and output ZIP file paths
            string inputFolder = @"C:\Data\MyFolder";
            string outputZip = @"C:\Data\MyArchive.zip";

            // Verify that the input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Do not overwrite an existing output file
            if (File.Exists(outputZip))
            {
                Console.Error.WriteLine($"Output file already exists: {outputZip}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputZip);
            Directory.CreateDirectory(outputDir);

            // Create a new ZIP archive and add all entries from the input folder
            using (FileStream zipStream = File.Open(outputZip, FileMode.CreateNew))
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputFolder);
                archive.CreateEntries(dirInfo);
                archive.Save(zipStream);
            }

            Console.WriteLine($"Folder compressed successfully to {outputZip}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to back up a project's directory into a ZIP archive in C# while ensuring the existing backup file is not overwritten.
 * 2. When an automated build pipeline must compress output files to a ZIP and should abort if the target archive already exists to avoid data loss.
 * 3. When a desktop utility lets users export a selected folder as a compressed ZIP and must prevent accidental overwriting of the chosen destination file.
 * 4. When a scheduled job creates daily ZIP snapshots of log files and needs to skip creation if the day's archive is already present.
 * 5. When a migration script compresses a source folder before transfer and must verify that the destination ZIP does not already contain previous data.
 */
