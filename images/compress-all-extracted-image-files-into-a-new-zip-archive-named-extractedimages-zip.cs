// HOW-TO: Compress Extracted Images Into a ZIP Archive Using Aspose.Zip C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing extracted images
            string inputDirectory = "ExtractedImages";
            // Hardcoded output ZIP file path
            string outputZipPath = "ExtractedImages.zip";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Create output directory if needed (guard against null or empty)
            string outputDir = Path.GetDirectoryName(outputZipPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Define image file extensions to include
            string[] imageExtensions = new string[] { ".png", ".jpg", ".jpeg", ".gif", ".bmp" };

            // Gather all image files recursively
            string[] imageFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.AllDirectories)
                .Where(f => imageExtensions.Contains(Path.GetExtension(f), StringComparer.OrdinalIgnoreCase))
                .ToArray();

            // Prepare the archive and keep source streams open until saving
            using (Archive archive = new Archive())
            {
                List<FileStream> openStreams = new List<FileStream>();

                foreach (string filePath in imageFiles)
                {
                    // Open file stream for the image
                    FileStream fileStream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                    openStreams.Add(fileStream);

                    // Preserve relative path inside the ZIP
                    string entryName = Path.GetRelativePath(inputDirectory, filePath);

                    // Add entry to the archive using the open stream
                    archive.CreateEntry(entryName, fileStream);
                }

                // Save the archive to the output ZIP file
                using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
                {
                    archive.Save(zipStream, new ArchiveSaveOptions());
                }

                // Dispose all opened file streams
                foreach (FileStream fs in openStreams)
                {
                    fs.Dispose();
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
 * 1. When you need to package a folder of extracted photos into a single downloadable ZIP file for web distribution.
 * 2. When you want to preserve the original folder hierarchy of images while creating a compressed archive for backup.
 * 3. When an application must automatically create a zip of only image files (png, jpg, gif, bmp) from a larger directory tree.
 * 4. When you need to generate a zip archive on the fly in a C# service without loading entire files into memory.
 * 5. When you are building a workflow that extracts images from documents and then bundles them into a zip for further processing or sharing.
 */
