// HOW-TO: Create Self-Extracting ZIP Executable With Auto Extract Switches In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing scripts
            string inputDirectory = @"C:\Scripts";

            // Hardcoded output path for the self-extracting executable
            string outputSfxPath = @"C:\Output\ScriptsSelfExtract.exe";

            // Hardcoded path for the invocation file
            string invocationFilePath = @"C:\Output\RunScriptsSfx.cmd";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputSfxPath));

            // Create ZIP archive and add all files from the input directory
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);
                archive.CreateEntries(dirInfo);

                // Configure self-extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save as self-extracting executable
                archive.Save(outputSfxPath, saveOptions);
            }

            // Ensure directory for the invocation file exists
            Directory.CreateDirectory(Path.GetDirectoryName(invocationFilePath));

            // Write the invocation command with runtime switches
            using (StreamWriter writer = new StreamWriter(invocationFilePath, false))
            {
                writer.WriteLine($"\"{outputSfxPath}\" -autoExtract -forceOverwrite");
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
 * 1. When you need to distribute a set of scripts as a single executable that extracts itself automatically on the target machine.
 * 2. When you want to package deployment scripts into a self‑extracting file to simplify installation without requiring users to run a separate unzip tool.
 * 3. When you must generate a command file that launches the SFX with predefined switches such as -autoExtract and -forceOverwrite for silent, overwrite‑friendly extraction.
 * 4. When you are automating build pipelines and need to create a portable archive of build artifacts that can be extracted on any Windows host with a single click.
 * 5. When you require a reproducible way to bundle configuration files and scripts into an executable for offline delivery or air‑gapped environments.
 */
