// HOW-TO: Create Split ZIP Archive of Audio Files with 110 KiB Parts in C# (Aspose.ZIP for .NET)
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
            string inputDir = "input";
            string outputDir = "output";

            Directory.CreateDirectory(outputDir);

            string[] audioFiles = new string[]
            {
                Path.Combine(inputDir, "sample1.mp3"),
                Path.Combine(inputDir, "sample2.wav"),
                Path.Combine(inputDir, "sample3.flac")
            };

            foreach (string filePath in audioFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            using (Archive archive = new Archive())
            {
                foreach (string filePath in audioFiles)
                {
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("samples", 110 * 1024);

                archive.SaveSplit(outputDir, saveOptions);
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
 * 1. When you need to package several audio tracks into a ZIP that is automatically split into 110 KB chunks for distribution on media with size constraints.
 * 2. When an application must upload audio files to a web service that only accepts files smaller than 120 KB, requiring the archive to be pre‑split before transmission.
 * 3. When backing up a music library to a file system that imposes a maximum file size, using C# to create split ZIP segments that fit the limit.
 * 4. When sending audio samples via email where each attachment must stay under a specific size, generating multi‑part ZIP files directly from code.
 * 5. When preparing audio assets for a game installer that expects separate ZIP parts, creating split archives programmatically to simplify the build process.
 */
