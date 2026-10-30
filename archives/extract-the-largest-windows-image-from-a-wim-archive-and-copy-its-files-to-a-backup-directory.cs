// HOW-TO: Extract Windows Image From WIM Archive To Backup Folder In C# (Aspose.ZIP for .NET)
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
            string outputDirectory = @"C:\Extracted\Wim";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            using (FileStream fileStream = File.OpenRead(inputPath))
            using (WimArchive wimArchive = new WimArchive(fileStream))
            {
                if (wimArchive.Images.Count > 0)
                {
                    wimArchive.Images[0].ExtractToDirectory(outputDirectory);
                    Console.WriteLine($"Extracted image index 0 to {outputDirectory}");
                }
                else
                {
                    Console.Error.WriteLine("No images found in the WIM archive.");
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
 * 1. When you need to pull the primary Windows image from a .wim file to create a local backup before deployment.
 * 2. When automating a build pipeline that must unpack a captured system image for inspection or modification.
 * 3. When restoring a Windows installation from a WIM archive to a separate directory for forensic analysis.
 * 4. When copying the contents of a Windows image to a staging folder to apply custom scripts or drivers.
 * 5. When validating that a WIM file contains a usable image by programmatically extracting it to a known location.
 */
