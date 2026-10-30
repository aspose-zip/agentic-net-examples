// HOW-TO: Extract First Image from WIM Archive to Folder Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Data\sample.wim";
        string outputFolder = @"C:\Data\ExtractedImage";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(outputFolder);
        Directory.CreateDirectory(Path.GetDirectoryName(outputFolder));

        try
        {
            using (FileStream fileStream = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fileStream))
                {
                    if (archive.Images.Count > 0)
                    {
                        archive.Images[0].ExtractToDirectory(outputFolder);
                        Console.WriteLine($"Image extracted to '{outputFolder}'.");
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
 * 1. When you need to retrieve the default Windows image from a .wim file for custom deployment scripts.
 * 2. When you want to verify the contents of a WIM archive by extracting its first image to a local directory for inspection.
 * 3. When automating a backup process that requires pulling the primary image out of a WIM file before archiving it elsewhere.
 * 4. When building a tool that extracts the base system image from Windows installation media to modify files before re‑packaging.
 * 5. When troubleshooting deployment failures by extracting the first image from a WIM to compare its files with a known good version.
 */
