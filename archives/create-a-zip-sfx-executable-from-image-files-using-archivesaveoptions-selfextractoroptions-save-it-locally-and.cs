// HOW-TO: Create Self‑Extracting ZIP Executable from PNG Images in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputDir = @"C:\Images";
            string outputDir = @"C:\Output";
            string outputSfxPath = Path.Combine(outputDir, "ImagesSelfExtract.exe");
            string invocationFilePath = Path.Combine(outputDir, "run_sfx.txt");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputSfxPath));

            // Gather image files (PNG format)
            string[] imageFiles = Directory.GetFiles(inputDir, "*.png");

            // Validate each input file exists
            List<string> validFiles = new List<string>();
            foreach (string filePath in imageFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    continue;
                }
                validFiles.Add(filePath);
            }

            // Create the ZIP archive and add image entries
            using (Archive archive = new Archive())
            {
                foreach (string filePath in validFiles)
                {
                    // Add each image file as an entry with its file name
                    archive.CreateEntry(Path.GetFileName(filePath), filePath);
                }

                // Configure self-extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save the archive as a self‑extracting executable
                archive.Save(outputSfxPath, saveOptions);
            }

            // Write a local invocation file containing the -autoExtract switch
            string invocationContent = $"{Path.GetFileName(outputSfxPath)} -autoExtract";
            File.WriteAllText(invocationFilePath, invocationContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a set of PNG images to end users as a single executable that extracts the files automatically.
 * 2. When you want to embed image resources in a self‑extracting installer without requiring the user to have a separate ZIP utility.
 * 3. When you must generate a portable archive that can be launched from a script using the -autoExtract switch for silent extraction.
 * 4. When you are automating a build process that packages product screenshots into a self‑extracting executable for QA testing.
 * 5. When you need to create a self‑extracting archive on a server and provide a separate command file that triggers extraction without running the EXE directly.
 */
