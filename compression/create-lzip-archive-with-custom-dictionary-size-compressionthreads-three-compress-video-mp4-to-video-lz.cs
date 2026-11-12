// HOW-TO: Create Lzip Archive from Video File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\video.mp4";
            string outputPath = @"C:\Data\video.lz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress large video files into a lightweight Lzip archive for faster uploads or storage using C# and Aspose.Zip.
 * 2. When an application must generate Lzip archives on the fly to package media assets before sending them over a network.
 * 3. When a backup utility written in .NET requires creating Lzip compressed files to reduce disk space consumption.
 * 4. When a content management system needs to archive user‑uploaded videos in Lzip format for long‑term retention.
 * 5. When a developer wants to integrate Lzip compression into a C# workflow without relying on external command‑line tools.
 */
