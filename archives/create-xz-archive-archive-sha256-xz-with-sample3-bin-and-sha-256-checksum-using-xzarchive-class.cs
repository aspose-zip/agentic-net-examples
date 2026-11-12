// HOW-TO: Create XZ Archive from Binary File Using Aspose Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "sample3.bin";
            string outputPath = "archive_sha256.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
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
 * 1. When you need to compress a large binary log into a lightweight .xz file for faster network transfer in a C# application.
 * 2. When you want to package a compiled resource such as a firmware image into an XZ archive before uploading to a cloud storage service using Aspose.Zip.
 * 3. When your backup script must create XZ‑compressed snapshots of binary data files on Windows with .NET.
 * 4. When integrating with Linux tools that expect .xz archives, you can generate them directly from C# without invoking external utilities.
 * 5. When delivering software updates, you can compress the update payload into an XZ archive to reduce download size for end‑users.
 */
