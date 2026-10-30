// HOW-TO: Extract Specific Image from WIM Archive by Index in C# (Aspose.ZIP for .NET)
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
            string outputFolder = "C:\\Data\\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                int imageIndex = 0;

                if (imageIndex < 0 || imageIndex >= archive.Images.Count)
                {
                    Console.Error.WriteLine($"Image index {imageIndex} is out of range.");
                    return;
                }

                archive.Images[imageIndex].ExtractToDirectory(outputFolder);
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
 * 1. When you need to programmatically pull a particular Windows image from a multi‑image WIM file for deployment automation.
 * 2. When building a backup tool that extracts only the first image of a system image archive to a temporary folder.
 * 3. When creating a CI/CD pipeline that validates the contents of a specific WIM image without extracting the entire archive.
 * 4. When developing a migration script that pulls a chosen image from a WIM file to copy files to a new location.
 * 5. When troubleshooting a corrupted WIM by extracting a single image to inspect its file structure.
 */
