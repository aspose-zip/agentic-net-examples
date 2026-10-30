// HOW-TO: Create a TAR.XZ Archive of Multiple Audio Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing audio files
            string inputDirectory = @"C:\AudioFiles";

            // Hardcoded output paths
            string outputTarPath = @"C:\Output\audio.tar";
            string outputXzPath = @"C:\Output\audio.tar.xz";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTarPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputXzPath));

            // List of audio files to include
            string[] audioFiles = new string[]
            {
                Path.Combine(inputDirectory, "song1.mp3"),
                Path.Combine(inputDirectory, "song2.wav"),
                Path.Combine(inputDirectory, "song3.flac")
            };

            // Verify each input file exists
            foreach (string filePath in audioFiles)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Create TAR archive and add entries
            using (TarArchive archive = new TarArchive())
            {
                foreach (string filePath in audioFiles)
                {
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                // Save the TAR archive with XZ compression
                archive.SaveXzCompressed(outputXzPath);
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
 * 1. When you need to bundle several music tracks into a single portable archive for distribution while keeping the file size small, you can use this code to create a .tar.xz package.
 * 2. When backing up a collection of audio recordings to a server that only accepts tar archives with XZ compression, this snippet automates the process in C#.
 * 3. When preparing audio assets for a Linux‑based deployment where .tar.xz is the preferred format, the code lets you generate the archive directly from a .NET application.
 * 4. When you want to archive podcast episodes before uploading them to cloud storage that charges per byte, the XZ‑compressed tar reduces storage costs.
 * 5. When integrating a build pipeline that needs to package generated sound files into a single compressed file for later extraction, this example shows how to do it programmatically.
 */
