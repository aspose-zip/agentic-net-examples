// HOW-TO: Extract First Image from WIM Archive to Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Wim;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\sample.wim";
        string outputDir = @"C:\Output\ExtractedImage";

        // Validate input file existence
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directories exist
        Directory.CreateDirectory(Path.GetDirectoryName(outputDir));
        Directory.CreateDirectory(outputDir);

        try
        {
            // Open the WIM archive for reading
            using (FileStream fileStream = File.OpenRead(inputPath))
            {
                using (WimArchive wimArchive = new WimArchive(fileStream))
                {
                    // Select the first image (index 0) from the archive
                    WimImage wimImage = wimArchive.Images[0];

                    // Extract the selected image to the designated output directory
                    wimImage.ExtractToDirectory(outputDir);
                }
            }

            Console.WriteLine("Image extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically retrieve a specific Windows Imaging Format (WIM) image for deployment scripts, this code extracts the first image to a known directory.
 * 2. If a backup solution stores system images in a WIM file and you must pull out a single image for verification, the example shows how to do it in C#.
 * 3. When building a custom installer that reads a WIM package and needs to copy one of its images to a staging folder, this snippet provides the extraction logic.
 * 4. For forensic analysis where investigators need to isolate a particular WIM image from a larger archive, the code demonstrates how to extract it using Aspose.Zip.
 * 5. When automating a CI/CD pipeline that unpacks a WIM file to retrieve an OS image for testing, this example shows the C# method to extract the image to a target path.
 */
