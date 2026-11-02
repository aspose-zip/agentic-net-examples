// HOW-TO: Compress Large File to XZ Using Eight Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\largefile.dat";
            string outputPath = @"C:\Data\archive.xz";

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
 * 1. When you need to reduce the size of a massive data file for faster network transfer or storage, you can compress it into an XZ archive using Aspose.Zip in C#.
 * 2. When building a backup utility that stores daily snapshots as highly compressed XZ files, this code shows how to create the archive programmatically.
 * 3. When integrating file compression into a .NET service that processes large logs, you can use the XzArchive class to generate a compact .xz file before archiving.
 * 4. When preparing data for distribution to clients who require the XZ format, developers can automate the compression step with this C# snippet.
 * 5. When optimizing CPU usage by leveraging multiple compression threads, the code demonstrates how to set up an XZ archive with eight threads for efficient processing.
 */
