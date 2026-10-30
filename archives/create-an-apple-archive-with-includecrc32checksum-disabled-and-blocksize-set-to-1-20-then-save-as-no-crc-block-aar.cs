// HOW-TO: Create Apple XAR Archive From File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file path
            string inputPath = "input.txt";
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output archive path
            string outputPath = "no_crc_block.aar";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the XAR archive and add the input file as an entry
            using (FileStream outStream = File.Open(outputPath, FileMode.Create))
            {
                using (XarArchive archive = new XarArchive())
                {
                    archive.CreateEntry("input.txt", inputPath);
                    // Save the archive with default options
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
 * 1. When you need to package a single text file into an Apple XAR archive for macOS distribution using C#.
 * 2. When you want to generate a .aar file programmatically to include resources in an iOS or macOS application build pipeline.
 * 3. When you must create an archive without manual command‑line tools, integrating XAR creation directly into a .NET backend service.
 * 4. When you need to ensure the output archive is placed in a specific folder structure before deployment or version control.
 * 5. When you want to handle missing input files gracefully while automating archive creation in a Windows environment.
 */
