// HOW-TO: Create Split ZIP of Multiple Audio Files with 200 KiB Volumes in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output directories
            string inputDir = "input";
            string outputDir = "output";

            // List of audio files to add
            string[] audioFiles = new string[]
            {
                "song1.mp3",
                "song2.wav",
                "song3.flac"
            };

            // Verify each input file exists
            foreach (string fileName in audioFiles)
            {
                string inputPath = Path.Combine(inputDir, fileName);
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            string outputBasePath = Path.Combine(outputDir, "audio");
            Directory.CreateDirectory(outputBasePath);

            // Create a new ZIP archive and add audio files
            using (Archive archive = new Archive())
            {
                foreach (string fileName in audioFiles)
                {
                    string inputPath = Path.Combine(inputDir, fileName);
                    FileInfo fileInfo = new FileInfo(inputPath);
                    archive.CreateEntry(fileName, fileInfo);
                }

                // Configure split options: 200 KiB per volume
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(200 * 1024);

                // Save the archive as split ZIP segments with base name 'audio'
                archive.SaveSplit(outputBasePath, saveOptions);
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
 * 1. When you need to package several music tracks into a ZIP that can be transferred over email or file‑size‑limited services, splitting the archive into 200 KB parts.
 * 2. When an application must generate portable backup archives of audio assets for distribution to devices with limited storage, using C# to create split ZIP volumes.
 * 3. When a game developer wants to bundle sound effects into a multi‑volume ZIP for incremental download during installation.
 * 4. When a media server script needs to archive large collections of audio files into manageable chunks for archival storage or cloud upload.
 * 5. When a Windows service automates the creation of split ZIP archives of daily audio recordings to comply with corporate file‑size policies.
 */
