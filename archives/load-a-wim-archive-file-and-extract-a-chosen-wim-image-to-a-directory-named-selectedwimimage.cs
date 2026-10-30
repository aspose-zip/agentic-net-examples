// HOW-TO: Extract Specific Image From WIM Archive To Folder In C# (Aspose.ZIP for .NET)
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
            // Output directory for the selected image
            string outputPath = "SelectedWimImage";

            // Verify the input file exists
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
                // Load the archive
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Choose the image to extract (e.g., first image)
                    int imageIndex = 0;
                    // Extract the selected image to the output directory
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
 * 1. When you need to retrieve a particular Windows Imaging Format (WIM) image from a multi‑image archive for deployment or analysis.
 * 2. When automating the extraction of a selected WIM image to a known directory as part of a build or CI pipeline.
 * 3. When creating a backup script that pulls only the required image from a large WIM file to save storage space.
 * 4. When developing a tool that inspects or modifies files inside a specific WIM image without extracting the entire archive.
 * 5. When integrating with imaging software that expects the contents of a single WIM image to be available in a standard folder structure.
 */
