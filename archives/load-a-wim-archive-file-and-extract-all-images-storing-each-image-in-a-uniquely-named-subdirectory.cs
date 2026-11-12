// HOW-TO: Extract All Images from a WIM Archive to Separate Folders in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WIM file path
            string inputPath = @"C:\Data\sample.wim";
            // Hardcoded base output directory for extracted images
            string outputBasePath = @"C:\Data\ExtractedImages";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure base output directory exists
            Directory.CreateDirectory(outputBasePath);

            // Open the WIM archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Iterate over each image in the archive
                    for (int i = 0; i < archive.Images.Count; i++)
                    {
                        // Create a unique subdirectory for the current image
                        string imageDir = Path.Combine(outputBasePath, $"Image_{i}");
                        Directory.CreateDirectory(imageDir);

                        // Extract the image to its subdirectory
                        archive.Images[i].ExtractToDirectory(imageDir);
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
 * 1. When you need to unpack every image from a Windows Imaging Format (WIM) file for analysis or migration, this code extracts each image into its own folder.
 * 2. When automating a backup verification process that compares extracted images against a reference set, the unique subdirectories simplify file‑by‑file comparison.
 * 3. When building a deployment tool that must separate individual WIM images before applying them to different machines, the code creates isolated directories for each image.
 * 4. When creating a reporting script that generates thumbnails from each WIM image, extracting them into distinct folders makes batch processing straightforward.
 * 5. When troubleshooting a corrupted WIM archive by isolating each image to inspect its contents, this extraction routine provides a clean, organized view of all images.
 */
