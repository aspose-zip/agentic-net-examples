// HOW-TO: Create ZIP Archive From Folder Using FileStream In C# (Aspose.ZIP for .NET)
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
            string inputFolderPath = @"C:\Data\SourceFolder";
            string outputZipPath = @"C:\Data\Archive\output.zip";

            // Verify that the input folder exists
            if (!Directory.Exists(inputFolderPath))
            {
                Console.Error.WriteLine($"Folder not found: {inputFolderPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputZipPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open a FileStream for the ZIP archive with FileMode.Create
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                // Create a new ZIP archive
                using (Archive archive = new Archive())
                {
                    // Add all entries from the source folder
                    DirectoryInfo sourceDir = new DirectoryInfo(inputFolderPath);
                    archive.CreateEntries(sourceDir);

                    // Save the archive to the opened stream
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
 * 1. When you need to package an entire directory into a ZIP file for backup or distribution directly from a .NET application.
 * 2. When automating deployment scripts that must generate a compressed archive of build output before uploading to a server.
 * 3. When creating downloadable bundles of user‑generated content in a desktop app without loading files into memory.
 * 4. When implementing a scheduled task that archives log files nightly by writing the ZIP to a specific path.
 * 5. When integrating with third‑party services that require a ZIP payload, and you must stream the archive to avoid temporary files.
 */
