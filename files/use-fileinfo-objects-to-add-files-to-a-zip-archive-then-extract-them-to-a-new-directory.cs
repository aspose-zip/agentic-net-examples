// HOW-TO: Add Files to ZIP Using FileInfo and Extract to Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = "input1.txt";
            string inputPath2 = "input2.txt";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Hardcoded output ZIP file path
            string zipPath = "archive.zip";

            // Ensure output directory exists (if any)
            string zipDir = Path.GetDirectoryName(zipPath);
            if (!string.IsNullOrEmpty(zipDir))
            {
                Directory.CreateDirectory(zipDir);
            }

            // Create FileInfo objects for the input files
            FileInfo fileInfo1 = new FileInfo(inputPath1);
            FileInfo fileInfo2 = new FileInfo(inputPath2);

            // Create ZIP archive and add files using FileInfo
            using (FileStream zipStream = File.Open(zipPath, FileMode.Create))
            {
                using (Archive archive = new Archive())
                {
                    archive.CreateEntry("input1.txt", fileInfo1);
                    archive.CreateEntry("input2.txt", fileInfo2);
                    archive.Save(zipStream, new ArchiveSaveOptions() { Encoding = Encoding.ASCII });
                }
            }

            // Hardcoded extraction directory
            string extractDir = "Extracted";

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Open the created ZIP archive and extract its contents
            using (FileStream zipReadStream = File.Open(zipPath, FileMode.Open))
            {
                using (Archive archive = new Archive(zipReadStream))
                {
                    archive.ExtractToDirectory(extractDir);
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
 * 1. When you need to programmatically bundle specific files into a ZIP archive while preserving their original metadata using FileInfo objects.
 * 2. When you want to create a portable archive of configuration or log files and later extract them to a designated directory for deployment or analysis.
 * 3. When an application must generate a compressed package on the fly and then unpack it on a different machine or user environment.
 * 4. When you are building a backup utility that stores selected files in a ZIP file and restores them to a known folder structure.
 * 5. When you require a simple C# solution to archive multiple documents and automatically extract them for further processing without using third‑party command‑line tools.
 */
