// HOW-TO: Compress a File to LZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.txt";
            string outputPath = @"C:\Data\sample.lz";

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
 * 1. When you need to reduce the size of a text file for faster network transfer by creating an LZIP archive in a C# application.
 * 2. When you want to store log or configuration files in a compact, portable format using Aspose.Zip's Lzip support.
 * 3. When a backup routine requires compressing individual files into .lz files before uploading to cloud storage.
 * 4. When integrating a .NET service that must generate LZIP archives for compatibility with Unix tools that expect .lz files.
 * 5. When automating a build process that needs to compress generated artifacts into LZIP to meet size constraints for distribution.
 */
