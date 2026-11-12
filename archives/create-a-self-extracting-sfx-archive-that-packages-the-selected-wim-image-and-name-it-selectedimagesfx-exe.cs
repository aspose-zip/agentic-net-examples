// HOW-TO: Create Self‑Extracting EXE for Selected WIM Image Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input WIM image and output SFX executable paths
            string inputPath = @"C:\Images\selected.wim";
            string outputPath = @"C:\Output\SelectedImageSfx.exe";

            // Verify the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure self-extractor options
            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
            saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

            // Create the archive, add the WIM image, and save as a self‑extracting EXE
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("selected.wim", inputPath);
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
 * 1. When you need to distribute a Windows Imaging Format (WIM) file to end users without requiring them to run a separate extraction tool.
 * 2. When you want to embed a single WIM image inside a portable executable that automatically extracts itself on execution.
 * 3. When you are building an installer that must unpack a selected system image on target machines without installing additional compression utilities.
 * 4. When you need to programmatically generate a self‑extracting archive for backup or deployment scripts in a C# application.
 * 5. When you want to simplify the delivery of a large WIM file by packaging it as a single .exe that can be run directly from a network share.
 */
