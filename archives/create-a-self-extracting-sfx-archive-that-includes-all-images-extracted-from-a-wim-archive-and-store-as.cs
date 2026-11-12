// HOW-TO: Create Self‑Extracting EXE with All Images from a WIM Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Wim;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input WIM file and output self‑extracting executable paths
            string wimPath = @"C:\Data\sample.wim";
            string sfxPath = @"C:\Data\WimImagesSfx.exe";

            // Verify input file exists
            if (!File.Exists(wimPath))
            {
                Console.Error.WriteLine($"File not found: {wimPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(sfxPath));

            // Temporary directory for extracting WIM images
            string tempExtractDir = Path.Combine(Path.GetTempPath(), "WimExtractTemp");
            Directory.CreateDirectory(tempExtractDir);

            // Open the WIM archive for reading
            using (FileStream wimStream = File.OpenRead(wimPath))
            using (WimArchive wimArchive = new WimArchive(wimStream))
            using (Archive sfxArchive = new Archive())
            {
                // Extract each image to a subfolder and add its files to the self‑extracting archive
                for (int i = 0; i < wimArchive.Images.Count; i++)
                {
                    WimImage image = wimArchive.Images[i];
                    string imageFolder = Path.Combine(tempExtractDir, $"Image_{i}");
                    Directory.CreateDirectory(imageFolder);

                    // Extract the image contents to the folder
                    image.ExtractToDirectory(imageFolder);

                    // Add all files from the extracted folder to the archive
                    foreach (string filePath in Directory.GetFiles(imageFolder, "*", SearchOption.AllDirectories))
                    {
                        string entryName = Path.GetRelativePath(tempExtractDir, filePath).Replace(Path.DirectorySeparatorChar, '/');
                        sfxArchive.CreateEntry(entryName, filePath);
                    }
                }

                // Configure self‑extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save the archive as a self‑extracting executable
                sfxArchive.Save(sfxPath, saveOptions);
            }

            // Clean up temporary extraction directory
            Directory.Delete(tempExtractDir, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute all Windows image (WIM) files as a single executable that extracts the images on the target machine without requiring separate extraction tools.
 * 2. When building an automated deployment package that must include every image from a WIM archive and run as a self‑extracting installer for Windows imaging workflows.
 * 3. When creating a portable backup utility that extracts and bundles all WIM images into one EXE so users can restore the images on any Windows system.
 * 4. When integrating Aspose.Zip into a C# application to programmatically extract WIM images and generate a self‑extracting archive for easy delivery to end‑users.
 * 5. When simplifying the distribution of large WIM‑based software updates by converting the images into a single SFX executable that handles extraction and installation automatically.
 */
