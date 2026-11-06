// HOW-TO: Create ZIP Archive from Local Folder Using FileStream in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input folder and output zip file paths
            string inputFolder = @"C:\Data\MyFolder";
            string outputZip = @"C:\Data\MyArchive.zip";

            // Verify that the input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZip));

            // Open a FileStream for the output ZIP file
            using (FileStream zipStream = File.Open(outputZip, FileMode.Create))
            {
                // Create a new ZIP archive
                using (Archive archive = new Archive())
                {
                    // Add all entries from the input folder
                    DirectoryInfo dirInfo = new DirectoryInfo(inputFolder);
                    archive.CreateEntries(dirInfo);

                    // Save the archive to the output stream
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
 * 1. When you need to package a directory into a .zip file on the server using C# and Aspose.Zip.
 * 2. When automating backups of application data by creating a ZIP archive from a local folder with a FileStream.
 * 3. When generating downloadable bundles of files for end‑users, you can compress a folder into a ZIP archive in a .NET application.
 * 4. When integrating file compression into a build pipeline, you can create a ZIP archive from a specified directory without loading all files into memory.
 * 5. When you must ensure the output ZIP is written to a specific path and the destination folder is created automatically in C#.
 */
