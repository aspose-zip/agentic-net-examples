// HOW-TO: Extract All Images from a WIM Archive into Separate Folders in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.wim";
        string outputBasePath = @"C:\Data\ExtractedImages";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure base output directory exists
            Directory.CreateDirectory(outputBasePath);

            // Open the WIM archive
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Iterate through all images in the archive
                    for (int i = 0; i < archive.Images.Count; i++)
                    {
                        // Create a folder for each image
                        string imageFolder = Path.Combine(outputBasePath, $"Image_{i}");
                        Directory.CreateDirectory(imageFolder);

                        // Extract the image to its folder
                        archive.Images[i].ExtractToDirectory(imageFolder);
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
 * 1. When you need to unpack every Windows Imaging Format (WIM) image to process or analyze them individually, this code extracts each image into its own folder.
 * 2. When automating deployment scripts that require separate handling of each WIM image, you can use this routine to create isolated directories for further customization.
 * 3. When building a backup verification tool that compares extracted image contents against expected files, the code provides a quick way to pull all images out of a WIM file.
 * 4. When integrating with a CI/CD pipeline that must run tests on each WIM image, the example shows how to programmatically extract them into distinct folders for test execution.
 * 5. When developing a migration utility that moves Windows images from a WIM archive to a new storage location, this snippet creates per‑image folders to preserve the original structure.
 */
