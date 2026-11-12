// HOW-TO: Extract All Images from a WIM Archive to Indexed Folders in C# (Aspose.ZIP for .NET)
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
            // Hardcoded base output directory for extracted images
            string outputBasePath = "C:\\Data\\ExtractedImages";

            // Verify that the input file exists
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
                    // Create a folder named with the image index
                    string imageFolder = Path.Combine(outputBasePath, i.ToString());
                    Directory.CreateDirectory(imageFolder);

                    // Extract the current image into its folder
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
 * 1. When you need to unpack every image from a Windows Imaging Format (WIM) file for analysis or migration, this code extracts them into separate, index‑named folders.
 * 2. If a deployment pipeline must verify the integrity of each image inside a WIM package, you can use this routine to isolate and inspect each image individually.
 * 3. For creating a catalog of all images contained in a WIM archive, the script extracts each image to its own folder, simplifying catalog generation and metadata collection.
 * 4. When automating backup restoration that requires pulling specific images from a WIM file, the code provides a quick way to extract all images into organized directories.
 * 5. If you are building a custom installer that needs to reuse individual images from a WIM source, this example shows how to programmatically extract them into separate folders for further processing.
 */
