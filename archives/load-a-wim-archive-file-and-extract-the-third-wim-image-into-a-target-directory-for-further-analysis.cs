// HOW-TO: Extract Third Image From WIM Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input WIM file path
        string inputPath = @"C:\Data\sample.wim";
        // Hardcoded output directory for the third image
        string outputPath = @"C:\Data\ExtractedImage3";

        try
        {
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
                    // Check that the archive contains at least three images
                    if (archive.Images.Count < 3)
                    {
                        Console.Error.WriteLine("The WIM archive does not contain a third image.");
                        return;
                    }

                    // Extract the third image (index 2) to the target directory
                    archive.Images[2].ExtractToDirectory(outputPath);
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
 * 1. When you need to analyze a specific Windows Imaging Format (WIM) image, such as the third image in a multi‑image WIM file, you can extract it to a folder for inspection.
 * 2. When automating deployment scripts that must retrieve a particular image from a WIM package without extracting the entire archive.
 * 3. When building a forensic tool that isolates a chosen WIM image for malware scanning or integrity checks.
 * 4. When creating a backup validation routine that compares the contents of a specific WIM image against expected files.
 * 5. When developing a custom installer that re‑uses only one image from a multi‑image WIM to reduce disk usage and installation time.
 */
