// HOW-TO: Extract All Files From ZIP to Folder Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
                // Load the archive from the stream
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
 * 1. When you need to unpack a downloaded ZIP package on a server to process its contents in a .NET application.
 * 2. When an automated build script must extract generated artifact archives into a staging directory before deployment.
 * 3. When a desktop utility reads user‑selected ZIP files and extracts them to a chosen folder for further editing.
 * 4. When a background service monitors a folder, detects new ZIP files, and extracts them to a processing directory using Aspose.Zip.
 * 5. When migrating legacy data stored in compressed archives and you require a reliable C# method to decompress all entries to a target location.
 */
