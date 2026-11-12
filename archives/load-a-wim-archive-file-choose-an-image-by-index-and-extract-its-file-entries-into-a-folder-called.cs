// HOW-TO: Extract Specific Image from WIM Archive to Folder in C# (Aspose.ZIP for .NET)
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
            string inputPath = "C:\\Data\\sample.wim";
            // Hardcoded output folder for extracted image
            string outputFolder = "C:\\Data\\IndexImageExtract";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Open the WIM archive and extract the desired image
            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                // Choose the image index to extract (e.g., first image)
                int imageIndex = 0;

                // Validate the image index
                if (imageIndex < 0 || imageIndex >= archive.Images.Count)
                {
                    Console.Error.WriteLine($"Image index {imageIndex} is out of range.");
                    return;
                }

                // Extract all entries of the selected image to the output folder
                archive.Images[imageIndex].ExtractToDirectory(outputFolder);
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
 * 1. When you need to retrieve the files of a particular Windows Imaging Format (WIM) image for deployment or analysis.
 * 2. When automating the extraction of a specific image from a WIM file during a build pipeline to prepare files for testing.
 * 3. When creating a backup tool that restores only selected images from a multi‑image WIM archive without extracting the whole archive.
 * 4. When developing a forensic utility that isolates the contents of a chosen WIM image for evidence collection.
 * 5. When building a custom installer that pulls configuration files from a specific WIM image into a target directory.
 */
