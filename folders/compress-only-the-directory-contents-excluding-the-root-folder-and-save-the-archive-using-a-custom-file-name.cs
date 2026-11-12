// HOW-TO: Create ZIP of Folder Contents Without Root Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input directory containing files to compress
            string inputDir = @"C:\Data\MyFolder";

            // Output ZIP file with custom name
            string outputPath = @"C:\Output\MyArchive.zip";

            // Verify the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the ZIP archive and add only the contents of the directory (root folder excluded)
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputDir);
                archive.CreateEntries(dirInfo); // adds all files/subfolders relative to inputDir
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
 * 1. When you need to package all files and subfolders from a project directory into a single ZIP file while omitting the top‑level folder name for easier distribution.
 * 2. When an automated build process must generate a compressed archive with a specific filename for downstream deployment scripts.
 * 3. When you want to back up user‑generated content from a known folder but keep the archive structure flat to match legacy import tools.
 * 4. When a web application creates downloadable bundles of selected files and must control the archive name and exclude the source folder path.
 * 5. When a scheduled task compresses log files daily, saving them with a custom name and without the root directory to simplify extraction.
 */
