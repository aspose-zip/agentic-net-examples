// HOW-TO: Compress File to LZ4 with Checksums and Extract in C# (Aspose.ZIP for .NET)
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
            string compressedPath = "data.lz4";
            string extractedPath = "extracted.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(compressedPath) ?? ".");

            using (Lz4Archive compressArchive = new Lz4Archive())
            {
                compressArchive.SetSource(inputPath);
                compressArchive.Save(compressedPath);
            }

            Directory.CreateDirectory(Path.GetDirectoryName(extractedPath) ?? ".");

            using (Lz4Archive decompressArchive = new Lz4Archive())
            {
                decompressArchive.SetSource(compressedPath);
                decompressArchive.Extract(extractedPath);
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
 * 1. When you need to reduce the size of a log file before sending it over a network while ensuring data integrity with LZ4 checksums.
 * 2. When you want to store a configuration file in a compact LZ4 archive and later retrieve the original file in a .NET application.
 * 3. When a backup routine requires fast compression of a single document and the ability to restore it with a single extraction step.
 * 4. When integrating with a system that only accepts LZ4‑compressed payloads, you can compress the payload and later decompress it on the receiving side.
 * 5. When performing automated testing of file‑transfer pipelines, you can compress a test file with LZ4 and verify that the extracted output matches the source.
 */
