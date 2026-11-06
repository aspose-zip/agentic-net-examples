// HOW-TO: Create ZIP archive from folder and save to file stream in C# (Aspose.ZIP for .NET)
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
            string inputFolder = @"C:\Data\SourceFolder";
            string outputZipPath = @"C:\Data\Output\archive.zip";

            // Verify that the input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputZipPath);
            Directory.CreateDirectory(outputDir);

            // Open a FileStream for the output ZIP file
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                // Create a new ZIP archive
                using (Archive archive = new Archive())
                {
                    // Add all entries from the input folder
                    DirectoryInfo sourceDir = new DirectoryInfo(inputFolder);
                    archive.CreateEntries(sourceDir);

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
 * 1. When you need to package all files in a local directory into a ZIP file for distribution using C#.
 * 2. When automating nightly backups of a folder by compressing its contents into a ZIP archive on a Windows server.
 * 3. When generating a downloadable ZIP of user‑uploaded documents in a web application without loading the entire archive into memory.
 * 4. When creating a ZIP file on the fly to attach to an email from a background Windows service using a FileStream.
 * 5. When archiving log files each day into a compressed ZIP stored in a specific output folder via .NET streams.
 */
