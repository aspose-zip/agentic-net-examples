// HOW-TO: Create Self-Extracting EXE Archive With Overwrite Option In C# (Aspose.ZIP for .NET)
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
            string dataDir = @"C:\Data";
            string[] inputFiles = new string[]
            {
                Path.Combine(dataDir, "file1.txt"),
                Path.Combine(dataDir, "file2.txt")
            };

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            string outputPath = Path.Combine(dataDir, "MySelfExtractingArchive.exe");
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            SelfExtractorOptions sfxOptions = new SelfExtractorOptions();

            ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
            saveOptions.SelfExtractorOptions = sfxOptions;

            using (Archive archive = new Archive())
            {
                foreach (string inputPath in inputFiles)
                {
                    string entryName = Path.GetFileName(inputPath);
                    archive.CreateEntry(entryName, inputPath);
                }

                archive.Save(outputPath, saveOptions);
            }

            Console.WriteLine($"Self-extracting archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a set of configuration files to end users as a single executable that extracts and overwrites existing files automatically.
 * 2. When deploying updates for a desktop application and want the installer to replace older resource files during self‑extraction without prompting the user.
 * 3. When sending log files to support staff and require a self‑extracting package that can overwrite any previously extracted logs on the target machine.
 * 4. When building a portable tool bundle that users can run to extract utilities, ensuring any existing copies are silently overwritten.
 * 5. When automating backup restoration by generating an SFX archive that restores multiple files and forces them to replace current files on the destination system.
 */
