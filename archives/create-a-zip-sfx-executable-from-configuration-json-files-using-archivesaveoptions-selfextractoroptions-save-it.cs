// HOW-TO: Create Self‑Extracting ZIP Executable With AutoExtract Switch In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing JSON configuration files
            string inputDirectory = @"C:\Data\Config";

            // List of configuration files to include in the SFX archive
            string configFile1 = Path.Combine(inputDirectory, "appsettings.json");
            string configFile2 = Path.Combine(inputDirectory, "config.json");

            // Verify each input file exists
            if (!File.Exists(configFile1))
            {
                Console.Error.WriteLine($"File not found: {configFile1}");
                return;
            }
            if (!File.Exists(configFile2))
            {
                Console.Error.WriteLine($"File not found: {configFile2}");
                return;
            }

            // Hardcoded output directory and SFX archive path
            string outputDirectory = @"C:\Output";
            string sfxPath = Path.Combine(outputDirectory, "ConfigArchive.exe");

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(sfxPath));

            // Create the ZIP archive and add the configuration files
            using (Archive archive = new Archive())
            {
                archive.CreateEntry(Path.GetFileName(configFile1), configFile1);
                archive.CreateEntry(Path.GetFileName(configFile2), configFile2);

                // Configure self‑extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save the archive as a self‑extracting executable
                archive.Save(sfxPath, saveOptions);
            }

            // Write an invocation file that runs the SFX with the -autoExtract switch
            string invocationFilePath = Path.Combine(outputDirectory, "run_sfx.txt");
            Directory.CreateDirectory(Path.GetDirectoryName(invocationFilePath));
            using (StreamWriter writer = new StreamWriter(invocationFilePath, false, Encoding.UTF8))
            {
                writer.WriteLine($"\"{sfxPath}\" -autoExtract");
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
 * 1. When you need to package multiple JSON configuration files into a single self‑extracting EXE for easy distribution to client machines without requiring a separate unzip tool.
 * 2. When automating deployment scripts that must deliver configuration bundles and invoke them with the -autoExtract switch to silently extract files during installation.
 * 3. When creating a portable backup of application settings that can be run on any Windows system to restore configurations without manual extraction steps.
 * 4. When building a custom installer that includes configuration files and wants to generate the SFX archive programmatically using Aspose.Zip in a C# build process.
 * 5. When you want to generate an invocation script that runs the SFX executable with predefined runtime options, such as -autoExtract, without actually executing the archive during creation.
 */
