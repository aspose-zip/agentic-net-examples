// HOW-TO: Create Self‑Extracting Archive of Extracted WIM Images in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string wimFilePath = @"C:\Data\sample.wim";
            string extractedImagesDir = @"C:\Data\ExtractedImages";
            string sfxOutputPath = @"C:\Data\WimAllSfx.exe";

            // Validate input WIM file
            if (!File.Exists(wimFilePath))
            {
                Console.Error.WriteLine($"File not found: {wimFilePath}");
                return;
            }

            // Validate extracted images directory
            if (!Directory.Exists(extractedImagesDir))
            {
                Console.Error.WriteLine($"Directory not found: {extractedImagesDir}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(sfxOutputPath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add each extracted image file to the archive
                string[] files = Directory.GetFiles(extractedImagesDir, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Compute the relative path inside the archive
                    string entryName = Path.GetRelativePath(extractedImagesDir, filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Configure self‑extracting options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save the archive as a self‑extracting executable
                archive.Save(sfxOutputPath, saveOptions);
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
 * 1. When you need to distribute multiple extracted Windows Imaging (WIM) files as a single executable that users can run to extract them automatically.
 * 2. When automating deployment scripts that must package extracted image files into a self‑extracting installer for offline installation.
 * 3. When creating a backup utility that bundles all extracted WIM images into one portable .exe for easy storage and transport.
 * 4. When building a custom recovery tool that delivers extracted system images via a self‑extracting archive without requiring separate zip utilities.
 * 5. When simplifying the delivery of extracted WIM components to end‑users who may not have compression software installed.
 */
