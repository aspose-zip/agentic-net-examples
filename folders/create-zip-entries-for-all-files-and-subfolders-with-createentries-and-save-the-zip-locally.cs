// HOW-TO: Create ZIP Archive of Directory With Subfolders Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string inputDirectory = "C:\\Temp\\Data";

            // Hardcoded output ZIP file path
            string outputZipPath = "C:\\Temp\\DataArchive.zip";

            // Validate input directory existence
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create a file stream for the output ZIP file
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            // Create an Aspose.Zip Archive instance
            using (Archive archive = new Archive())
            {
                // Create entries for all files and subfolders in the input directory
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
                archive.CreateEntries(dirInfo);

                // Save the archive to the ZIP file
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
 * 1. When you need to back up a project's entire folder structure into a single ZIP file for easy storage or transfer.
 * 2. When you want to package configuration files and resources from multiple subdirectories into a deployable archive for a .NET application.
 * 3. When you must generate a compressed archive of user‑uploaded files on a server before sending them via email or API.
 * 4. When you are creating nightly backups of log files spread across several subfolders and need a quick C# solution.
 * 5. When you need to prepare a ZIP bundle of source code and assets for distribution to clients or collaborators without manual zipping.
 */
