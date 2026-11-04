// HOW-TO: Compress a Folder into a ZIP File with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output ZIP file paths
            string inputDirectory = @"C:\Data\MyFolder";
            string outputZipPath = @"C:\Data\MyArchive.zip";

            // Verify that the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Create the output directory if needed
            string outputDir = Path.GetDirectoryName(outputZipPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create the ZIP archive from the directory and save it
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
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
 * 1. When you need to back up a project's output folder into a single ZIP archive before uploading it to a server.
 * 2. When you want to package log files from a specific directory for email attachment or archival storage.
 * 3. When you are creating a downloadable data bundle by compressing a user‑generated folder on the fly in a C# application.
 * 4. When you must generate a compressed deployment package of configuration files to distribute across multiple environments.
 * 5. When you automate the archiving of temporary files after a batch process completes to free disk space.
 */
