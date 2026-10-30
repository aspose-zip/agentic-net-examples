// HOW-TO: Create Self‑Extracting ZIP Executable With Auto‑Extract Switches In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output directories
            string inputDir = @"C:\Data\Input";
            string outputDir = @"C:\Data\Output";

            // Input files to include in the SFX archive
            string filePath1 = Path.Combine(inputDir, "document1.txt");
            string filePath2 = Path.Combine(inputDir, "image1.png");

            // Verify that each input file exists
            if (!File.Exists(filePath1))
            {
                Console.Error.WriteLine($"File not found: {filePath1}");
                return;
            }
            if (!File.Exists(filePath2))
            {
                Console.Error.WriteLine($"File not found: {filePath2}");
                return;
            }

            // Path for the self‑extracting executable
            string sfxPath = Path.Combine(outputDir, "MyArchive.exe");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(sfxPath));

            // Create the archive and add entries
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("document1.txt", filePath1);
                archive.CreateEntry("image1.png", filePath2);

                // Configure self‑extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save the archive as a self‑extracting executable
                archive.Save(sfxPath, saveOptions);
            }

            // Create a local invocation file with runtime switches
            string invocationFilePath = Path.Combine(outputDir, "run_sfx.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(invocationFilePath));
            string invocationContent = "-autoExtract -forceOverwrite";
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
 * 1. When you need to distribute multiple files as a single executable that automatically extracts on the target machine without user interaction.
 * 2. When you want to generate a separate invocation file containing runtime switches such as -autoExtract and -forceOverwrite to control the self‑extractor’s behavior.
 * 3. When you must programmatically package local documents and images into a self‑extracting archive for easy deployment in Windows environments.
 * 4. When you require the SFX archive to be saved to a specific output directory as part of an automated C# build or deployment pipeline.
 * 5. When you need a repeatable process that creates the self‑extracting executable and its configuration file without actually executing the extractor during the build.
 */
