// HOW-TO: Create Self-Extracting Zip Executable With AutoExtract Switch In C# (Aspose.ZIP for .NET)
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
            string sourceFolder = @"C:\Data\SourceFolder";
            string outputSfxPath = @"C:\Data\output\MyArchive.exe";
            string invocationFilePath = @"C:\Data\output\run.txt";

            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputSfxPath));

            using (Archive archive = new Archive())
            {
                archive.CreateEntries(sourceFolder);
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();
                archive.Save(outputSfxPath, saveOptions);
            }

            string command = $"\"{outputSfxPath}\" -autoExtract";
            File.WriteAllText(invocationFilePath, command);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a folder of files to end‑users as a single executable that automatically extracts its contents without requiring a separate unzip tool.
 * 2. When you want to embed a self‑extracting archive in an installer package and provide a pre‑generated command line file that runs the SFX with the –autoExtract option.
 * 3. When you must create a portable deployment bundle for a .NET application, compressing all binaries into an SFX that extracts itself to a temporary directory on launch.
 * 4. When you are automating a build pipeline that generates a self‑extracting archive and saves a script file for later remote execution on client machines.
 * 5. When you need to supply a downloadable executable that silently extracts confidential documents, using Aspose.Zip’s SelfExtractorOptions to control the extraction behavior.
 */
