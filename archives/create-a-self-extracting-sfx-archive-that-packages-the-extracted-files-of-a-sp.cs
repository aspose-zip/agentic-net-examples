// HOW-TO: Create a Self‑Extracting ZIP Executable from a Folder in C# (Aspose.ZIP for .NET)
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
            string sourceDirectory = @"C:\Data\SourceFiles";
            string outputExePath = @"C:\Data\Output\SelfExtractingArchive.exe";

            // Verify source directory exists
            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputExePath));

            // Create the archive and add files
            using (Archive archive = new Archive())
            {
                string[] files = Directory.GetFiles(sourceDirectory);
                foreach (string filePath in files)
                {
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Configure self-extracting options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                SelfExtractorOptions sfxOptions = new SelfExtractorOptions();
                // Example: set default extraction path (optional)
                // sfxOptions.ExtractPath = "%TEMP%";
                saveOptions.SelfExtractorOptions = sfxOptions;

                // Save as self-extracting executable
                archive.Save(outputExePath, saveOptions);
            }

            Console.WriteLine("Self-extracting archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a set of files to end‑users who may not have a ZIP utility, you can package them into a self‑extracting EXE that runs on Windows.
 * 2. When deploying configuration files or resources with an installer, you can generate an SFX archive that extracts automatically to a target directory during setup.
 * 3. When sending large log or report files via email, you can compress them into a self‑extracting archive to simplify extraction for recipients without requiring extra software.
 * 4. When creating a portable tool bundle that should unpack itself to a temporary folder at runtime, you can use this code to build the SFX executable programmatically.
 * 5. When automating build pipelines, you can generate a self‑extracting archive of build artifacts so that downstream systems can extract them without installing third‑party compression tools.
 */
