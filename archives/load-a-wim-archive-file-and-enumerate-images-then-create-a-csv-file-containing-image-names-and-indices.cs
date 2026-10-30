// HOW-TO: Extract First Image From WIM Archive To Directory Using C# (Aspose.ZIP for .NET)
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
            string inputPath = "data/sample.wim";
            string outputDirectory = "output";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the WIM archive and extract the first image to the output directory
            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                if (archive.Images.Count > 0)
                {
                    archive.Images[0].ExtractToDirectory(outputDirectory);
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
 * 1. When you need to programmatically pull the primary image from a Windows Imaging Format (WIM) file for further analysis or deployment in a C# application.
 * 2. When automating the creation of a clean working copy of a system image stored in a WIM archive as part of a build or testing pipeline.
 * 3. When building a tool that validates that a WIM file contains at least one image before proceeding with installation scripts.
 * 4. When extracting the first image from a WIM backup to a specific folder to recover files after a system failure.
 * 5. When integrating WIM image extraction into a .NET service that prepares custom Windows PE environments for deployment.
 */
