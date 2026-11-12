// HOW-TO: Extract First Image from WIM Archive to Folder Using Aspose.Zip for .NET (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WIM archive path
            string inputPath = "sample.wim";
            // Output folder for the extracted image
            string outputPath = "ApiSpecificImage";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Open the WIM archive and extract the first image
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Extract image at index 0 to the specified folder
                    archive.Images[0].ExtractToDirectory(outputPath);
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
 * 1. When you need to programmatically pull the boot image from a Windows Imaging Format (WIM) file for deployment scripts.
 * 2. When automating the extraction of a specific image from a WIM archive to prepare it for further analysis or modification.
 * 3. When building a backup tool that must retrieve the first image inside a WIM file and store it in a designated directory.
 * 4. When integrating Aspose.Zip into a CI/CD pipeline to verify that a WIM package contains the expected image by extracting it locally.
 * 5. When creating a custom installer that extracts a WIM image to a temporary folder before applying it to a target system.
 */
