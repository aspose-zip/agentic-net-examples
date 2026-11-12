// HOW-TO: Extract a Specific Windows Image from a WIM File Using C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WIM archive path
            string inputPath = @"C:\Data\WindowsImage.wim";

            // Hardcoded output directory for the extracted image
            string outputPath = @"C:\Data\ExtractedImage";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the WIM archive and extract the desired image (index 0) to the output folder
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    int imageIndex = 0; // Index of the Windows image to extract
                    archive.Images[imageIndex].ExtractToDirectory(outputPath);
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
 * 1. When you need to pull a particular Windows edition from a WIM archive to customize a deployment image.
 * 2. When you want to programmatically extract files from a Windows installation image for forensic analysis.
 * 3. When you are building an automated tool that copies the contents of a WIM image to a staging directory before applying updates.
 * 4. When you need to retrieve the default system files from a Windows PE image to create a custom recovery environment.
 * 5. When you are scripting a backup process that restores a specific Windows image from a WIM file to a new location.
 */
