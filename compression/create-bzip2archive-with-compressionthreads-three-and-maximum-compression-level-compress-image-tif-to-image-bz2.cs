// HOW-TO: Compress TIFF Image to BZ2 Using Aspose.Zip Bzip2Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\image.tif";
            string outputPath = "C:\\Data\\image.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive())
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
 * 1. When you need to reduce the storage size of large TIFF files before uploading them to a cloud server, you can use this code to create a BZ2 archive in C#.
 * 2. When a desktop application must generate a high‑compression backup of scanned documents, the Bzip2Archive class can compress each image to a .bz2 file for efficient archiving.
 * 3. When integrating a document‑management workflow that requires BZIP2‑compressed assets for compatibility with legacy systems, this snippet shows how to produce the .bz2 file programmatically.
 * 4. When automating nightly batch jobs that prepare medical imaging data for transmission over limited‑bandwidth networks, the code compresses the TIFF files into BZ2 format using Aspose.Zip.
 * 5. When building a C# utility that validates the existence of source files and creates the necessary output directories before compressing, this example demonstrates the complete error‑handling and compression process.
 */
