// HOW-TO: Decompress GZIP File and Recompress to XZ in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "data/backup.gz";
            string outputPath = "output/backup.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (MemoryStream decompressedStream = new MemoryStream())
            {
                using (GzipArchive gzipArchive = new GzipArchive(File.OpenRead(inputPath)))
                {
                    using (Stream sourceStream = gzipArchive.Open())
                    {
                        sourceStream.CopyTo(decompressedStream);
                    }
                    Console.WriteLine($"Decompressed GZIP archive: {gzipArchive.Name}");
                }

                decompressedStream.Position = 0;

                using (XzArchive xzArchive = new XzArchive())
                {
                    xzArchive.SetSource(decompressedStream);
                    xzArchive.Save(outputPath);
                    Console.WriteLine($"Compressed to XZ archive: {outputPath}");
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
 * 1. When you need to convert legacy .gz backups to .xz format for better compression before archiving them in a .NET application.
 * 2. When a data migration script must read a GZIP‑compressed database dump, extract its contents, and store it as an XZ archive for compatibility with Linux tools.
 * 3. When an automated backup pipeline requires decompressing incoming .gz logs, processing them in memory, and re‑compressing the result as .xz to reduce storage costs.
 * 4. When a C# service receives GZIP streams over a network, needs to unpack them, and then saves the payload in XZ format for long‑term retention.
 * 5. When you are refactoring a legacy system that only supports GZIP and want to transition to XZ without writing intermediate files to disk.
 */
