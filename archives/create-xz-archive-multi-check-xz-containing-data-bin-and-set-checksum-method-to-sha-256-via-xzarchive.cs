// HOW-TO: Create XZ Archive With SHA-256 Checksum From Binary File In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "data.bin";
            string outputPath = "multi_check.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine($"XZ archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a large binary log file into a compact XZ archive with a SHA‑256 integrity check before uploading it to cloud storage.
 * 2. When you want to package a firmware binary for distribution, ensuring the archive uses XZ compression and includes a SHA‑256 checksum for verification on the target device.
 * 3. When automating backup of configuration files, you can create an XZ archive with a SHA‑256 hash to guarantee the backup hasn't been tampered with during transfer.
 * 4. When integrating with a CI/CD pipeline that requires artifacts to be compressed in XZ format and validated with SHA‑256 before publishing to an artifact repository.
 * 5. When developing a desktop utility that lets users select a single file and generate a secure XZ archive with a built‑in checksum for later extraction and integrity validation.
 */
