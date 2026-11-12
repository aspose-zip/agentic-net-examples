// HOW-TO: Compress FLAC to XZ With Multi‑Threaded Settings In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input/audio_collection.flac";
            string outputPath = "output/collection.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
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
 * 1. When you need to reduce the size of high‑quality audio files for faster download or storage, you can compress a .flac file into an .xz archive using Aspose.Zip in C#.
 * 2. When building a backup system that stores large media collections efficiently, you can programmatically create XZ archives of audio files with configurable compression threads.
 * 3. When developing a cross‑platform media distribution tool that requires a single compressed package, you can use the XzArchive class to bundle and compress FLAC tracks before sending them to clients.
 * 4. When optimizing server‑side processing time for bulk audio compression, you can set the CompressionThreads property to use multiple CPU cores while creating XZ archives in .NET.
 * 5. When integrating archival functionality into a .NET application that must preserve lossless audio quality while minimizing disk usage, you can convert .flac files to .xz format with Aspose.Zip.
 */
