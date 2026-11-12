// HOW-TO: Create Self‑Extracting EXE From Extracted WIM Images In C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string wimPath = @"C:\Data\sample.wim";
            string extractDir = @"C:\Data\WimExtracted";
            string sfxPath = @"C:\Data\AllImagesSfx.exe";

            // Validate input WIM file
            if (!File.Exists(wimPath))
            {
                Console.Error.WriteLine($"File not found: {wimPath}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract all images from the WIM archive
            using (FileStream wimStream = File.OpenRead(wimPath))
            {
                using (WimArchive wimArchive = new WimArchive(wimStream))
                {
                    for (int i = 0; i < wimArchive.Images.Count; i++)
                    {
                        string imageDir = Path.Combine(extractDir, $"Image_{i}");
                        Directory.CreateDirectory(imageDir);
                        wimArchive.Images[i].ExtractToDirectory(imageDir);
                    }
                }
            }

            // Ensure output directory for the SFX executable exists
            Directory.CreateDirectory(Path.GetDirectoryName(sfxPath));

            // Create self‑extracting archive containing all extracted files
            using (Archive archive = new Archive())
            {
                // Add all files from the extraction folder recursively
                string[] files = Directory.GetFiles(extractDir, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    string entryName = Path.GetRelativePath(extractDir, filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Configure self‑extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                SelfExtractorOptions sfxOptions = new SelfExtractorOptions();
                // Optional: set default extraction location inside the SFX (can be left empty)
                // sfxOptions.ExtractLocation = Path.GetTempPath();
                saveOptions.SelfExtractorOptions = sfxOptions;

                // Save as .exe SFX archive
                archive.Save(sfxPath, saveOptions);
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
 * 1. When you need to distribute a Windows image's files to end users without requiring them to run a separate extraction tool, you can bundle the extracted WIM contents into a self‑extracting EXE.
 * 2. When automating a deployment pipeline that extracts multiple images from a WIM file and then packages them for easy transfer to another server, this code creates the SFX archive in one step.
 * 3. When creating a portable backup of all images inside a WIM archive that can be restored simply by executing the generated EXE, the self‑extracting archive simplifies recovery.
 * 4. When delivering custom Windows installation resources to technicians who may not have WIM handling utilities installed, the SFX file provides a click‑once extraction experience.
 * 5. When integrating Aspose.Zip into a C# application to programmatically extract WIM images and then compress them into a single executable for distribution via email or download links, this approach handles both tasks automatically.
 */
