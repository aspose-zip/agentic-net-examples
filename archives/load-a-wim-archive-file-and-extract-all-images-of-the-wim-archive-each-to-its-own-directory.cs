// HOW-TO: Extract All Images From a WIM Archive To Separate Folders In C# (Aspose.ZIP for .NET)
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
            string inputPath = "sample.wim";
            string outputBasePath = "ExtractedImages";

            // Validate input file existence
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
                    // Create a dedicated directory for each image
                    string imageOutputDir = Path.Combine(outputBasePath, $"Image_{i}");
                    Directory.CreateDirectory(imageOutputDir);

                    // Extract the current image to its directory
                    archive.Images[i].ExtractToDirectory(imageOutputDir);
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
 * 1. When you need to unpack each Windows Imaging Format (WIM) image into its own folder for further analysis or deployment.
 * 2. When automating backup restoration scripts that must isolate individual images from a combined WIM file.
 * 3. When creating a CI/CD pipeline that validates the contents of each WIM image separately before packaging.
 * 4. When developing a tool that migrates system images from a WIM archive to separate directories for custom imaging workflows.
 * 5. When troubleshooting deployment issues by extracting each WIM image to examine its file structure individually.
 */
