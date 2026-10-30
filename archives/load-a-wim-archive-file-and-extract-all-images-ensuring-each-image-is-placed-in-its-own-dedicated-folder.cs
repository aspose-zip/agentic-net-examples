// HOW-TO: Extract Each Image from a WIM Archive into Separate Folders in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.wim";
            string outputBasePath = @"C:\Output\WimImages";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputBasePath);

            // Open the WIM archive for reading
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (WimArchive wimArchive = new WimArchive(fileStream))
            {
                // Iterate through all images in the archive
                for (int i = 0; i < wimArchive.Images.Count; i++)
                {
                    // Create a dedicated folder for each image
                    string imageFolder = Path.Combine(outputBasePath, $"Image_{i}");
                    Directory.CreateDirectory(imageFolder);

                    // Extract the current image to its folder
                    wimArchive.Images[i].ExtractToDirectory(imageFolder);
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
 * 1. When you need to unpack all Windows Imaging Format (WIM) images for analysis, placing each image in its own directory for isolated processing.
 * 2. When automating a deployment pipeline that extracts individual WIM images to apply custom configurations per image.
 * 3. When creating a backup solution that separates each WIM image into separate folders to simplify version control and restoration.
 * 4. When developing a forensic tool that inspects each image inside a WIM file without mixing their contents.
 * 5. When building a migration utility that moves each WIM image to a distinct location before converting them to other formats.
 */
