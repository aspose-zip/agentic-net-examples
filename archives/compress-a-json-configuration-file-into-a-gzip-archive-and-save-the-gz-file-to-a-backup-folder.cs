// HOW-TO: Compress JSON Configuration File to Gzip Backup Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\Data\\config.json";
            string outputPath = "C:\\Backup\\config.json.gz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Gzip archive and compress the file
            using (GzipArchive archive = new GzipArchive())
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
 * 1. When you need to reduce the size of a JSON settings file before storing it in a backup directory.
 * 2. When you want to automate daily archiving of configuration files using Gzip compression in a C# application.
 * 3. When you must ensure a configuration file can be quickly restored from a .gz archive after a system failure.
 * 4. When you are building a deployment script that compresses JSON resources to save network bandwidth during transfer.
 * 5. When you require a simple way to create gzip‑compressed backups of configuration data without third‑party command‑line tools.
 */
