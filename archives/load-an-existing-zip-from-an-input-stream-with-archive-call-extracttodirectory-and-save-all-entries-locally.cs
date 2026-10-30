// HOW-TO: Extract All Files From a ZIP Stream to a Directory in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.zip";
            // Hardcoded output directory path where entries will be extracted
            string outputPath = "extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create the parent directory of the output path (as required)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            // Ensure the output directory itself exists
            Directory.CreateDirectory(outputPath);

            // Open the input ZIP file as a stream and load it into an Archive
            using (FileStream inputStream = new FileStream(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(inputStream))
                {
                    // Extract all entries to the specified directory
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
 * 1. When you need to programmatically unpack a user‑uploaded ZIP file received as a stream and save its contents to a server folder.
 * 2. When a desktop application must extract all files from a downloaded archive without knowing the file names in advance.
 * 3. When a background service processes backup archives stored in cloud storage by reading them as streams and restoring their contents locally.
 * 4. When you want to validate that a ZIP file exists and then extract its entire directory structure to a specific output path using Aspose.Zip.
 * 5. When an automated deployment script extracts packaged resources from a ZIP stream to prepare them for installation on a Windows machine.
 */
