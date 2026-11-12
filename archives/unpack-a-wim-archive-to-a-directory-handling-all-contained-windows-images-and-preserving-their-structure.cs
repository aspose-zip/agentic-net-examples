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
            // Hardcoded paths for the WIM archive and the extraction folder
            string inputPath = "C:\\Data\\sample.wim";
            string outputPath = "C:\\Data\\ExtractedWim";

            // Verify that the input WIM file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the WIM archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                // Iterate through all images contained in the WIM archive
                for (int i = 0; i < archive.Images.Count; i++)
                {
                    // Create a subdirectory for each image to preserve its structure
                    string imageDir = Path.Combine(outputPath, $"Image_{i}");
                    Directory.CreateDirectory(imageDir);

                    // Extract the current image to its dedicated directory
                    archive.Images[i].ExtractToDirectory(imageDir);
                }
            }
        }
        catch (Exception ex)
        {
            // Output any unexpected errors without crashing
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to deploy multiple Windows editions from a single WIM file and want each image extracted to its own folder for further processing.
 * 2. When automating the creation of backup copies of Windows system images stored in a WIM archive for offline analysis.
 * 3. When building a custom Windows installation media and must unpack every image in the WIM to modify files before repackaging.
 * 4. When a forensic tool requires access to individual images inside a WIM file to examine file system contents separately.
 * 5. When a CI/CD pipeline must extract all images from a WIM archive to run validation scripts on each Windows image.
 */
