// HOW-TO: Extract Specific Image from WIM Archive to Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.wim";
            string outputPath = "output\\extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                int imageIndex = 0;
                if (imageIndex < 0 || imageIndex >= archive.Images.Count)
                {
                    Console.Error.WriteLine($"Image index {imageIndex} is out of range.");
                    return;
                }

                archive.Images[imageIndex].ExtractToDirectory(outputPath);
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
 * 1. When you need to programmatically extract the first image from a Windows Imaging Format (WIM) file to deploy files onto a target system using C#.
 * 2. When building an automated tool that reads a WIM archive and pulls out a specific image for creating custom Windows installation media.
 * 3. When creating a backup solution that restores files from a particular image inside a WIM file without manual interaction.
 * 4. When developing a CI/CD pipeline that validates the contents of a WIM image by extracting it to a temporary directory for inspection.
 * 5. When writing a utility that processes WIM archives to retrieve a selected image for forensic analysis or content indexing.
 */
