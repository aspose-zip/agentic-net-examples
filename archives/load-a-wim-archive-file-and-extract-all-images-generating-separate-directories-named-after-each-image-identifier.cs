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
            // Hardcoded input WIM file and base output directory
            string inputPath = "sample.wim";
            string outputBase = "ExtractedImages";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure base output directory exists
            Directory.CreateDirectory(outputBase);

            // Open the WIM archive
            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                // Iterate through all images in the archive
                for (int i = 0; i < archive.Images.Count; i++)
                {
                    WimImage image = archive.Images[i];

                    // Create a directory named after the image index
                    string imageDir = Path.Combine(outputBase, i.ToString());
                    Directory.CreateDirectory(imageDir);

                    // Extract the image to its dedicated directory
                    image.ExtractToDirectory(imageDir);
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
 * 1. When you need to unpack every image from a Windows Imaging Format (WIM) file for analysis or modification, this code extracts each image into its own folder.
 * 2. When automating deployment scripts that must isolate individual system images stored in a WIM for separate testing environments, the routine creates distinct directories per image.
 * 3. When building a backup verification tool that compares extracted image contents against expected files, the code provides a convenient way to pull each image out of the archive.
 * 4. When integrating Aspose.Zip for .NET into a CI pipeline to generate per‑image artifacts from a WIM package, the example shows how to programmatically extract them.
 * 5. When creating a forensic utility that needs to examine each image inside a captured Windows system image without manual extraction, this snippet automates the process.
 */
