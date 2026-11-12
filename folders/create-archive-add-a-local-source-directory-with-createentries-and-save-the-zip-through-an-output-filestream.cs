// HOW-TO: Create ZIP Archive From Folder Using Aspose.Zip and FileMode CreateNew in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded source directory and output ZIP file paths
            string sourceDirectoryPath = @"C:\Data\SourceFolder";
            string outputZipPath = @"C:\Data\Archive\output.zip";

            // Validate source directory exists
            if (!Directory.Exists(sourceDirectoryPath))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectoryPath}");
                return;
            }

            // Ensure output directory exists
            string outputDirectory = Path.GetDirectoryName(outputZipPath);
            Directory.CreateDirectory(outputDirectory);

            // Create a FileStream for the output ZIP file with FileMode.CreateNew
            using (FileStream zipFileStream = File.Open(outputZipPath, FileMode.CreateNew))
            {
                // Create a new Archive instance
                using (Archive archive = new Archive())
                {
                    // Create a DirectoryInfo object for the source directory
                    DirectoryInfo sourceDirectoryInfo = new DirectoryInfo(sourceDirectoryPath);

                    // Add all entries from the source directory to the archive
                    archive.CreateEntries(sourceDirectoryInfo);

                    // Save the archive to the output stream
                    archive.Save(zipFileStream);
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
 * 1. When you need to package a project's output files into a new ZIP file without overwriting any existing archives.
 * 2. When you want to back up a local directory to a zip archive on a server using Aspose.Zip in a .NET application.
 * 3. When you must generate a compressed bundle of log files for email attachment, ensuring the zip is created only if it does not already exist.
 * 4. When an automated build script has to archive build artifacts into a zip file using a FileStream with FileMode.CreateNew for safe file creation.
 * 5. When a desktop utility needs to compress user‑selected folders into a zip archive while preserving directory structure via Aspose.Zip’s CreateEntries method.
 */
