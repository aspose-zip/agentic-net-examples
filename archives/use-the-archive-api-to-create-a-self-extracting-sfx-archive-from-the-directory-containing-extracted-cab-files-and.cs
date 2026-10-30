// HOW-TO: Create Self‑Extracting EXE From CAB Files Directory Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing extracted CAB files
            string inputDir = @"C:\Temp\ExtractedCab";
            // Hardcoded output self‑extracting executable path
            string outputPath = @"C:\Temp\ApiCabSfx.exe";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure self‑extractor options (default settings)
            SelfExtractorOptions sfxOptions = new SelfExtractorOptions();

            // Configure archive save options with SFX settings
            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
            saveOptions.SelfExtractorOptions = sfxOptions;

            // Create archive and add all files from the input directory
            using (Archive archive = new Archive())
            {
                // Add all entries from the directory (including subfolders)
                archive.CreateEntries(new DirectoryInfo(inputDir));

                // Save as a self‑extracting executable
                archive.Save(outputPath, saveOptions);
            }

            Console.WriteLine("Self‑extracting archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a set of extracted CAB files into a single executable that users can run to automatically extract the contents on any Windows machine.
 * 2. When you want to distribute driver or update files that were originally in a CAB archive but require a self‑extracting installer for easier deployment.
 * 3. When automating build pipelines to convert extracted CAB resources into a portable SFX executable for offline installation scenarios.
 * 4. When creating a custom setup tool that bundles multiple CAB‑derived components into one executable without relying on third‑party installers.
 * 5. When simplifying the delivery of pre‑extracted files to end‑users by generating a self‑extracting archive programmatically in a C# application.
 */
