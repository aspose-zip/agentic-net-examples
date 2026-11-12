// HOW-TO: Compress a JPEG Image to BZIP2 with Default Settings in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.jpg";
            string outputPath = "output\\compressed.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Bzip2CompressionSettings bzip2Settings = new Bzip2CompressionSettings();

            using (FileStream outStream = File.Open(outputPath, FileMode.Create))
            using (Archive archive = new Archive(new ArchiveEntrySettings(bzip2Settings)))
            {
                archive.CreateEntry("image.jpg", inputPath);
                archive.Save(outStream);
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
 * 1. When you need to reduce the size of a single photo before uploading it to a web service that only accepts BZIP2 archives.
 * 2. When you want to store a JPEG in a BZIP2 file to save disk space while preserving the original filename for later extraction.
 * 3. When an automated backup script must compress individual image assets using C# and Aspose.Zip without configuring custom compression levels.
 * 4. When integrating a .NET application with a legacy system that processes BZIP2‑compressed image streams.
 * 5. When creating a lightweight, portable archive of a picture for distribution over low‑bandwidth networks using Aspose.Zip’s Bzip2CompressionSettings.
 */
