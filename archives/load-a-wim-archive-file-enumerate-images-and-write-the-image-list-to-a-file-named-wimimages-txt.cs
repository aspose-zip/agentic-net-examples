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
            string outputPath = "ExtractedWim";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    for (int i = 0; i < archive.Images.Count; i++)
                    {
                        string imageOutputDir = Path.Combine(outputPath, $"Image_{i}");
                        Directory.CreateDirectory(imageOutputDir);
                        archive.Images[i].ExtractToDirectory(imageOutputDir);
                    }
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
 * 1. When you need to unpack each Windows Imaging Format (WIM) image into its own directory for analysis or modification.
 * 2. When automating the creation of a clean file structure from a WIM file before applying custom scripts to individual images.
 * 3. When building a deployment pipeline that extracts WIM images to prepare them for further processing or re‑packaging.
 * 4. When performing forensic investigations that require separating each image inside a WIM archive for detailed examination.
 * 5. When migrating legacy system backups stored in WIM archives and you must extract the contained images to a new location.
 */
