// HOW-TO: Extract All Images from a WIM Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "C:\\Data\\sample.wim";
        string outputFolder = "C:\\Data\\ExtractedImages";

        try
        {
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
                    foreach (WimImage image in archive.Images)
                    {
                        image.ExtractToDirectory(outputFolder);
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
 * 1. When you need to programmatically unpack all Windows Imaging Format (WIM) images to a folder for further analysis or deployment.
 * 2. When automating the extraction of system image files from a WIM archive in a C# build or CI pipeline.
 * 3. When creating a backup script that pulls every image from a WIM file to a designated directory before archiving.
 * 4. When developing a tool that reads a WIM archive to list and extract its contained images for forensic or migration purposes.
 * 5. When integrating Aspose.Zip into a .NET application to handle WIM files and extract their images without using external command‑line utilities.
 */
