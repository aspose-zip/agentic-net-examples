// HOW-TO: Extract All Images From a WIM Archive To Separate Folders In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Data\sample.wim";
        string outputFolder = @"C:\Data\ExtractedImages";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                int index = 0;
                foreach (WimImage image in archive.Images)
                {
                    string imageFolder = Path.Combine(outputFolder, $"Image_{index}");
                    Directory.CreateDirectory(imageFolder);
                    image.ExtractToDirectory(imageFolder);
                    index++;
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
 * 1. When you need to programmatically unpack each Windows image from a .wim file for custom deployment or analysis.
 * 2. When automating the creation of a repository of individual Windows image files to run offline servicing or patching.
 * 3. When building a tool that extracts all images from Windows installation media to separate directories for forensic examination.
 * 4. When developing a backup solution that isolates each captured system image from a WIM archive for independent storage.
 * 5. When integrating with a CI pipeline that validates the contents of a WIM by extracting each image to verify file integrity.
 */
