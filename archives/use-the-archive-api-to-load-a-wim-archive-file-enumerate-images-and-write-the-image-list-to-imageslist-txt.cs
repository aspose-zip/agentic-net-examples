// HOW-TO: List Images in a WIM Archive and Save to Text File in C# (Aspose.ZIP for .NET)
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
            string inputPath = "sample.wim";
            string outputPath = "ImagesList.txt";

            // Verify that the input WIM file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists (handles case when outputPath is just a file name)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // Open the WIM archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Enumerate images and collect their identifiers
                    List<string> imageList = new List<string>();
                    for (int i = 0; i < archive.Images.Count; i++)
                    {
                        // Use ToString() to obtain a readable representation of the image
                        string imageInfo = archive.Images[i].ToString();
                        imageList.Add(imageInfo);
                    }

                    // Write the list of images to the output text file
                    File.WriteAllLines(outputPath, imageList);
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
 * 1. When you need to audit the contents of a Windows Imaging Format (WIM) file to verify which images are included before deployment.
 * 2. When you want to generate a simple inventory report of all images inside a WIM archive for documentation or compliance purposes.
 * 3. When a build automation script must extract image identifiers from a WIM file to feed into further processing or packaging steps.
 * 4. When troubleshooting deployment failures and you need to quickly view the list of images stored in a WIM without extracting them.
 * 5. When creating a custom UI that displays available WIM images, you can use this code to populate the list from the archive file.
 */
