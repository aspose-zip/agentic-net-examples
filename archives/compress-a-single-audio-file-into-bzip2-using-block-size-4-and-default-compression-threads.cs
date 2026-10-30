// HOW-TO: Compress a Single Audio File to BZIP2 Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input/audio.mp3";
            string outputPath = "output/audio.bz2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open output stream for the BZIP2 archive
            using (FileStream outStream = File.Open(outputPath, FileMode.Create))
            {
                // Configure BZIP2 compression (default settings)
                Bzip2CompressionSettings bzip2Settings = new Bzip2CompressionSettings();

                // Apply compression settings to the archive
                ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(bzip2Settings);

                // Create the archive and add the audio file
                using (Archive archive = new Archive(entrySettings))
                {
                    // Add entry using the source file path
                    archive.CreateEntry(Path.GetFileName(inputPath), inputPath);
                    // Save the archive to the output stream
                    archive.Save(outStream);
                }
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
 * 1. When you need to reduce the size of an MP3 before uploading it to a bandwidth‑limited server, you can use this code to create a BZIP2 archive in C#.
 * 2. When a desktop application must store audio assets in a compact, single‑file format for offline distribution, the snippet shows how to generate a .bz2 file with Aspose.Zip.
 * 3. When integrating a backup routine that archives individual media files into BZIP2 to save disk space, this example demonstrates the required C# steps.
 * 4. When preparing audio logs for long‑term archival compliance, you can compress each log file into a BZIP2 container using the provided code.
 * 5. When building a C# utility that converts raw audio files into a portable compressed format for cross‑platform sharing, the sample illustrates creating and saving a BZIP2 entry.
 */
