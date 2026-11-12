// HOW-TO: Create LZ4 Archive from a Single File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = "sample.txt";
            string outputPath = "sample.lz4";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create LZ4 archive, set the source file, and save the archive
            using (Lz4Archive archive = new Lz4Archive())
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
 * 1. When you need to compress a log file into an LZ4 archive for fast transmission over a network in a C# application.
 * 2. When you want to reduce the size of a configuration file before storing it in cloud storage using Aspose.Zip Lz4Archive.
 * 3. When a backup utility written in C# must create lightweight LZ4 archives of individual documents for quick restore operations.
 * 4. When you are building a data pipeline that packages sensor data files into LZ4 containers to improve read/write performance.
 * 5. When you need to generate an LZ4‑compressed version of a text report to meet email attachment size limits in a .NET service.
 */
