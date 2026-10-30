// HOW-TO: Create Self‑Extracting EXE Archive of WIM Images with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing WIM image files
            string inputDirectory = @"C:\Data\WimImages";

            // Hardcoded output SFX executable path
            string outputPath = @"C:\Output\FirstImageSfx.exe";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Configure self-extracting options
            SelfExtractorOptions selfExtractor = new SelfExtractorOptions();
            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
            saveOptions.SelfExtractorOptions = selfExtractor;

            // Create archive and add files
            using (Archive archive = new Archive())
            {
                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Save as self-extracting executable
                archive.Save(outputPath, saveOptions);
            }

            Console.WriteLine($"Self-extracting archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a set of Windows Imaging Format (WIM) files as a single executable that users can run to extract the images without installing additional software.
 * 2. When automating deployment scripts that must package first‑image WIM files into a self‑extracting installer for offline installation scenarios.
 * 3. When creating backup utilities that bundle critical WIM snapshots into an EXE for easy storage and later restoration on any Windows machine.
 * 4. When delivering diagnostic tools that require the first WIM image to be extracted on the target system via a double‑clickable executable.
 * 5. When simplifying file transfer to non‑technical users by converting multiple WIM files into a single self‑extracting program that handles extraction automatically.
 */
