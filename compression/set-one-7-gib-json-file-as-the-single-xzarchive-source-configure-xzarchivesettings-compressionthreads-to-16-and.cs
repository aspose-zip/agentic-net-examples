// HOW-TO: Compress Large JSON File to XZ with Multi‑Threading in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;
using Aspose.Zip.Xz.Settings;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\large.json";
            string outputPath = @"C:\Output\parallel.xz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure XZ compression settings
            XzArchiveSettings settings = new XzArchiveSettings();
            settings.CompressionThreads = 16;

            // Create XZ archive with the specified settings
            using (XzArchive archive = new XzArchive(settings))
            {
                // Set the source file for compression
                archive.SetSource(inputPath);

                // Save the compressed archive
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
 * 1. When you need to reduce storage space for a multi‑gigabyte JSON dataset before archiving it on a server.
 * 2. When you want to speed up XZ compression by utilizing all available CPU cores for a large file in a .NET application.
 * 3. When you must generate an XZ archive that can be later decompressed by standard tools on Linux or Windows.
 * 4. When you are building a data‑pipeline that transfers huge JSON logs and want to minimize network bandwidth usage.
 * 5. When you need to programmatically verify that a source file exists and create the output directory before compressing it in C#.
 */
