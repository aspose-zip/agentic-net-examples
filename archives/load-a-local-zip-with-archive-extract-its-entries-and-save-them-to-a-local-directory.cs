// HOW-TO: Extract All Files from a Local ZIP to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = "C:\\Data\\sample.zip";
            // Hardcoded output directory path
            string outputPath = "C:\\Data\\Extracted";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the ZIP file stream
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Load the archive
                using (Archive archive = new Archive(zipStream))
                {
                    // Extract all entries to the output directory
                    archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack a downloaded ZIP package on a server and place its contents into a specific folder for further processing.
 * 2. When an application must automatically extract configuration files bundled in a ZIP archive during installation.
 * 3. When a scheduled job extracts log archives each night to a directory for analysis or archiving.
 * 4. When a desktop utility reads a user‑selected ZIP file and expands all its files to a chosen output directory.
 * 5. When a data migration script pulls data files from a compressed archive and saves them to a target folder before importing them into a database.
 */
