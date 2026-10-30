// HOW-TO: Extract First Image Files From WIM Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string inputPath = "C:\\Data\\sample.wim";
            string outputPath = "ApiSelectedImageFiles";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? outputPath);

            // Open the WIM archive and extract the selected image entries
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    if (archive.Images.Count > 0)
                    {
                        // Extract all entries of the first image to the output folder
                        archive.Images[0].ExtractToDirectory(outputPath);
                    }
                    else
                    {
                        Console.Error.WriteLine("No images found in the WIM archive.");
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
 * 1. When you need to programmatically pull the boot image files from a Windows Imaging Format (WIM) archive for deployment scripts.
 * 2. When automating the extraction of specific image contents from a WIM file to prepare data for forensic analysis.
 * 3. When building a C# utility that copies the first image's files from a WIM package into a staging directory for custom OS customization.
 * 4. When integrating Aspose.Zip into a backup solution that must retrieve individual files from a WIM snapshot without extracting the entire archive.
 * 5. When creating a CI/CD pipeline step that validates the contents of the primary image inside a WIM file by extracting it to a temporary folder.
 */
