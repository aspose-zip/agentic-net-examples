// HOW-TO: Extract Images From ZIP and Prefix Filenames With Entry Index in C# (Aspose.ZIP for .NET)
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
            string outputDir = "extracted_images";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the ZIP archive for reading
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream))
            {
                // Iterate over entries with index
                for (int i = 0; i < archive.Entries.Count; i++)
                {
                    ArchiveEntry entry = archive.Entries[i];

                    // Skip directories
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Determine if the entry is an image based on extension
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                    bool isImage = extension == ".png" ||
                                   extension == ".jpg" ||
                                   extension == ".jpeg" ||
                                   extension == ".gif" ||
                                   extension == ".bmp";

                    if (!isImage)
                    {
                        continue;
                    }

                    // Build new file name with index prefix
                    string newFileName = $"{i}_{entry.Name}";
                    string destinationPath = Path.Combine(outputDir, newFileName);

                    // Extract the entry to the new file name
                    entry.Extract(destinationPath);
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
 * 1. When you need to batch‑extract photos from a ZIP archive and keep the original order by adding the entry index to each filename.
 * 2. When a reporting tool requires image files to be named sequentially to match metadata stored elsewhere in the archive.
 * 3. When you are building a migration script that moves images from legacy ZIP packages to a new folder structure while preserving their original position.
 * 4. When you want to avoid filename collisions while extracting images from a ZIP that contains duplicate names.
 * 5. When an automated image‑processing pipeline expects the file name to start with an index so it can sort and process the pictures correctly.
 */
