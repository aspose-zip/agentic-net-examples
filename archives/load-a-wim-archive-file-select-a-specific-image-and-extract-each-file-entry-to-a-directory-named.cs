// HOW-TO: Extract Specific Image Files from a WIM Archive in C# (Aspose.ZIP for .NET)
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
            string inputPath = "sample.wim";

            // Output directory for the selected image files
            string outputPath = "SelectedImageFiles";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the WIM archive for reading
            using (FileStream fileStream = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fileStream))
                {
                    // Index of the image to extract (0‑based)
                    int imageIndex = 0;

                    // Validate the image index
                    if (imageIndex < 0 || imageIndex >= archive.Images.Count)
                    {
                        Console.Error.WriteLine($"Invalid image index: {imageIndex}");
                        return;
                    }

                    // Extract all entries of the selected image to the output directory
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
 * 1. When you need to retrieve only the files from a particular Windows Imaging Format (WIM) image for deployment or analysis.
 * 2. When you want to programmatically extract the contents of a selected image in a multi‑image WIM file to a known folder for further processing.
 * 3. When you are building a backup tool that must isolate and copy files from a specific snapshot stored inside a WIM archive.
 * 4. When you need to validate or inspect the file structure of a chosen WIM image without extracting the entire archive.
 * 5. When you are automating the preparation of installation media by pulling files from a designated image within a WIM package.
 */
