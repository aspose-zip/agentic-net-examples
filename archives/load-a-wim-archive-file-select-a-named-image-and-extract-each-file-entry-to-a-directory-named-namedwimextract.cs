// HOW-TO: Extract First Image From WIM Archive To Folder In C# (Aspose.ZIP for .NET)
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
            string outputPath = "C:\\Data\\NamedWimExtract";

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
                if (archive.Images.Count == 0)
                {
                    Console.Error.WriteLine("No images found in the WIM archive.");
                    return;
                }

                archive.Images[0].ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack the default Windows image from a .wim file to modify its contents before deployment.
 * 2. When automating a build pipeline that extracts files from a captured Windows image for validation or testing.
 * 3. When creating a backup script that pulls the first image of a WIM archive to a known folder for later analysis.
 * 4. When developing a migration tool that reads a WIM file and extracts its primary image to a staging directory.
 * 5. When troubleshooting deployment issues by extracting the WIM image locally to inspect individual files.
 */
