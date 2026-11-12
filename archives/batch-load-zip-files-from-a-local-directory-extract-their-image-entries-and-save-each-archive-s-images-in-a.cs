// HOW-TO: Batch extract images from multiple ZIP files to separate folders in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing ZIP files
            string inputDirectory = @"C:\InputZips";
            // Hardcoded base output directory for extracted images
            string outputBaseDirectory = @"C:\ExtractedImages";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure base output directory exists
            Directory.CreateDirectory(outputBaseDirectory);

            // Get all ZIP files in the input directory
            string[] zipFiles = Directory.GetFiles(inputDirectory, "*.zip");

            foreach (string zipFilePath in zipFiles)
            {
                // Verify each ZIP file exists (redundant but follows rule)
                if (!File.Exists(zipFilePath))
                {
                    Console.Error.WriteLine($"File not found: {zipFilePath}");
                    continue;
                }

                // Create a subdirectory for this archive's images
                string archiveName = Path.GetFileNameWithoutExtension(zipFilePath);
                string archiveOutputDir = Path.Combine(outputBaseDirectory, archiveName);
                Directory.CreateDirectory(archiveOutputDir);

                // Open the ZIP archive
                using (FileStream zipStream = File.Open(zipFilePath, FileMode.Open, FileAccess.Read))
                using (Archive archive = new Archive(zipStream))
                {
                    // Iterate over entries that are image files
                    foreach (ArchiveEntry entry in archive.Entries.Where(e =>
                        e.Name.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        e.Name.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        e.Name.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        e.Name.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                        e.Name.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase)))
                    {
                        // Destination file path for the extracted image
                        string destinationPath = Path.Combine(archiveOutputDir, entry.Name);

                        // Ensure the directory for the destination file exists
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                        // Extract the image entry to the destination path
                        entry.Extract(destinationPath);
                        Console.WriteLine($"Extracted {entry.Name} from {archiveName} to {destinationPath}");
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
 * 1. When you need to process a large collection of ZIP archives containing product photos and automatically save each archive’s images into its own folder for further cataloging.
 * 2. When a web service receives uploaded ZIP packages of user‑generated graphics and you must extract only PNG or JPG files to distinct output directories for downstream processing.
 * 3. When migrating legacy data, you can batch‑read ZIP files from a source folder, pull out all image entries, and organize them by archive name for easy review.
 * 4. When building an automated reporting tool that gathers screenshots stored in ZIP bundles, this code extracts the images and places them in separate folders ready for PDF generation.
 * 5. When creating a backup validation script that checks image assets inside multiple ZIP backups, the routine extracts each archive’s pictures into dedicated folders to compare against the original files.
 */
