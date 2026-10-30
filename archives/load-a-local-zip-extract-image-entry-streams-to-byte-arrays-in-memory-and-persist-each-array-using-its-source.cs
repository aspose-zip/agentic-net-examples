// HOW-TO: Extract Images From ZIP To Memory And Save With Original Names In C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.zip";

            // Hardcoded output directory for extracted images
            string outputDir = "ExtractedImages";

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
            {
                using (Archive archive = new Archive(zipStream))
                {
                    // Iterate through all entries in the archive
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Process only file entries with image extensions
                        string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                        if (extension == ".png" ||
                            extension == ".jpg" ||
                            extension == ".jpeg" ||
                            extension == ".gif" ||
                            extension == ".bmp")
                        {
                            // Open the entry stream
                            using (Stream entryStream = entry.Open())
                            {
                                // Read entry data into a memory buffer
                                using (MemoryStream memory = new MemoryStream())
                                {
                                    entryStream.CopyTo(memory);
                                    byte[] imageData = memory.ToArray();

                                    // Determine full output path for the image
                                    string outputPath = Path.Combine(outputDir, entry.Name);

                                    // Ensure any subdirectories in the entry name exist
                                    string entryDirectory = Path.GetDirectoryName(outputPath);
                                    if (!string.IsNullOrEmpty(entryDirectory))
                                    {
                                        Directory.CreateDirectory(entryDirectory);
                                    }

                                    // Write the byte array to disk using the original entry name
                                    File.WriteAllBytes(outputPath, imageData);
                                    Console.WriteLine($"Extracted: {entry.Name}");
                                }
                            }
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
 * 1. When you need to programmatically pull all picture files out of a user‑uploaded ZIP and store them as byte arrays for further processing before writing them to disk.
 * 2. When a web service must validate or resize images that are bundled in a compressed archive without extracting the whole archive to a temporary folder.
 * 3. When an automated build pipeline extracts product screenshots from a release package to embed them into documentation or release notes.
 * 4. When a desktop application reads a ZIP containing design assets and saves each image using its original filename for easy reference by designers.
 * 5. When a migration script moves image resources from legacy ZIP backups into a new file system while preserving the original naming convention.
 */
