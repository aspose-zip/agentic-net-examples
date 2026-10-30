// HOW-TO: Extract Image Index 5 From WIM Archive To Folder In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded input and output paths
            string inputPath = @"C:\Archives\sample.wim";
            string outputPath = @"C:\Archives\Image5Extract";

            // Verify that the WIM file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the extraction folder exists
            Directory.CreateDirectory(outputPath);

            // Load the WIM archive
            using (WimArchive archive = new WimArchive(inputPath))
            {
                // Validate that the archive contains at least six images (index 5)
                if (archive.Images.Count <= 5)
                {
                    Console.Error.WriteLine("Image index 5 does not exist in the archive.");
                    return;
                }

                // Select the image with index five (zero‑based)
                WimImage image = archive.Images[5];

                // Extract all entries of the selected image into the output folder
                image.ExtractToDirectory(outputPath);
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
 * 1. When you need to pull a specific Windows image (e.g., the sixth image) from a multi‑image WIM file for custom deployment or analysis.
 * 2. When automating the extraction of a particular WIM image to a directory to inspect its file structure before applying updates.
 * 3. When building a backup tool that extracts only selected images from a large WIM archive to reduce processing time.
 * 4. When creating a CI/CD pipeline that validates the contents of a specific WIM image by extracting it to a temporary folder.
 * 5. When developing a migration script that isolates a single image from a WIM file to copy its files to another system.
 */
