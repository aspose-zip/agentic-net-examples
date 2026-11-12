// HOW-TO: Extract Only Image Files From ZIP To Specified Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded input ZIP file and output directory
        string inputPath = "C:\\Data\\images.zip";
        string outputDir = "C:\\Data\\ExtractedImages";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(outputDir);

        try
        {
            // Open the ZIP archive for reading
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    // Iterate through all entries in the archive
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Skip directories
                        if (entry.IsDirectory)
                        {
                            continue;
                        }

                        // Determine file extension (case‑insensitive)
                        string extension = Path.GetExtension(entry.Name).ToLowerInvariant();

                        // List of image extensions to copy
                        bool isImage = extension == ".png" ||
                                       extension == ".jpg" ||
                                       extension == ".jpeg" ||
                                       extension == ".gif" ||
                                       extension == ".bmp";

                        if (isImage)
                        {
                            // Extract the image entry to the output directory
                            entry.Extract(outputDir);
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
 * 1. When you need to pull only photos from a large ZIP package for a web gallery, this code extracts the image files to a dedicated folder.
 * 2. When automating a data‑migration pipeline that receives zipped image batches, you can use this snippet to unpack only the supported PNG, JPG, GIF, or BMP files.
 * 3. When building a desktop application that lets users select a ZIP archive and view its pictures, the code isolates the images and saves them for quick loading.
 * 4. When processing email attachments that contain compressed image collections, the utility extracts the pictures while ignoring other document types.
 * 5. When creating a backup script that restores only visual assets from archived projects, this example copies the images to a user‑specified output directory.
 */
