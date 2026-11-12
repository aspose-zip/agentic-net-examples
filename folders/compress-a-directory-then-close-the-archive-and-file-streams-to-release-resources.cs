// HOW-TO: Compress a Local Folder into a ZIP File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output zip file paths
            string inputDirectory = "C:\\Data\\InputFolder";
            string outputZipPath = "C:\\Data\\Output.zip";

            // Verify that the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputZipPath);
            Directory.CreateDirectory(outputDir);

            // Create a file stream for the zip archive and the Archive object
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                // Add all entries from the input directory to the archive
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
 * 1. When you need to back up a project's output folder into a single ZIP archive for easy distribution.
 * 2. When you want to programmatically create a compressed package of log files before uploading them to cloud storage.
 * 3. When an application must generate a downloadable ZIP of user‑uploaded documents on the fly.
 * 4. When you need to archive old reports nightly and ensure all file handles are properly released.
 * 5. When a build pipeline requires bundling compiled binaries into a ZIP file using Aspose.Zip for consistent compression.
 */
