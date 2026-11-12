// HOW-TO: Compress Dataset_Collection.Bin to Xz with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\dataset_collection.bin";
            string outputPath = @"C:\Data\collection.xz";

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
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to reduce the size of a large binary dataset for faster network transfer or storage, you can compress it into an XZ archive using Aspose.Zip in C#.
 * 2. When building a backup solution that stores binary logs in a compact format, you can generate .xz files programmatically with the XzArchive class.
 * 3. When preparing data files for distribution to clients who require XZ compression, you can automate the creation of .xz archives in a .NET application.
 * 4. When integrating a data pipeline that outputs large .bin files, you can immediately compress them to .xz to save disk space and improve I/O performance.
 * 5. When implementing a cross‑platform archiving feature that must support XZ compression, you can use Aspose.Zip’s XzArchiveSettings to control threading and create the archive in C#.
 */
