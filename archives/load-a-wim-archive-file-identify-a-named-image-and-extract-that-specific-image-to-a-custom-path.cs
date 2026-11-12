// HOW-TO: Extract First Image From WIM Archive To Custom Directory In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.wim";
            string outputPath = @"C:\Output\ExtractedImage";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? outputPath);

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                if (archive.Images.Count == 0)
                {
                    Console.Error.WriteLine("No images found in the WIM archive.");
                    return;
                }

                WimImage image = archive.Images[0];
                image.ExtractToDirectory(outputPath);
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
 * 1. When you need to pull the first Windows image from a .wim deployment package and place it in a specific folder for inspection or modification.
 * 2. When automating a build pipeline that extracts a WIM image to a staging directory before applying custom scripts.
 * 3. When creating a backup utility that reads a WIM file and saves its primary image to a user‑defined location for archival purposes.
 * 4. When developing a migration tool that extracts a WIM image to a temporary path so that individual files can be copied to a new system.
 * 5. When troubleshooting deployment issues by extracting the initial image from a WIM archive to examine its contents on a local drive.
 */
