// HOW-TO: How To Set BZIP2 Block Size To 3 When Creating A .bz2 Archive In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string outputPath = "output/output.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Archive archive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
            {
                archive.CreateEntry("file.txt", inputPath);
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
 * 1. When you need to create a .bz2 archive with a specific BZIP2 block size to optimize compression speed and memory usage in a C# application.
 * 2. When your application must generate BZIP2‑compressed files that conform to a legacy system’s requirement of block size 3 for compatibility.
 * 3. When you want to control the compression parameters of an Aspose.Zip archive to achieve consistent file sizes across different environments.
 * 4. When you are building a backup utility in .NET that compresses text files into BZIP2 format and requires fine‑tuned block size settings for performance tuning.
 * 5. When you need to programmatically create a BZIP2 archive in C# and ensure the block size is set before saving to meet regulatory or storage constraints.
 */
