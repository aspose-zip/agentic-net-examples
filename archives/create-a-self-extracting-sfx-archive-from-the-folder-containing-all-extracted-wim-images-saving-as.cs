// HOW-TO: Create Self‑Extracting EXE from WIM Image Folder in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input folder containing extracted WIM images
            string inputFolder = @"C:\WimImages";
            // Hardcoded output path for the self‑extracting executable
            string outputPath = @"C:\Output\AllWimImagesSfx.exe";

            // Verify the input folder exists
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add all files from the input folder (recursively)
                DirectoryInfo dirInfo = new DirectoryInfo(inputFolder);
                archive.CreateEntries(dirInfo);

                // Configure self‑extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                SelfExtractorOptions sfxOptions = new SelfExtractorOptions();
                // Example: set a default extraction path (optional)
                // sfxOptions.ExtractPath = @"%TEMP%";
                saveOptions.SelfExtractorOptions = sfxOptions;

                // Save the archive as a self‑extracting executable
                archive.Save(outputPath, saveOptions);
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
 * 1. When you need to distribute a set of extracted Windows Imaging Format (WIM) files as a single executable that users can run to extract them automatically.
 * 2. When you want to bundle deployment scripts and resources from a folder into a self‑extracting archive for easy installation on client machines.
 * 3. When you need to create a portable installer that includes all files from a directory without requiring the end user to have a zip utility.
 * 4. When automating backup of configuration files into a self‑extracting executable that can be run to restore the original folder structure.
 * 5. When delivering software updates that consist of multiple files and you want the update package to extract itself without additional tools.
 */
