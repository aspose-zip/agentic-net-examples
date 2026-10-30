// HOW-TO: Create ZIP Archive from Multiple Folders and Save to Output Directory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directories
            string inputDir1 = @"C:\Data\Folder1";
            string inputDir2 = @"C:\Data\Folder2";

            // Verify input directories exist
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

            // Hardcoded output zip file path
            string outputPath = @"C:\Output\archive.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new ZIP archive and add entries from both directories
            using (Archive archive = new Archive())
            {
                // Add all files from the first directory
                archive.CreateEntries(new DirectoryInfo(inputDir1));

                // Add all files from the second directory
                archive.CreateEntries(new DirectoryInfo(inputDir2));

                // Save the archive to the output path
                archive.Save(outputPath, new ArchiveSaveOptions());
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
 * 1. When you need to bundle configuration files from several project folders into a single ZIP for deployment, this code creates the archive and stores it in a target folder.
 * 2. When you want to back up logs and reports located in different directories nightly, the example shows how to compress them together into one ZIP file using Aspose.Zip.
 * 3. When preparing a downloadable package that combines user data and documentation stored in separate folders, this snippet generates the combined ZIP ready for distribution.
 * 4. When automating a build process that must archive compiled binaries and resource files from distinct output paths, the code demonstrates adding both sets of files to one archive.
 * 5. When a desktop application needs to export selected files from multiple user‑chosen locations into a single compressed file for email attachment, this example provides the necessary steps in C#.
 */
