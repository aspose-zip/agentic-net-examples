// HOW-TO: Extract Second Image From WIM Archive To Folder In C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.wim";
            string outputPath = "Image2Extract";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? outputPath);

            // Load the WIM archive
            using (WimArchive archive = new WimArchive(inputPath))
            {
                // Verify the archive contains at least two images
                if (archive.Images.Count < 2)
                {
                    Console.Error.WriteLine("The WIM archive does not contain a second image.");
                    return;
                }

                // Select the second image (index 1)
                WimImage secondImage = archive.Images[1];

                // Extract all entries of the second image to the target folder
                secondImage.ExtractToDirectory(outputPath);
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
 * 1. When you need to pull the second image from a Windows Imaging Format (WIM) file and unpack its contents for analysis or deployment.
 * 2. When a deployment script must isolate files from a specific image inside a multi‑image WIM to a separate directory.
 * 3. When you are building a backup utility that restores only the second snapshot stored in a WIM archive.
 * 4. When a forensic tool requires extracting all files of a particular WIM image to examine system state at that point.
 * 5. When automating the creation of a custom Windows PE build by extracting the second image’s files into a working folder.
 */
