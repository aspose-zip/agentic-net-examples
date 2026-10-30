// HOW-TO: Create Self-Extracting ZIP Executable for Video Files in C# (Aspose.ZIP for .NET)
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
            string inputDir = @"C:\Videos";
            string outputExePath = @"C:\Output\VideosSelfExtract.exe";
            string invocationFilePath = @"C:\Output\RunSfx.txt";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputExePath));

            // Verify input directory exists
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Collect video files
            string[] videoFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly);
            string[] allowedExt = new string[] { ".mp4", ".avi", ".mkv", ".mov" };

            using (Archive archive = new Archive())
            {
                foreach (string filePath in videoFiles)
                {
                    string ext = Path.GetExtension(filePath).ToLowerInvariant();
                    bool isVideo = false;
                    foreach (string aExt in allowedExt)
                    {
                        if (ext == aExt)
                        {
                            isVideo = true;
                            break;
                        }
                    }
                    if (!isVideo)
                    {
                        continue;
                    }

                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Configure self-extractor options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.SelfExtractorOptions = new SelfExtractorOptions();

                // Save as SFX executable
                archive.Save(outputExePath, saveOptions);
            }

            // Write invocation file with -autoExtract switch
            using (StreamWriter writer = new StreamWriter(invocationFilePath, false))
            {
                writer.WriteLine($"{Path.GetFileName(outputExePath)} -autoExtract");
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
 * 1. When you need to distribute a collection of video files as a single executable that automatically extracts the videos on any Windows machine without requiring a separate archive utility.
 * 2. When you want to embed video assets into an installer and provide a self‑extracting archive that can be launched from a script or command line with predefined switches.
 * 3. When you must generate a portable SFX file programmatically in a C# application for secure offline delivery of media content while keeping extraction parameters in a separate configuration file.
 * 4. When you are building a media‑sharing tool that creates a self‑extracting archive for large video files and stores the command‑line options (such as -autoExtract) for later automated deployment.
 * 5. When you need to automate the creation of a self‑extracting video bundle for backup or archiving purposes, ensuring the archive can be extracted silently on any Windows system.
 */
