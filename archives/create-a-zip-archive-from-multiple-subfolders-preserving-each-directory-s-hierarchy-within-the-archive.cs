// HOW-TO: Create ZIP Archive From Multiple Subfolders Preserving Directory Structure In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input root directory containing the subfolders to compress
            string inputRootPath = @"C:\Data\SourceRoot";

            // Hardcoded output ZIP file path
            string outputZipPath = @"C:\Data\Archive\output.zip";

            // Validate input directory exists
            if (!Directory.Exists(inputRootPath))
            {
                Console.Error.WriteLine($"Directory not found: {inputRootPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Open a file stream for the output ZIP archive
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                // Create a new ZIP archive
                using (Archive archive = new Archive())
                {
                    // Add all entries from the input root directory, preserving hierarchy
                    DirectoryInfo rootDirectory = new DirectoryInfo(inputRootPath);
                    archive.CreateEntries(rootDirectory);

                    // Save the archive to the file stream
                    archive.Save(zipStream);
                }
            }

            Console.WriteLine("Archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to back up several related project folders into a single ZIP file while keeping their original folder hierarchy intact.
 * 2. When you want to package a set of resource directories for distribution to clients or partners without flattening the directory structure.
 * 3. When automating deployment scripts that must compress configuration and data subfolders into a ZIP archive for later extraction on a server.
 * 4. When creating an archive of log files organized by date subfolders to preserve chronological organization for compliance audits.
 * 5. When generating a downloadable archive of user‑generated content stored in multiple subfolders, ensuring the folder layout is retained for easy restoration.
 */
