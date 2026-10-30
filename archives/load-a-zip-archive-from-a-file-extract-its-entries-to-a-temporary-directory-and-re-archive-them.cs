// HOW-TO: Extract ZIP to Temporary Folder and Repack into New Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input ZIP file path (hardcoded)
            string inputPath = "input.zip";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Temporary directory for extraction
            string tempDirectory = Path.Combine(Path.GetTempPath(), "ExtractedTemp");
            Directory.CreateDirectory(tempDirectory);

            // Load the ZIP archive and extract all entries to the temporary directory
            using (Archive archive = new Archive(inputPath))
            {
                archive.ExtractToDirectory(tempDirectory);
            }

            // Create a new archive from the extracted files
            using (Archive newArchive = new Archive())
            {
                // Add all files from the temporary directory to the new archive
                newArchive.CreateEntries(tempDirectory);

                // Output ZIP file path (hardcoded)
                string outputPath = "repacked.zip";
                string outputDir = Path.GetDirectoryName(outputPath);
                if (!string.IsNullOrEmpty(outputDir))
                {
                    Directory.CreateDirectory(outputDir);
                }

                // Save the new archive
                newArchive.Save(outputPath);
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
 * 1. When you need to unzip a package, modify its contents in a temporary location, and create a fresh ZIP file for deployment.
 * 2. When an application must validate or reorganize files from an uploaded archive before storing them in a secure archive.
 * 3. When a build pipeline extracts resources from a source ZIP, processes them, and then bundles them back into a new archive for distribution.
 * 4. When you want to programmatically copy the structure of an existing ZIP to another file while ensuring all entries are re‑compressed using default settings.
 * 5. When a service must isolate extracted files in a sandbox folder, then re‑archive them to clean up the temporary directory after processing.
 */
