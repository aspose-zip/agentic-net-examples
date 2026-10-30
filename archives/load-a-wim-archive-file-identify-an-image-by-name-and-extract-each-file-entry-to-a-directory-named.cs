// HOW-TO: Extract First Image From WIM Archive To Directory In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WIM file path
            string inputPath = @"C:\Data\sample.wim";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output directory for the extracted image
            string outputPath = @"C:\Data\NamedImageExtract";

            // Ensure the output directory's parent exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the WIM archive
            using (FileStream fs = File.OpenRead(inputPath))
            using (WimArchive archive = new WimArchive(fs))
            {
                if (archive.Images.Count > 0)
                {
                    // Extract the first image to the output directory
                    archive.Images[0].ExtractToDirectory(outputPath);
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
 * 1. When you need to unpack the first image of a Windows Imaging Format (WIM) file to a specific folder for further analysis or deployment.
 * 2. When automating backup restoration scripts that must retrieve the primary image from a WIM backup and place its contents in a known directory.
 * 3. When building a CI/CD pipeline that validates the contents of a WIM image by extracting it locally before running tests.
 * 4. When creating a custom installer that extracts the base system image from a WIM package to customize files before packaging.
 * 5. When troubleshooting deployment issues by extracting the first image of a WIM file to inspect file structures and permissions.
 */
