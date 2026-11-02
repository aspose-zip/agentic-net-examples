// HOW-TO: Compress PNG to Lzip With Custom Dictionary And Six Threads In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\image.png";
            string outputPath = @"C:\Data\image.lz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            int dictionarySize = 1048576; // 1 MB
            int compressionThreads = 6;

            using (LzipArchive archive = new LzipArchive(new LzipArchiveSettings(dictionarySize, compressionThreads)))
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
 * 1. When you need to reduce the size of PNG assets for faster network transfer while controlling memory usage with a 1 MB dictionary.
 * 2. When you want to speed up Lzip compression on a multi‑core server by specifying six parallel compression threads.
 * 3. When you are building an automated backup script that archives image files into Lzip format using Aspose.Zip for .NET.
 * 4. When you must create a reproducible Lzip archive with a custom dictionary size to meet a third‑party tool’s compression requirements.
 * 5. When you are integrating image compression into a C# application and need to ensure the output file is stored in the .lz format for later extraction.
 */
