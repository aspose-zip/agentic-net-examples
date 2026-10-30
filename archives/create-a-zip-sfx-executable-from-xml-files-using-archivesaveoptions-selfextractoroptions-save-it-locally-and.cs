// HOW-TO: Create Self-Extracting Zip From XML Files With AutoExtract Switch In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing XML files
            string dataDir = @"C:\Data\XmlFiles";

            // Verify input directory exists
            if (!Directory.Exists(dataDir))
            {
                Console.Error.WriteLine($"Directory not found: {dataDir}");
                return;
            }

            // Get all XML files in the directory
            string[] xmlFiles = Directory.GetFiles(dataDir, "*.xml");

            // Verify each XML file exists
            foreach (string filePath in xmlFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Hardcoded output directory and SFX file path
            string outputDir = @"C:\Output";
            Directory.CreateDirectory(outputDir);
            string sfxPath = Path.Combine(outputDir, "MyArchive.exe");

            // Create the ZIP archive and add XML files
            using (Archive archive = new Archive())
            {
                foreach (string filePath in xmlFiles)
                {
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Configure self-extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save as self-extracting executable
                archive.Save(sfxPath, saveOptions);
            }

            // Write a local invocation file with -autoExtract switch
            string invocationFilePath = Path.Combine(outputDir, "run_sfx.cmd");
            Directory.CreateDirectory(Path.GetDirectoryName(invocationFilePath));
            string commandLine = $"\"{sfxPath}\" -autoExtract";
            File.WriteAllText(invocationFilePath, commandLine);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a set of XML configuration files into a single executable that can be distributed to end users without requiring them to install a ZIP utility.
 * 2. When you want to automate the deployment of XML data by creating a self‑extracting archive that extracts automatically using the -autoExtract command‑line switch.
 * 3. When you must generate a portable installer for XML‑based templates that can be run from a command script on any Windows machine.
 * 4. When you are building a build‑pipeline step that creates a self‑extracting archive of XML logs for easy archiving and later extraction without manual intervention.
 * 5. When you need to provide a simple double‑click solution for non‑technical users to unpack XML files, while also supplying a separate .cmd file that invokes the SFX with silent extraction.
 */
