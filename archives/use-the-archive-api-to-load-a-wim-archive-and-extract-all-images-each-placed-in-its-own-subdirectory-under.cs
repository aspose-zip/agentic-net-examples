// HOW-TO: Extract All Images from a WIM Archive to Separate Folders in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input WIM archive path
        string inputPath = "sample.wim";
        // Base output directory for all extracted images
        string outputBase = "ApiAllImages";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputBase);

            // Open the WIM archive for reading
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fileStream))
            {
                // Iterate over each image in the archive
                int imageCount = archive.Images.Count;
                for (int i = 0; i < imageCount; i++)
                {
                    // Create a subdirectory for the current image
                    string imageDirectory = Path.Combine(outputBase, $"Image_{i}");
                    Directory.CreateDirectory(imageDirectory);

                    // Extract the image to its dedicated subdirectory
                    archive.Images[i].ExtractToDirectory(imageDirectory);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unpack every image from a Windows Imaging Format (WIM) file for individual processing or analysis, this code extracts each image into its own folder.
 * 2. If you are building a deployment tool that must separate WIM images to apply them independently, the example creates distinct directories for each image automatically.
 * 3. When migrating legacy WIM archives to a new storage system, you can use this snippet to extract all images and organize them under a common root folder.
 * 4. For automated testing that requires access to each image inside a WIM archive, the code provides a quick way to extract them into separate test directories.
 * 5. When creating documentation or visual catalogs of the contents of a WIM file, the program extracts each image into its own subdirectory for easy reference.
 */
