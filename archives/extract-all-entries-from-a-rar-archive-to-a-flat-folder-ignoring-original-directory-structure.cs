// HOW-TO: Extract All Files From RAR To Single Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Archives\sample.rar";
            string outputPath = @"C:\Extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory's parent exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Ensure the output directory itself exists
            Directory.CreateDirectory(outputPath);

            // Open the RAR archive
            using (RarArchive archive = new RarArchive(inputPath))
            {
                // Iterate through all entries
                foreach (RarArchiveEntry entry in archive.Entries)
                {
                    // Skip directories
                    if (entry.IsDirectory)
                        continue;

                    // Get only the file name, ignoring any internal folder structure
                    string fileName = Path.GetFileName(entry.Name);
                    string destinationFile = Path.Combine(outputPath, fileName);

                    // Extract the entry to a file stream
                    using (FileStream fs = new FileStream(destinationFile, FileMode.Create, FileAccess.Write))
                    {
                        entry.Extract(fs);
                    }
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
 * 1. When you need to unpack a downloaded RAR package and place every file directly into one directory for batch processing.
 * 2. When a legacy system stores logs in a RAR archive with subfolders but your analysis tool expects all log files in a single folder.
 * 3. When you want to migrate assets from a compressed RAR backup into a flat folder structure for a content management system that does not support nested directories.
 * 4. When automating a build pipeline that extracts third‑party libraries from a RAR archive and copies them to a common lib folder without preserving internal paths.
 * 5. When creating a simple command‑line utility that flattens a RAR archive so users can easily browse or copy the extracted files without navigating subfolders.
 */
