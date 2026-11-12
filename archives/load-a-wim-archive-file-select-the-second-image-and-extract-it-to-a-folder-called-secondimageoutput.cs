// HOW-TO: Extract Second Image from WIM Archive to Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.wim";
            string outputFolder = "SecondImageOutput";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Open the WIM archive and extract the second image (index 1)
            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (WimArchive archive = new WimArchive(fs))
                {
                    archive.Images[1].ExtractToDirectory(outputFolder);
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to retrieve a specific Windows Imaging (WIM) image, such as the second build, for deployment or analysis.
 * 2. When automating the extraction of a particular image from a multi‑image WIM file to prepare it for further processing in a CI pipeline.
 * 3. When creating a backup tool that extracts individual images from a WIM archive to separate directories for selective restoration.
 * 4. When developing a forensic application that isolates a specific image inside a WIM file to examine its contents without extracting the entire archive.
 * 5. When building a custom installer that pulls only the required image from a WIM package to reduce installation size and time.
 */
