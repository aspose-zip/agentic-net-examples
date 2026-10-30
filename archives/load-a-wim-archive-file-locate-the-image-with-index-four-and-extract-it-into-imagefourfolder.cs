// HOW-TO: Extract Fourth Image From WIM Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string inputPath = "data/input.wim";
            string outputFolder = "output/ImageFourFolder";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory's parent exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFolder));

            // Open the WIM archive and extract the image at index 4
            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                archive.Images[4].ExtractToDirectory(outputFolder);
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
 * 1. When you need to retrieve a specific image (the fourth) from a Windows Imaging Format (WIM) file for further processing or analysis.
 * 2. When automating deployment scripts that must extract particular images from a WIM‑based Windows installation media.
 * 3. When building a backup restoration tool that selectively restores only certain images from a multi‑image WIM archive.
 * 4. When creating a custom imaging workflow that pulls a designated image out of a WIM file to generate a separate ISO or disk image.
 * 5. When troubleshooting or auditing a WIM archive by extracting a specific image to examine its contents without unpacking the entire archive.
 */
