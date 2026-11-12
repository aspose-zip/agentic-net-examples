// HOW-TO: Create ZIP Archive From Folder And Subfolders Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string outputZipPath = @"C:\Data\Archive.zip";

            // Verify that the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create a new ZIP archive and add all entries from the input directory
            using (Archive archive = new Archive())
            {
                DirectoryInfo sourceInfo = new DirectoryInfo(inputDirectory);
                archive.CreateEntries(sourceInfo);

                // Save the archive to the specified ZIP file
                using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
                {
                    archive.Save(zipStream);
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
 * 1. When you need to package a project's output files and nested directories into a single ZIP file for distribution or backup using C#.
 * 2. When an automated build script must compress logs and generated reports from multiple subfolders into a ZIP archive before uploading to a server.
 * 3. When a desktop application has to create a downloadable archive of user‑selected files and folders without relying on external tools.
 * 4. When you want to implement a scheduled task that archives old data folders into ZIP files to free up disk space.
 * 5. When integrating Aspose.Zip into a .NET service to generate compressed archives for email attachments containing multiple folder structures.
 */
