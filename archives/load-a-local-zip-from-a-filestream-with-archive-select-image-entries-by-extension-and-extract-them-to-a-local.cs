// HOW-TO: Extract Only Image Files From a ZIP Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\Data\\sample.zip";
        string outputDirectory = "C:\\Data\\ExtractedImages";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            using (FileStream zipFile = File.Open(inputPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (Archive archive = new Archive(zipFile))
                {
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                        if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" || extension == ".gif" || extension == ".bmp")
                        {
                            string destinationPath = Path.Combine(outputDirectory, entry.Name);
                            string destinationDir = Path.GetDirectoryName(destinationPath);
                            Directory.CreateDirectory(destinationDir);
                            entry.Extract(destinationPath);
                            Console.WriteLine($"Extracted: {entry.Name}");
                        }
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
 * 1. When you need to pull only PNG, JPEG, GIF, or BMP pictures out of a large ZIP archive for processing in a photo‑management application.
 * 2. When a server‑side C# service must read an uploaded ZIP stream and store only the image assets in a specific folder without extracting other file types.
 * 3. When automating migration of legacy product catalogs that are packaged as ZIP files, and you want to isolate and copy the product images to a new directory.
 * 4. When building a desktop utility that scans backup archives and extracts visual assets for quick preview or thumbnail generation.
 * 5. When integrating with a third‑party API that returns ZIP bundles, and you must filter and extract just the image entries to feed into a machine‑learning model.
 */
