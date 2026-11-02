// HOW-TO: Compress Large Database Dump to Bzip2 with Multi‑Threading in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\dump.sql";
            string outputPath = @"C:\Data\parallel.bz2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a Bzip2 archive, set the source file, configure options, and save
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);

                Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                saveOptions.CompressionThreads = 6;

                archive.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce the size of a multi‑gigabyte SQL dump for faster network transfer, you can compress it to a Bzip2 file using C# with multiple threads.
 * 2. When backing up large production databases to limited‑storage media, multi‑threaded Bzip2 compression in .NET helps fit the dump within the available space.
 * 3. When preparing a database export for archival compliance, you can generate a single‑file Bzip2 archive in C# while controlling the number of compression threads for optimal CPU usage.
 * 4. When automating nightly data dumps in a Windows service, you can use Aspose.Zip to compress the 1 GiB file to parallel.bz2 without blocking other tasks.
 * 5. When integrating database export pipelines with cloud storage APIs, creating a Bzip2 archive with configurable threading in C# simplifies uploading a compact, single‑file package.
 */
