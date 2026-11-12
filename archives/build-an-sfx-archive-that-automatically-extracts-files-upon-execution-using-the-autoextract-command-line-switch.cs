// HOW-TO: Create Self-Extracting ZIP Archive With Auto-Extract Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Define input file and verify its existence
            string dataDir = @"C:\Data";
            string inputFile = Path.Combine(dataDir, "sample.txt");
            if (!File.Exists(inputFile))
            {
                Console.Error.WriteLine($"File not found: {inputFile}");
                return;
            }

            // Define output SFX path and ensure the directory exists
            string outputDir = @"C:\Output";
            string sfxPath = Path.Combine(outputDir, "MyArchive.exe");
            Directory.CreateDirectory(Path.GetDirectoryName(sfxPath));

            // Configure self-extractor options (default behavior)
            SelfExtractorOptions sfxOptions = new SelfExtractorOptions();

            // Set save options with the self-extractor configuration
            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
            saveOptions.SelfExtractorOptions = sfxOptions;

            // Create the archive, add the file, and save as a self-extracting executable
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("sample.txt", inputFile);
                archive.Save(sfxPath, saveOptions);
            }

            Console.WriteLine($"Self-extracting archive created at {sfxPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a single executable that automatically unpacks configuration files on a user's machine without requiring a separate unzip tool.
 * 2. When you want to embed a text file or log within a self‑extracting installer for quick deployment in corporate environments.
 * 3. When you are building a backup utility that creates an SFX archive so end users can restore files by simply running the generated .exe.
 * 4. When you need to send confidential documents that automatically extract to a temporary folder, reducing the steps for non‑technical recipients.
 * 5. When you are automating software packaging and want the archive to launch and extract its contents as part of a CI/CD pipeline.
 */
