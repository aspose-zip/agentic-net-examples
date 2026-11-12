// HOW-TO: Compress JSON Configuration File to LZ Backup Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input JSON configuration file and output LZ backup file
            string inputPath = "C:\\Data\\config.json";
            string outputPath = "C:\\Backup\\config.lz";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Lzip archive, set source file, and save the compressed output
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
 * 1. When you need to create a lightweight, compressed backup of application settings stored in a JSON file before deploying updates.
 * 2. When you want to archive configuration data for long‑term storage on a server using the LZ format to save disk space.
 * 3. When an automated maintenance script must verify the existence of a config file, compress it, and place the result in a designated backup directory.
 * 4. When you are implementing a version‑controlled backup system that stores each configuration snapshot as a .lz archive for easy retrieval.
 * 5. When you need to ensure that a JSON configuration file is safely stored off‑site by compressing it with LzipArchive in a .NET application.
 */
