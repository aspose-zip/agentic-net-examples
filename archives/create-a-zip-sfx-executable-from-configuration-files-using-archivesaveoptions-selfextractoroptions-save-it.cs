// HOW-TO: Create Self-Extracting ZIP Executable With AutoExtract Switch In C# (Aspose.ZIP for .NET)
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
            // Input directory containing configuration files
            string inputDir = @"C:\ConfigFiles";
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Output self-extracting archive path
            string sfxPath = @"C:\Output\ConfigArchive.exe";
            Directory.CreateDirectory(Path.GetDirectoryName(sfxPath));

            // Create the archive and add all files from the input directory
            using (Archive archive = new Archive())
            {
                archive.CreateEntries(new DirectoryInfo(inputDir));

                // Configure self-extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save the self-extracting archive
                archive.Save(sfxPath, saveOptions);
            }

            // Write an invocation file with the -autoExtract switch
            string invokeFilePath = @"C:\Output\RunSfx.txt";
            Directory.CreateDirectory(Path.GetDirectoryName(invokeFilePath));
            using (StreamWriter writer = new StreamWriter(invokeFilePath, false, Encoding.UTF8))
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
 * 1. When you need to package configuration files into a single executable that can be run on client machines without requiring a separate unzip tool.
 * 2. When you want to distribute software settings as a self‑extracting archive that automatically extracts to the target folder using the -autoExtract command line option.
 * 3. When you must generate a portable installer for internal tools and include a script file that launches the SFX with the appropriate switches.
 * 4. When you are automating deployment pipelines and need to create a self‑extracting archive on the fly without invoking it during the build.
 * 5. When you need to store the command line invocation for later use, such as logging or passing to another process, while keeping the SFX creation separate.
 */
