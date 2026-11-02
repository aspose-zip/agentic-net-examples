// HOW-TO: Compress JSON File to Bzip2 Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\dataset.json";
            string outputPath = @"C:\Data\dataset.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive())
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
 * 1. When you need to reduce the size of a large JSON dataset before transferring it over a network, you can compress it to a .bz2 file with Aspose.Zip in C#.
 * 2. When storing backup copies of configuration files, you can create a Bzip2 archive to save disk space while keeping the original JSON format intact.
 * 3. When preparing data for archival compliance, you can use the code to generate a Bzip2‑compressed file that can be easily decompressed later with standard tools.
 * 4. When integrating a C# application with a pipeline that expects Bzip2‑compressed inputs, this snippet shows how to produce the required .bz2 file from a JSON source.
 * 5. When automating daily data exports, you can compress the exported JSON file into a Bzip2 archive to speed up file uploads to cloud storage services.
 */
