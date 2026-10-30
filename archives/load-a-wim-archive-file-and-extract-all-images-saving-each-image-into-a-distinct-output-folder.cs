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
            string inputPath = "sample.wim";
            string outputBasePath = "ExtractedImages";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputBasePath);

            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    int imageCount = archive.Images.Count;
                    for (int i = 0; i < imageCount; i++)
                    {
                        string imageFolder = Path.Combine(outputBasePath, $"Image_{i}");
                        Directory.CreateDirectory(imageFolder);
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
 * 1. When you need to unpack every image from a Windows Imaging Format (WIM) file for analysis or processing, this code extracts each image into its own directory.
 * 2. When automating deployment scripts that must retrieve individual disk images from a WIM package to apply them to separate virtual machines, the example shows how to separate them programmatically.
 * 3. When creating a backup verification tool that compares extracted images against expected content, you can use this code to pull each image into distinct folders for easy comparison.
 * 4. When building a migration utility that moves legacy WIM-contained system images into a new storage structure, the snippet demonstrates extracting each image into a dedicated folder.
 * 5. When developing a forensic application that needs to isolate every image inside a WIM archive for detailed inspection, this example provides the C# method to extract them individually.
 */
