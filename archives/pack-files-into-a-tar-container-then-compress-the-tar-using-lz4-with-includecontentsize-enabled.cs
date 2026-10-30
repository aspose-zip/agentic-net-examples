// HOW-TO: Create TAR Archive and Compress with LZ4 Including Content Size in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = @"C:\InputData";
            string outputDir = @"C:\OutputData";
            string outputPath = Path.Combine(outputDir, "archive.tar.lz4");

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            string[] files = new string[]
            {
                Path.Combine(inputDir, "file1.txt"),
                Path.Combine(inputDir, "file2.txt")
            };

            using (TarArchive archive = new TarArchive())
            {
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, filePath);
                }

                archive.SaveLZ4Compressed(outputPath);
            }

            Console.WriteLine($"TAR LZ4 archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple files into a single portable TAR package and apply fast LZ4 compression with content‑size metadata for network transfer.
 * 2. When building a backup system that stores daily snapshots as .tar.lz4 files to save space while preserving original file names.
 * 3. When you must create an archive compatible with Unix tar utilities but want the speed of LZ4 for quick extraction in a .NET application.
 * 4. When you want a compressed archive that records each entry’s original size to enable accurate progress reporting during decompression.
 * 5. When integrating Aspose.Zip into a CI pipeline to package build artifacts into a TAR container and compress them with LZ4 for efficient distribution.
 */
