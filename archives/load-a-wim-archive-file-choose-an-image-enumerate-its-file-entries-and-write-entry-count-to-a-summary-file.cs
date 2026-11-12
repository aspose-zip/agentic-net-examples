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
                    int imageIndex = 0;
                    if (archive.Images.Count == 0)
                    {
                        Console.Error.WriteLine("No images found in the WIM archive.");
                        return;
                    }

                    archive.Images[imageIndex].ExtractToDirectory(outputFolder);
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
 * 1. When you need to programmatically pull the first Windows image from a .wim file to prepare files for a custom Windows deployment.
 * 2. When an application must automatically extract a WIM image to a specific directory for further processing or analysis in a CI/CD pipeline.
 * 3. When you want to retrieve the default system image from a backup .wim archive to restore files without using GUI tools.
 * 4. When building a tool that validates the contents of a WIM archive by extracting its first image to a known location for inspection.
 * 5. When integrating with deployment scripts that require extracting a WIM image to a staging folder before applying configuration changes.
 */
