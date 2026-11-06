// HOW-TO: Create Zip Archive From Directory Including Subfolders In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing files and subfolders to compress
            string inputDirectory = @"C:\Data\SourceFolder";

            // Hardcoded output ZIP file path
            string outputZipPath = @"C:\Data\Result\archive.zip";

            // Verify that the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create a file stream for the output ZIP archive
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            // Create an Aspose.Zip Archive instance
            using (Archive archive = new Archive())
            {
                // Add all files and subfolders from the input directory to the archive
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
                archive.CreateEntries(dirInfo);

                // Save the archive to the file stream
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
 * 1. When you need to package a project's output files and nested directories into a single ZIP file for distribution or backup.
 * 2. When automating the creation of downloadable archives so users can download multiple files and folders at once.
 * 3. When preparing data for transfer to another system that only accepts compressed ZIP archives.
 * 4. When archiving log files and their subfolders nightly to conserve disk space and simplify retention.
 * 5. When generating a ZIP bundle of configuration files for deployment to remote servers.
 */
