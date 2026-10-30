// HOW-TO: Compress JSON File to XZ Archive with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "configuration.json";
            string outputPath = "config.xz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Create XZ archive, set source file, and save the compressed archive
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
 * 1. When you need to reduce the size of a JSON configuration file for faster deployment and store it in an XZ archive using C#.
 * 2. When you want to create a portable, compressed backup of application settings that can be verified with a CRC64 checksum.
 * 3. When your .NET application must package configuration data into a single XZ file before uploading it to a cloud storage service.
 * 4. When you require a reliable way to archive sensitive JSON files with Aspose.Zip XZ compression to meet storage compliance requirements.
 * 5. When automating build pipelines that compress configuration files into XZ format for version‑controlled artifacts.
 */
