// HOW-TO: Create Lzip Archive with Custom Dictionary and 4 Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\video.mov";
            string outputPath = @"C:\Data\video.lz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure Lzip archive settings
            LzipArchiveSettings settings = new LzipArchiveSettings(32 * 1024 * 1024, 4);

            // Create Lzip archive with the specified settings
            using (LzipArchive archive = new LzipArchive(settings))
            {
                // Set the source file to be compressed
                archive.SetSource(inputPath);

                // Save the archive to the output path
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
 * 1. When you need to compress large video files into a smaller Lzip archive using a specific dictionary size for better compression efficiency.
 * 2. When you want to speed up compression of media assets on a server by leveraging multiple CPU cores with four compression threads.
 * 3. When you must generate Lzip files compatible with Unix tools for cross‑platform distribution of MOV videos.
 * 4. When you need to programmatically ensure the output directory exists before creating an archive in a .NET application.
 * 5. When you want to handle missing source files gracefully by checking existence and reporting errors in a C# compression utility.
 */
