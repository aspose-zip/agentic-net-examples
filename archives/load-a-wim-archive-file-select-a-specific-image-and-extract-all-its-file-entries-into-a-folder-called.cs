// HOW-TO: Extract Specific Image From WIM Archive to Folder Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define the input WIM archive path
            string inputPath = "C:\\Data\\sample.wim";

            // Define the output folder for the specific image extraction
            string outputPath = "C:\\Data\\SpecificImageExtract";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the WIM archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Select the specific image index (e.g., first image)
                    int imageIndex = 0;

                    // Validate the image index range
                    if (imageIndex < 0 || imageIndex >= archive.Images.Count)
                    {
                        Console.Error.WriteLine($"Image index {imageIndex} is out of range.");
                        return;
                    }

                    // Extract all entries of the selected image to the output folder
                    archive.Images[imageIndex].ExtractToDirectory(outputPath);
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
 * 1. When you need to retrieve only the files from a particular Windows Imaging Format (WIM) image for deployment scripts.
 * 2. When automating backup restoration and you must extract a single image's contents from a multi‑image WIM file.
 * 3. When building a tool that analyzes the file structure of a specific WIM image without loading the entire archive.
 * 4. When creating a custom installer that pulls resources from a chosen image inside a WIM package.
 * 5. When troubleshooting a corrupted WIM and you want to isolate and extract the files of one image for inspection.
 */
