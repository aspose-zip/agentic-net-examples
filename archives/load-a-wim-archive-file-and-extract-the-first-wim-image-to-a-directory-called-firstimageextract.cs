// HOW-TO: Extract First Image from WIM Archive to Folder in C# (Aspose.ZIP for .NET)
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
            string inputPath = "sample.wim";
            string outputPath = "FirstImageExtract\\";

            // Verify that the input WIM file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the WIM archive
            using (WimArchive archive = new WimArchive(inputPath))
            {
                // Check that the archive contains at least one image
                if (archive.Images.Count > 0)
                {
                    // Get the first image in the archive
                    WimImage firstImage = archive.Images[0];

                    // Extract the first image to the specified directory
                    firstImage.ExtractToDirectory(outputPath);
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
 * 1. When you need to pull the primary Windows image from a .wim file to prepare it for custom deployment scripts.
 * 2. When you want to verify the contents of the first image in a backup WIM archive before performing a full system restore.
 * 3. When a build pipeline must extract the initial image from a captured Windows installation to run automated tests on its file system.
 * 4. When a migration tool extracts the first WIM image to a temporary directory to compare registry hives with a target environment.
 * 5. When a forensic analyst extracts the first image from a WIM archive to examine system files for security auditing.
 */
