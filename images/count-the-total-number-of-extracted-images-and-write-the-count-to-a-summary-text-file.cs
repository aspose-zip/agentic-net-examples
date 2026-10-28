// HOW-TO: Count Extracted Images from ZIP and Write Summary in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file and output directory
            string inputPath = "input.zip";
            string outputDir = "output";
            string summaryPath = Path.Combine(outputDir, "summary.txt");

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            int imageCount = 0;

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                // Iterate through all entries in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Skip directories
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Check if the entry is an image based on its file extension
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                    if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp")
                    {
                        // Determine the full path for extraction
                        string destinationPath = Path.Combine(outputDir, entry.Name);
                        string destinationDir = Path.GetDirectoryName(destinationPath);

                        // Ensure the destination subdirectory exists (for entries in subfolders)
                        Directory.CreateDirectory(destinationDir);

                        // Extract the image file
                        entry.Extract(destinationPath);
                        imageCount++;
                    }
                }
            }

            // Write the total count of extracted images to the summary file
            File.WriteAllText(summaryPath, imageCount.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract all image files from a ZIP archive and generate a report of how many were extracted for auditing purposes.
 * 2. When processing user‑uploaded zip bundles containing photos, you want to automatically save the images to a folder and log the total count for further processing.
 * 3. When building a migration script that moves images from archived backups to a new directory structure while keeping a simple text summary of the extracted items.
 * 4. When creating a batch job that scans zip packages, extracts PNG, JPG, GIF, BMP files, and records the count to a summary file for monitoring extraction success.
 * 5. When developing a C# utility that validates the contents of a zip by extracting images and writing the image count to a text file for quality‑control checks.
 */
