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
            using (WimArchive archive = new WimArchive(fs))
            {
                int imageCount = archive.Images.Count;
                for (int i = 0; i < imageCount; i++)
                {
                    string imageFolder = Path.Combine(outputBasePath, $"Image{i}");
                    Directory.CreateDirectory(imageFolder);
                    archive.Images[i].ExtractToDirectory(imageFolder);
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
 * 1. When you need to unpack every image from a Windows Imaging Format (WIM) file for further processing or analysis in a .NET application.
 * 2. When automating the creation of individual image folders from a WIM backup to organize assets for a deployment pipeline.
 * 3. When building a tool that extracts and separates disk images stored in a WIM archive for forensic investigation or quality assurance.
 * 4. When developing a C# utility that reads a WIM archive and saves each contained image into its own directory for batch conversion or resizing.
 * 5. When integrating Aspose.Zip for .NET to programmatically extract all images from a WIM file and store them in a structured folder hierarchy for a content management system.
 */
