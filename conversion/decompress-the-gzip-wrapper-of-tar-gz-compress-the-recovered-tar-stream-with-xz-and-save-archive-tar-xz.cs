// HOW-TO: Convert Tar.Gz To Tar.Xz Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Gzip;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input\\archive.tar.gz";
        string outputPath = "output\\archive.tar.xz";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Decompress GZIP to obtain the TAR stream
            using (GzipArchive gzip = new GzipArchive())
            {
                gzip.SetSource(inputPath);
                using (Stream tarStream = gzip.Open())
                {
                    // Compress the TAR stream with XZ and save as .tar.xz
                    using (XzArchive xz = new XzArchive())
                    {
                        xz.SetSource(tarStream);
                        xz.Save(outputPath);
                    }
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
 * 1. When you need to replace a .tar.gz package with a smaller .tar.xz file for faster distribution in a .NET deployment pipeline.
 * 2. When migrating backup archives from GZIP to XZ compression to reduce storage costs while preserving the original TAR contents.
 * 3. When extracting a TAR stream from a .tar.gz download and re‑compressing it to .tar.xz for compatibility with Linux systems that prefer XZ.
 * 4. When automating a build process that converts source code bundles packaged as .tar.gz into .tar.xz before publishing to a repository.
 * 5. When creating a cross‑platform installer that must deliver assets in XZ format, requiring conversion from existing GZIP‑compressed TAR archives in C#.
 */
