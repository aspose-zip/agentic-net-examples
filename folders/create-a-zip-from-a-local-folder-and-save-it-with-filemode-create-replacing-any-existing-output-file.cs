// HOW-TO: Create ZIP from folder and overwrite existing file in C# (Aspose.ZIP for .NET)
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

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputZip);
            Directory.CreateDirectory(outputDir);

            // Create a new ZIP archive and add all entries from the input folder
            using (FileStream zipStream = File.Open(outputZip, FileMode.Create))
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputFolder);
                archive.CreateEntries(dirInfo);
                archive.Save(zipStream);
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
 * 1. When you need to package a project's output directory into a single ZIP archive for backup or distribution, automatically overwriting any existing zip file.
 * 2. When an automated build script must generate a compressed ZIP of log files each night, using FileMode.Create to replace the old archive and conserve disk space.
 * 3. When a desktop application lets users export selected files as a ZIP, ensuring the export overwrites any existing file with the same name.
 * 4. When a scheduled task creates a ZIP of a data folder for remote syncing, recreating the archive from scratch on each run.
 * 5. When a migration utility compresses a source directory before uploading it to cloud storage, using C# and Aspose.Zip to produce a fresh archive each time.
 */
