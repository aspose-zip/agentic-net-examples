// HOW-TO: Count Extracted Images From Zip And Write Summary In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputZipPath = "input.zip";

            // Hardcoded output directory for extracted images
            string extractDirectory = "extracted_images";

            // Hardcoded summary text file path
            string summaryFilePath = "summary.txt";

            // Validate input ZIP file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(extractDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(summaryFilePath) ?? ".");

            int imageCount = 0;

            // Open the ZIP archive
            using (Archive archive = new Archive(inputZipPath))
            {
                // Iterate over all entries in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Check if the entry is a file (not a directory) and has an image extension
                    string entryName = entry.Name;
                    if (!entry.IsDirectory && (
                        entryName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase)))
                    {
                        // Extract the image to the output directory
                        string destinationPath = Path.Combine(extractDirectory, entryName);
                        entry.Extract(destinationPath);
                        imageCount++;
                    }
                }
            }

            // Write the count to the summary file
            using (StreamWriter writer = new StreamWriter(summaryFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine($"Extracted images count: {imageCount}");
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
 * 1. When you need to extract all image files from a ZIP archive and keep a record of how many were extracted for reporting or logging purposes.
 * 2. When building a batch processing tool that pulls photos from uploaded zip packages and generates a summary file for downstream workflows.
 * 3. When automating the validation of image assets in a zip before importing them into a content management system, and you must know the total count.
 * 4. When creating a desktop utility that unpacks user‑submitted zip bundles of pictures and writes the number of extracted images to a text file for user feedback.
 * 5. When developing a server‑side service that receives zip files, extracts supported image formats, and stores the extraction count for audit trails.
 */
