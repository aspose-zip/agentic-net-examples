// HOW-TO: Extract First Image From WIM Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\sample.wim";
            string outputFolder = "C:\\Data\\ExtractedImage0";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    if (archive.Images.Count == 0)
                    {
                        Console.Error.WriteLine("No images found in the WIM archive.");
                        return;
                    }

                    archive.Images[0].ExtractToDirectory(outputFolder);
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
 * 1. When you need to programmatically pull the first Windows Imaging Format (WIM) image from a deployment package to a specific folder in a C# application.
 * 2. When automating the preparation of a clean Windows image for testing by extracting it from a .wim file using Aspose.Zip.
 * 3. When building a backup tool that must retrieve the initial image inside a WIM archive without manual GUI interaction.
 * 4. When creating a deployment pipeline that extracts the primary image from a WIM file to modify or analyze its contents in .NET.
 * 5. When developing a utility that reads a WIM archive and extracts its first image to a target directory for further processing or inspection.
 */
