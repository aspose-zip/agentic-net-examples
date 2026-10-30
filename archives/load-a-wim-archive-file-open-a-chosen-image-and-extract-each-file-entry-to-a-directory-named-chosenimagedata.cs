// HOW-TO: Extract Specific Image Files from a WIM Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input WIM file and output directory
        string inputPath = "sample.wim";
        string outputDir = "ChosenImageData";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the WIM archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Choose the image index to extract (e.g., first image)
                    int imageIndex = 0;

                    // Extract all entries of the chosen image to the output directory
                    archive.Images[imageIndex].ExtractToDirectory(outputDir);
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
 * 1. When you need to pull the files of a particular Windows image from a .wim deployment package for analysis or customization.
 * 2. When automating the creation of a backup of a selected image’s contents from a system image archive to a local directory.
 * 3. When building a deployment script that extracts only the first image of a multi‑image WIM to prepare files for a clean‑room build.
 * 4. When developing a tool that reads a WIM file and extracts its chosen image to a folder for further processing such as scanning or indexing.
 * 5. When integrating Aspose.Zip for .NET into a CI pipeline to unpack a specific image from a Windows installation media archive for testing.
 */
