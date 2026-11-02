// HOW-TO: Compress TAR File to LZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\archive_2021.tar";
            string outputPath = @"C:\Data\archive_2021.lz";

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
 * 1. When you need to reduce the size of a large .tar backup before transferring it over a network, you can use this code to create a .lz archive in C#.
 * 2. When integrating automated build pipelines that generate .tar packages, you can compress them to .lz format to save storage space on the artifact repository.
 * 3. When developing a cross‑platform .NET application that must archive logs or data bundles, this snippet shows how to produce an LZIP file that can be extracted on Linux systems.
 * 4. When implementing a scheduled maintenance script that archives daily data dumps, you can use the Aspose.Zip LzipArchive class to compress the .tar file with minimal code.
 * 5. When providing users a downloadable compressed version of a software distribution packaged as a .tar, this code enables you to generate a .lz file on the fly in a web service.
 */
