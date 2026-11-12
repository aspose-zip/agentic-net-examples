// HOW-TO: Extract Images from ZIP and Save with Original Extensions in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\sample.zip";
            // Hardcoded output directory for extracted images
            string outputDir = @"C:\Data\ExtractedImages";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Open the ZIP archive for reading
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream))
            {
                int imageIndex = 1;

                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Skip directories
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Determine the file extension of the entry
                    string extension = Path.GetExtension(entry.Name);
                    if (extension == null)
                    {
                        continue;
                    }

                    // Check if the entry is an image based on its extension
                    bool isImage = string.Equals(extension, ".jpg", StringComparison.OrdinalIgnoreCase) ||
                                   string.Equals(extension, ".jpeg", StringComparison.OrdinalIgnoreCase) ||
                                   string.Equals(extension, ".png", StringComparison.OrdinalIgnoreCase) ||
                                   string.Equals(extension, ".gif", StringComparison.OrdinalIgnoreCase) ||
                                   string.Equals(extension, ".bmp", StringComparison.OrdinalIgnoreCase) ||
                                   string.Equals(extension, ".tiff", StringComparison.OrdinalIgnoreCase) ||
                                   string.Equals(extension, ".webp", StringComparison.OrdinalIgnoreCase);

                    if (!isImage)
                    {
                        continue;
                    }

                    // Build the output file name preserving the original extension
                    string outputFileName = $"image{imageIndex}{extension}";
                    string outputPath = Path.Combine(outputDir, outputFileName);

                    // Ensure the output directory exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                    // Extract the entry bytes to the output file
                    using (Stream entryStream = entry.Open())
                    using (FileStream outStream = File.Create(outputPath))
                    {
                        entryStream.CopyTo(outStream);
                    }

                    imageIndex++;
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
 * 1. When you need to pull all JPEG, PNG, GIF, or BMP files out of a ZIP package and store them on disk with simple numbered filenames while preserving their original formats.
 * 2. When a desktop application must batch‑process images bundled in a zip file without converting them, using Aspose.Zip to read the archive and write each image to a designated output folder.
 * 3. When an automated import routine has to validate that a received ZIP contains only supported image types and extract them for further processing in a .NET service.
 * 4. When you want to generate a flat folder of images from a nested archive structure, ignoring directories and naming each file sequentially for easy indexing.
 * 5. When a migration script must unpack archived product photos from legacy zip archives and save them with their native extensions before uploading to a cloud storage solution.
 */
