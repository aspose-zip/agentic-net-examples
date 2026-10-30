// HOW-TO: Extract Third Image From WIM Archive To Folder Using C# (Aspose.ZIP for .NET)
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
            string inputPath = "C:\\Data\\sample.wim";
            // Hardcoded output folder for the third image files
            string outputPath = "C:\\Data\\Image3Files";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory's parent exists (as per safety rule)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the WIM archive for reading
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    // Verify the archive contains at least three images
                    if (archive.Images.Count < 3)
                    {
                        Console.Error.WriteLine("The archive does not contain a third image.");
                        return;
                    }

                    // Extract the third image (index 2) to the specified folder
                    archive.Images[2].ExtractToDirectory(outputPath);
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
 * 1. When you need to retrieve the files of a specific Windows Imaging Format (WIM) image, such as the third snapshot, for analysis or deployment.
 * 2. When automating a backup process that extracts only the third image of a multi‑image WIM file to a separate directory for further processing.
 * 3. When building a tool that isolates a particular Windows system image from a WIM package to copy its contents to a staging folder before customization.
 * 4. When troubleshooting a WIM archive by extracting the third image’s files to examine its directory structure and verify integrity.
 * 5. When creating a CI/CD pipeline step that pulls the third image from a WIM file and extracts its contents to a known location for packaging or testing.
 */
