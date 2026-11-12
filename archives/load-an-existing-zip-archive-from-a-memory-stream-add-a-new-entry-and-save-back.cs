// HOW-TO: Add a File to an Existing Zip Archive from Memory in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path, file to add, and output ZIP path
            string inputZipPath = "input/input.zip";
            string fileToAddPath = "input/newfile.txt";
            string outputZipPath = "output/output.zip";

            // Validate input files exist
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            if (!File.Exists(fileToAddPath))
            {
                Console.Error.WriteLine($"File not found: {fileToAddPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Load the existing ZIP archive into a memory stream
            byte[] zipBytes = File.ReadAllBytes(inputZipPath);
            using (MemoryStream zipStream = new MemoryStream(zipBytes))
            {
                // Open the archive from the memory stream
                using (Archive archive = new Archive(zipStream))
                {
                    // Add a new entry to the archive
                    archive.CreateEntry("newfile.txt", fileToAddPath);

                    // Save the modified archive to the output path
                    archive.Save(outputZipPath);
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
 * 1. When you need to programmatically insert a new document into a zip package that is already loaded in memory before sending it over a network.
 * 2. When a web service receives a zip file as a byte array, and you must add a configuration file to it without writing the original archive to disk.
 * 3. When building a backup utility that merges additional log files into an existing compressed archive stored in a memory buffer.
 * 4. When creating a downloadable bundle where you dynamically add user‑generated reports to a pre‑existing zip before saving the final file.
 * 5. When updating a packaged deployment by appending a patch file to an existing zip archive that is being processed in‑memory for performance reasons.
 */
