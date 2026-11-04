// HOW-TO: Compress a Folder to ZIP File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputDirectory = @"C:\Data\InputFolder";
            string outputZipPath = @"C:\Data\Output.zip";

            // Verify that the input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            string outputDirectory = Path.GetDirectoryName(outputZipPath);
            Directory.CreateDirectory(outputDirectory);

            // Create the ZIP archive and add all entries from the input directory
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
 * 1. When you need to back up a project's source files by zipping an entire directory before uploading to cloud storage.
 * 2. When you want to package log files from a server directory into a single ZIP archive for archival and compliance reporting.
 * 3. When you are preparing a set of configuration files for distribution to client machines and need to compress them into one ZIP bundle.
 * 4. When you automate the creation of deployment packages by compressing a build output folder into a ZIP file for CI/CD pipelines.
 * 5. When you generate downloadable content for end‑users by zipping a media folder on the fly using C# and Aspose.Zip.
 */
