// HOW-TO: Compress and Extract a File Using LZ4 with Block Checksums in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string compressedPath = "output/blocks.lz4";
            string extractedPath = "output/extracted.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(compressedPath));
            Directory.CreateDirectory(Path.GetDirectoryName(extractedPath));

            // Compress with LZ4
            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(inputPath);
                archive.Save(compressedPath);
            }

            // Decompress
            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(compressedPath);
                archive.Extract(extractedPath);
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
 * 1. When you need to shrink a large text log before transmitting it and want LZ4’s fast compression with block‑level checksum verification.
 * 2. When you store configuration or settings files in a compact LZ4 archive on disk and later need to extract the original file for runtime use.
 * 3. When building a backup tool that compresses each file with LZ4 and relies on IncludeBlockChecksum to detect corruption during restore.
 * 4. When embedding a small data payload in an application package and require quick compression and decompression while ensuring integrity via block checksums.
 * 5. When creating a data‑processing pipeline that archives intermediate results using LZ4 and then extracts them for further analysis.
 */
