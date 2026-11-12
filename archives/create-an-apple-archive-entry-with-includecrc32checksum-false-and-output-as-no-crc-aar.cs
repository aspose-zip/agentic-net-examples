// HOW-TO: Create Bzip2, LZMA, and Store ZIP Archives in C# (Aspose.ZIP for .NET)
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
            string outputPathBzip2 = "bzip2.zip";
            string outputPathLzma = "lzma.zip";
            string outputPathStore = "store.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Bzip2 compression
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathBzip2) ?? ".");
            using (FileStream zipStream = File.Open(outputPathBzip2, FileMode.Create))
            {
                using (Archive archive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
                {
                    archive.CreateEntry("input.txt", inputPath);
                    archive.Save(zipStream);
                }
            }

            // LZMA compression
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathLzma) ?? ".");
            using (FileStream zipStream = File.Open(outputPathLzma, FileMode.Create))
            {
                using (Archive archive = new Archive(new ArchiveEntrySettings(new LzmaCompressionSettings())))
                {
                    archive.CreateEntry("input.txt", inputPath);
                    archive.Save(zipStream);
                }
            }

            // Store (no compression)
            Directory.CreateDirectory(Path.GetDirectoryName(outputPathStore) ?? ".");
            using (FileStream zipStream = File.Open(outputPathStore, FileMode.Create))
            {
                using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
                {
                    archive.CreateEntry("input.txt", inputPath);
                    archive.Save(zipStream);
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
 * 1. When you need to generate ZIP files with different compression algorithms (Bzip2, LZMA, or no compression) for testing compatibility across various archive tools.
 * 2. When an application must package log or data files into a compressed archive while allowing users to choose the most efficient compression method for their storage constraints.
 * 3. When a backup system requires creating separate ZIP archives using high‑ratio LZMA compression for long‑term storage and fast Store compression for quick restores.
 * 4. When you are integrating Aspose.Zip into a C# service that dynamically creates archives for downloadable reports, and you want to compare Bzip2 and LZMA performance.
 * 5. When a DevOps pipeline needs to compress configuration files into ZIP archives with specific algorithms before uploading them to an artifact repository.
 */
