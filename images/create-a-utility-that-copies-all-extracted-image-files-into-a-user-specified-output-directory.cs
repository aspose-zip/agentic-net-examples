// HOW-TO: Extract Only Image Files From ZIP To Specified Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = "C:\\Data\\archive.zip";
            // Hardcoded output directory for extracted images
            string outputDirectory = "C:\\Data\\ExtractedImages";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the ZIP archive for reading
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    // Iterate over all entries in the archive
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Determine the file extension of the entry (case‑insensitive)
                        string extension = Path.GetExtension(entry.Name).ToLowerInvariant();

                        // Process only common image file types
                        if (extension == ".jpg" ||
                            extension == ".jpeg" ||
                            extension == ".png" ||
                            extension == ".gif" ||
                            extension == ".bmp")
                        {
                            // Build the full destination path for the extracted image
                            string destinationPath = Path.Combine(outputDirectory, entry.Name);

                            // Ensure any sub‑directory structure inside the ZIP is created
                            string destinationDir = Path.GetDirectoryName(destinationPath);
                            if (!string.IsNullOrEmpty(destinationDir))
                            {
                                Directory.CreateDirectory(destinationDir);
                            }

                            // Extract the image entry to the destination path
                            entry.Extract(destinationPath);
                            Console.WriteLine($"Extracted: {entry.Name} -> {destinationPath}");
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
 * 1. When you need to pull only photos out of a large ZIP archive and save them to a dedicated directory for further processing.
 * 2. When a web application receives uploaded ZIP packages and must extract JPEG, PNG, GIF, or BMP images to a server folder for thumbnail generation.
 * 3. When automating a migration of legacy image collections stored in compressed archives to a new file system structure.
 * 4. When building a batch job that filters image files from mixed‑type ZIP files and copies them to a user‑chosen output location.
 * 5. When creating a utility that preserves the original folder hierarchy of images inside a ZIP while extracting them for backup or analysis.
 */
