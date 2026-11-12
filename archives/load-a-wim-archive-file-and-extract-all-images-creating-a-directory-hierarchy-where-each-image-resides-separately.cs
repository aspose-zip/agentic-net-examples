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
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.wim";
            string outputBasePath = @"C:\Output\WimImages";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputBasePath);

            // Open the WIM archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                // Iterate over all images in the archive
                for (int i = 0; i < archive.Images.Count; i++)
                {
                    // Create a separate directory for each image
                    string imageDir = Path.Combine(outputBasePath, $"Image_{i}");
                    Directory.CreateDirectory(imageDir);

                    // Extract the image to its directory
                    archive.Images[i].ExtractToDirectory(imageDir);
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
 * 1. When you need to unpack Windows Imaging Format (WIM) files to access individual system images for analysis or deployment.
 * 2. When you want to programmatically extract each image from a WIM archive into its own directory for automated testing of different Windows builds.
 * 3. When you are building a backup tool that must separate and store each captured Windows image from a WIM file for later restoration.
 * 4. When you need to migrate or compare files across multiple images inside a WIM archive by extracting them into distinct folders.
 * 5. When you are creating a CI/CD pipeline that validates the contents of each WIM image by extracting them individually for scanning.
 */
