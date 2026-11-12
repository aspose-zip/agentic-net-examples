// HOW-TO: Create LZMA Compressed CPIO Archive from File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;
using Aspose.Zip.LZMA;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file and output archive paths
            string inputFilePath = "data\\input.txt";
            string outputArchivePath = "output\\archive.cpio.lzma";

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Create CPIO archive, add the input file, and save as LZMA-compressed CPIO
            using (CpioArchive archive = new CpioArchive())
            {
                // Add entry with the same name as the source file
                archive.CreateEntry("input.txt", inputFilePath);

                // Save the archive compressed with LZMA
                archive.SaveLZMACompressed(outputArchivePath);
            }

            Console.WriteLine($"Compressed CPIO archive created at: {outputArchivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a configuration file into a compact LZMA‑compressed CPIO archive for distribution to Linux systems using C#.
 * 2. When creating backup snapshots of critical logs where the smallest possible size is required, and the target environment expects a .cpio.lzma file.
 * 3. When automating deployment scripts that generate CPIO archives with LZMA compression to meet embedded device firmware update constraints.
 * 4. When integrating .NET applications with legacy Unix tools that only accept CPIO archives, and you want to reduce transfer time by applying LZMA compression.
 * 5. When building a CI pipeline that archives build artifacts into a single .cpio.lzma file for efficient storage and later extraction on a Linux server.
 */
