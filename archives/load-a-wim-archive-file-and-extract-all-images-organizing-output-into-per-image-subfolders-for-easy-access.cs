// HOW-TO: Extract All Images From a WIM Archive to Separate Folders in C# (Aspose.ZIP for .NET)
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
            // Hardcoded output root folder for extracted images
            string outputRoot = @"C:\Data\ExtractedImages";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output root directory exists
            Directory.CreateDirectory(outputRoot);

            // Open the WIM archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Iterate over each image in the archive
                    int imageCount = archive.Images.Count;
                    for (int i = 0; i < imageCount; i++)
                    {
                        // Create a subfolder for the current image
                        string imageFolder = Path.Combine(outputRoot, $"Image_{i}");
                        Directory.CreateDirectory(imageFolder);

                        // Extract the image to its dedicated subfolder
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
 * 1. When you need to pull every image file from a Windows Imaging Format (WIM) backup to analyze or edit them individually.
 * 2. When automating a deployment pipeline that must unpack WIM images into isolated directories for further processing or customization.
 * 3. When performing forensic analysis on a captured system image and require each image layer extracted into its own folder for detailed inspection.
 * 4. When creating a documentation set that showcases the contents of each WIM image separately, needing a clean folder structure for screenshots or reports.
 * 5. When building a migration tool that reads a WIM archive and stores each image in a distinct directory to simplify comparison with existing installations.
 */
