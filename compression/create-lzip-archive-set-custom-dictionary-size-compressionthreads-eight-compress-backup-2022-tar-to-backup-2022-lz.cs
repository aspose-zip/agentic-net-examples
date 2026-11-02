// HOW-TO: Create Lzip Archive From Tar File Using C# Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "backup_2022.tar";
            string outputPath = "backup_2022.lz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? string.Empty);

            using (LzipArchive archive = new LzipArchive())
            {
                archive.SetSource(inputPath);
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    archive.Save(outStream);
                }
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
 * 1. When you need to compress a large .tar backup into a smaller .lz file for efficient storage or transfer in a .NET application.
 * 2. When automating nightly server backups and you want to generate Lzip archives directly from existing tar archives using C#.
 * 3. When integrating Aspose.Zip into a deployment pipeline to convert legacy tar packages into Lzip format for compatibility with Linux tools.
 * 4. When building a cross‑platform utility that reads a tar file and creates a compressed Lzip archive without external command‑line tools.
 * 5. When you must programmatically verify the existence of a source tar file and create an Lzip archive on the fly to meet bandwidth constraints.
 */
