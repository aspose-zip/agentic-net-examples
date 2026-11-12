// HOW-TO: Extract All Images From A WIM Archive Using C# (Aspose.ZIP for .NET)
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
                for (int i = 0; i < archive.Images.Count; i++)
                {
                    archive.Images[i].ExtractToDirectory(outputFolder);
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
 * 1. When you need to programmatically unpack all images from a Windows Imaging Format (WIM) file to prepare files for a custom deployment script.
 * 2. When automating the migration of system images stored in a WIM archive to a new directory structure for analysis or testing.
 * 3. When building a backup verification tool that extracts each image in a WIM to compare its contents against expected files.
 * 4. When creating a CI/CD pipeline step that pulls individual images from a WIM archive to feed into container or VM image generation.
 * 5. When developing a forensic utility that reads a WIM file and extracts its images for detailed inspection or evidence collection.
 */
