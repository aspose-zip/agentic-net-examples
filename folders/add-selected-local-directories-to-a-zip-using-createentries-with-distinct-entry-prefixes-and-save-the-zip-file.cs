// HOW-TO: Add Multiple Local Folders to a ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directories and output ZIP path
            string inputDir1 = @"C:\Data\Folder1";
            string inputDir2 = @"C:\Data\Folder2";
            string outputZipPath = @"C:\Output\combined.zip";

            // Validate input directories
            if (!Directory.Exists(inputDir1))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir1}");
                return;
            }
            if (!Directory.Exists(inputDir2))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create archive and add directories
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo1 = new DirectoryInfo(inputDir1);
                archive.CreateEntries(dirInfo1);

                DirectoryInfo dirInfo2 = new DirectoryInfo(inputDir2);
                archive.CreateEntries(dirInfo2);

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
 * 1. When you need to bundle several project output folders into a single compressed ZIP file for easy distribution or backup using C#.
 * 2. When an automated build script must archive logs and reports from different directories into one archive before uploading to a server.
 * 3. When a desktop application offers users the option to export selected data folders as a ZIP package for offline access.
 * 4. When you want to programmatically create a ZIP archive that preserves the original folder structure of multiple source directories in a .NET service.
 * 5. When a scheduled task has to combine multiple data sets stored in separate folders into a single compressed file for archival compliance.
 */
