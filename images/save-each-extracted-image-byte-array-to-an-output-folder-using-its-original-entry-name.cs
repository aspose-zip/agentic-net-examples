// HOW-TO: Extract Images from ZIP and Save with Original Names in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file and output folder paths
            string inputPath = "input.zip";
            string outputFolder = "output_images";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputFolder);

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                // Iterate through all entries in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Process only files with common image extensions
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                    if (extension == ".png" ||
                        extension == ".jpg" ||
                        extension == ".jpeg" ||
                        extension == ".gif" ||
                        extension == ".bmp")
                    {
                        // Extract entry content to a memory stream
                        using (MemoryStream memory = new MemoryStream())
                        {
                            entry.Extract(memory);
                            byte[] imageBytes = memory.ToArray();

                            // Build full output path preserving entry name (including subfolders if any)
                            string outputPath = Path.Combine(outputFolder, entry.Name);
                            string outputDir = Path.GetDirectoryName(outputPath);
                            if (!string.IsNullOrEmpty(outputDir))
                            {
                                Directory.CreateDirectory(outputDir);
                            }

                            // Write the image bytes to the output file
                            File.WriteAllBytes(outputPath, imageBytes);
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
 * 1. When you need to unpack a zip archive containing product photos and store them in a directory hierarchy that matches the archive’s folder structure.
 * 2. When a web service receives a zip file of user‑uploaded screenshots and must extract each image to a server folder while preserving the original filenames.
 * 3. When migrating legacy data, you can extract embedded image assets from backup zip files and write them to the new file system without renaming them.
 * 4. When building a batch processing tool that reads a zip of marketing graphics and saves each file to a designated output folder for further editing.
 * 5. When creating an automated script that validates image contents of a zip and writes them to disk, keeping subfolder paths intact for later reference.
 */
