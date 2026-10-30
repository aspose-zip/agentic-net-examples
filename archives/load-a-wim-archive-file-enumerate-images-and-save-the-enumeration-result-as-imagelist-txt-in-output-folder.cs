// HOW-TO: List Images In A WIM Archive And Save To Text File In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\Data\\sample.wim";
            string outputFolder = "C:\\Output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare output file path
            string outputPath = Path.Combine(outputFolder, "ImageList.txt");
            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the WIM archive and enumerate images
            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                List<string> lines = new List<string>();
                for (int i = 0; i < archive.Images.Count; i++)
                {
                    // Add a simple description for each image
                    lines.Add($"Image {i}");
                }

                // Write the enumeration result to a text file
                File.WriteAllLines(outputPath, lines);
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
 * 1. When you need to generate a simple inventory of all images inside a Windows Imaging Format (WIM) file for documentation or reporting purposes.
 * 2. When a deployment script must verify the number of images contained in a WIM before proceeding with further processing.
 * 3. When you want to create a text manifest of WIM images to compare different builds or versions of an operating system image.
 * 4. When an automated backup system requires logging the image names from a WIM archive to a log file for audit trails.
 * 5. When a CI/CD pipeline needs to extract metadata from a WIM file and store it in a readable file for downstream analysis.
 */
