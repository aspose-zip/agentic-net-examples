// HOW-TO: Extract First Image from WIM Archive to Folder in C# (Aspose.ZIP for .NET)
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
            string outputFolder = @"C:\Data\Extracted";

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
 * 1. When you need to programmatically pull the default Windows image from a .wim file for automated deployment scripts.
 * 2. When building a C# tool that validates the contents of a WIM backup by extracting its first image to a temporary directory.
 * 3. When creating a custom installer that pulls required system files from a WIM archive without using external command‑line tools.
 * 4. When developing a migration utility that reads a captured Windows image and extracts it for analysis or modification in .NET.
 * 5. When automating forensic investigations that require extracting the primary image from a WIM file to examine file structures.
 */
