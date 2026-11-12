// HOW-TO: Compress Directory Contents to ZIP Without Root Folder Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input directory whose contents will be compressed (root folder excluded)
            string inputDir = @"C:\Data\MyFolder";

            // Output ZIP file path
            string outputPath = @"C:\Data\output.zip";

            // Verify that the input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Create the ZIP archive and add entries from the directory (contents only)
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputDir);
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
 * 1. When you need to package all files from a project’s output folder into a ZIP for distribution while keeping the folder structure flat.
 * 2. When an automated build script must create a backup of a logs directory without nesting the parent folder inside the archive.
 * 3. When a web application generates a downloadable ZIP of user‑uploaded documents but wants the files to appear at the root of the archive.
 * 4. When you are preparing data for a third‑party system that expects a ZIP containing only the files, not the containing directory.
 * 5. When you want to compress the contents of a temporary working directory before cleaning it up, using Aspose.Zip in a C# service.
 */
