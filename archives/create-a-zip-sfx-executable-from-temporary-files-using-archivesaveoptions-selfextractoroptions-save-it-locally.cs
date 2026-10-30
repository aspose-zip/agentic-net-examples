// HOW-TO: Create Self-Extracting ZIP Executable With Auto-Extract Switches In C# (Aspose.ZIP for .NET)
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
            // Define temporary directory and ensure it exists
            string tempDir = Path.Combine(Path.GetTempPath(), "AsposeZipTemp");
            Directory.CreateDirectory(tempDir);

            // Create sample files
            string file1Path = Path.Combine(tempDir, "file1.txt");
            string file2Path = Path.Combine(tempDir, "file2.txt");
            File.WriteAllText(file1Path, "This is the content of file 1.");
            File.WriteAllText(file2Path, "This is the content of file 2.");

            // Verify input files exist
            if (!File.Exists(file1Path))
            {
                Console.Error.WriteLine($"File not found: {file1Path}");
                return;
            }
            if (!File.Exists(file2Path))
            {
                Console.Error.WriteLine($"File not found: {file2Path}");
                return;
            }

            // Define output SFX executable path and ensure its directory exists
            string sfxOutputPath = Path.Combine(Directory.GetCurrentDirectory(), "MySelfExtracting.exe");
            Directory.CreateDirectory(Path.GetDirectoryName(sfxOutputPath));

            // Create archive and add entries
            using (Archive archive = new Archive())
            {
                archive.CreateEntry(Path.GetFileName(file1Path), file1Path);
                archive.CreateEntry(Path.GetFileName(file2Path), file2Path);

                // Configure self-extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save as self-extracting executable
                archive.Save(sfxOutputPath, saveOptions);
            }

            // Write invocation file with runtime switches
            string invocationFilePath = Path.Combine(Directory.GetCurrentDirectory(), "run_sfx.bat");
            Directory.CreateDirectory(Path.GetDirectoryName(invocationFilePath));
            string invocationContent = $"\"{sfxOutputPath}\" -autoExtract -forceOverwrite";
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
 * 1. When you need to distribute a set of generated files as a single executable that automatically extracts them on the target machine without user interaction.
 * 2. When you want to create a self‑extracting installer from temporary files during a build process and control extraction behavior with switches like -autoExtract and -forceOverwrite.
 * 3. When you must package confidential logs or reports into a portable SFX archive that can be run on any Windows system without requiring the Aspose.Zip library installed.
 * 4. When an automated deployment script requires a self‑extracting ZIP that overwrites existing files and extracts silently as part of a CI/CD pipeline.
 * 5. When you need to generate a temporary SFX executable for testing extraction logic and store the command‑line options in a separate invocation file for later execution.
 */
