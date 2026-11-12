// HOW-TO: Create Self-Extracting ZIP Executable From Audio Files In C# (Aspose.ZIP for .NET)
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
            string inputDirectory = @"C:\AudioFiles";
            string outputPath = @"C:\Output\AudioArchiveSFX.exe";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] audioFiles = Directory.GetFiles(inputDirectory, "*.*", SearchOption.TopDirectoryOnly);
            if (audioFiles.Length == 0)
            {
                Console.Error.WriteLine("No audio files found in the input directory.");
                return;
            }

            using (Archive archive = new Archive())
            {
                foreach (string filePath in audioFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    FileInfo fileInfo = new FileInfo(filePath);
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, fileInfo);
                }

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

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
 * 1. When you need to distribute a collection of music tracks to users who may not have a zip utility, you can bundle them into a self‑extracting EXE so they can run a single file to extract the audio.
 * 2. When deploying audio assets for a Windows desktop application, you can package the files as a self‑extracting archive that the installer can launch without requiring additional extraction tools.
 * 3. When sending audio recordings via email and want to avoid attachment size limits, you can compress them into a self‑extracting executable that automatically extracts the files on the recipient’s machine.
 * 4. When creating a portable demo of a sound library, you can generate a self‑extracting archive in C# that users can execute on any Windows PC to instantly access the audio files.
 * 5. When automating a build pipeline that prepares audio resources for end‑users, you can use Aspose.Zip to programmatically create a self‑extracting ZIP so the build script produces a ready‑to‑run installer.
 */
