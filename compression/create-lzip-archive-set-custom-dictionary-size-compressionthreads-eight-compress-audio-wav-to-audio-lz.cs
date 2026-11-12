// HOW-TO: Create Lzip Archive and Compress WAV File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "audio.wav";
            string outputPath = "audio.lz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? string.Empty);

            // Create Lzip archive and compress the file
            using (LzipArchive archive = new LzipArchive())
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
 * 1. When you need to reduce the size of a large WAV audio file for faster network transfer by creating an Lzip archive in a .NET application.
 * 2. When building a backup utility that stores raw audio recordings in Lzip format to save disk space on Windows servers.
 * 3. When implementing a preprocessing step in a media processing pipeline that compresses input WAV files before feeding them to downstream services.
 * 4. When developing a desktop tool that lets users archive their sound samples into a single .lz file for easy distribution.
 * 5. When automating archival of audio logs in a C# script to meet storage compliance requirements using Lzip compression.
 */
