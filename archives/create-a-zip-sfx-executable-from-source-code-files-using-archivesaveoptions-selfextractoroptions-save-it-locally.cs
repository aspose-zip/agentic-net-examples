// HOW-TO: Create Self-Extracting ZIP Of C# Source Files With Auto Extract Switches In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string sourceDir = @"C:\SourceCode";
            string outputSfxPath = @"C:\Output\MyApp.sfx";
            string invocationFilePath = @"C:\Output\MyApp.invocation.txt";

            // Validate source directory
            if (!Directory.Exists(sourceDir))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDir}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputSfxPath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add all .cs files from the source directory
                string[] sourceFiles = Directory.GetFiles(sourceDir, "*.cs", SearchOption.AllDirectories);
                foreach (string filePath in sourceFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Configure self-extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save the self-extracting archive
                archive.Save(outputSfxPath, saveOptions);
            }

            // Write invocation file with runtime switches
            string switches = "-autoExtract -forceOverwrite";
            File.WriteAllText(invocationFilePath, switches);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a C# project's source code as a single executable that extracts itself on the target machine without manual steps.
 * 2. When you want to automate deployment of source files by generating a self‑extracting archive that overwrites existing files during extraction.
 * 3. When you must package multiple .cs files into a portable SFX for offline code review or sharing with collaborators.
 * 4. When you need to create an installer‑like archive that can be launched with predefined command‑line switches for silent extraction.
 * 5. When you are building a build‑pipeline step that produces a self‑extracting ZIP for backup or versioning without executing the extraction process.
 */
