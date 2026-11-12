// HOW-TO: Extract First Image From WIM Archive Using Aspose Zip for .NET (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Archives\sample.wim";
            string outputPath = @"C:\Archives\ImageOneExtract";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the WIM archive
            using (WimArchive wim = new WimArchive(inputPath))
            {
                // Extract the first image (index 0) to the specified directory
                if (wim.Images.Count > 0)
                {
                    WimImage image = wim.Images[0];
                    image.ExtractToDirectory(outputPath);
                }
                else
                {
                    Console.Error.WriteLine("No images found in the WIM archive.");
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
 * 1. When you need to programmatically retrieve the boot image from a Windows installation WIM file for deployment scripts.
 * 2. When automating the creation of a custom recovery environment by extracting a specific image from a WIM archive on a build server.
 * 3. When building a C# utility that pulls a particular image out of a WIM to analyze its file contents before applying updates.
 * 4. When integrating Aspose.Zip into a CI/CD pipeline to unpack a WIM image into a staging folder for further processing.
 * 5. When developing a backup verification tool that extracts the first image of a WIM archive to compare its files against a reference set.
 */
