// HOW-TO: Compress Binary File to XZ Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\data_snapshot.bin";
            string outputPath = @"C:\Data\snapshot.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (XzArchive archive = new XzArchive())
            {
                archive.SetSource(inputPath);
                archive.Save(outputPath);
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a large binary log before uploading it to a cloud storage service, you can use this code to create an XZ archive with Aspose.Zip in C#.
 * 2. When a backup system must store snapshot files efficiently on disk, the example shows how to compress a .bin snapshot into a .xz file programmatically.
 * 3. When integrating a data‑export feature that delivers compressed binary reports to end‑users, this snippet demonstrates setting the source file and saving it as an XZ archive.
 * 4. When automating nightly builds that generate large artifact files, you can shrink them by compressing each artifact with Aspose.Zip’s XzArchive in a C# script.
 * 5. When implementing a secure file‑transfer pipeline that requires a single‑stream, high‑ratio compression format, the code provides a straightforward way to produce an XZ file from a binary source.
 */
