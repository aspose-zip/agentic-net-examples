// HOW-TO: Create LZ4 Compressed TAR Archive With Block Checksum In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string outputPath = "output.tar.lz4";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            using (TarArchive archive = new TarArchive())
            {
                archive.CreateEntry("file.txt", inputPath);
                archive.SaveLZ4Compressed(outputPath);
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
 * 1. When you need to back up a configuration file into a small, integrity‑checked LZ4‑compressed TAR archive for fast storage or transfer in a C# application.
 * 2. When you want to package log files into a .tar.lz4 archive with block checksums before uploading them to a remote server to verify data integrity during transmission.
 * 3. When a build pipeline requires compressing generated artifacts into a lightweight LZ4 TAR file that can be quickly decompressed by downstream tools.
 * 4. When you are implementing a custom backup solution that stores daily snapshots as LZ4‑compressed TAR archives to minimize disk usage while still allowing checksum validation.
 * 5. When you need to create a portable, cross‑platform archive of a single file in C# that can be extracted by standard TAR utilities and includes block‑level checksums for error detection.
 */
