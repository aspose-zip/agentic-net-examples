// HOW-TO: Extract First Image From WIM Archive To Directory Using Aspose.Zip For .NET (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.wim";
            string outputPath = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream fileStream = File.OpenRead(inputPath))
            {
                using (WimArchive wimArchive = new WimArchive(fileStream))
                {
                    if (wimArchive.Images.Count > 0)
                    {
                        wimArchive.Images[0].ExtractToDirectory(outputPath);
                        Console.WriteLine("Extraction completed.");
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
 * 1. When you need to programmatically pull the primary image from a Windows Imaging Format (WIM) file for deployment scripts.
 * 2. When automating backup restoration and you must extract the first image of a WIM backup to a specific folder.
 * 3. When building a tool that validates the contents of a WIM archive by extracting its first image for inspection.
 * 4. When integrating with a CI/CD pipeline that requires extracting a WIM image to prepare a Windows installation environment.
 * 5. When creating a custom installer that reads a WIM file and extracts the initial image to a target directory for further processing.
 */
