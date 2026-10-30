// HOW-TO: Compress A TAR Archive With Zstandard To ZST In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;
using Aspose.Zip.Zstandard;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file and output paths
            string inputFilePath = "input.txt";
            string outputDirectory = "output";
            string outputFilePath = Path.Combine(outputDirectory, "archive.tar.zst");

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Create TAR archive, add entry, and save with Zstandard compression
            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry(Path.GetFileName(inputFilePath), inputFilePath);
                archive.SaveZstandard(outputFilePath);
            }

            Console.WriteLine($"TAR archive compressed with Zstandard saved to: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package log files into a single TAR and reduce size using high‑speed Zstandard compression for faster uploads.
 * 2. When you want to create a .zst archive for distribution to Linux systems that expect Zstandard‑compressed tarballs.
 * 3. When you must generate a compressed backup of configuration files in C# before storing them in cloud storage with limited bandwidth.
 * 4. When you are building a deployment pipeline that bundles application assets into a TAR and compresses them with Zstandard to meet size constraints.
 * 5. When you need to programmatically compress large data sets into a .tar.zst file for archival while preserving the original directory structure.
 */
