// HOW-TO: Extract First Image From WIM Archive To Folder Using C# (Aspose.ZIP for .NET)
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
                if (archive.Images.Count == 0)
                {
                    Console.Error.WriteLine("No images found in the WIM archive.");
                    return;
                }

                archive.Images[0].ExtractToDirectory(outputFolder);
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
 * 1. When you need to programmatically unpack the first image of a Windows Imaging Format (WIM) file to a local directory for further analysis or deployment.
 * 2. When automating the preparation of Windows installation media by extracting its core file system from a WIM archive in a C# build script.
 * 3. When building a backup verification tool that checks the contents of a WIM snapshot by extracting the primary image to compare files.
 * 4. When creating a custom imaging workflow that pulls the base image from a WIM file to modify or repackage it for enterprise deployment.
 * 5. When developing a forensic utility that reads a WIM file and extracts its first image to a secure folder for evidence collection.
 */
