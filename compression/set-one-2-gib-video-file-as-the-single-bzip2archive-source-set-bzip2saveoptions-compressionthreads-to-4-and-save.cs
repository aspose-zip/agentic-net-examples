// HOW-TO: Compress Large Video to Bzip2 Using Multiple Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = @"C:\Data\video2GB.mp4";
        string outputPath = @"C:\Data\parallel.bz2";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create Bzip2 archive and set source file
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);

                // Configure save options with 4 compression threads
                Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                saveOptions.CompressionThreads = 4;

                // Save the compressed file
                archive.Save(outputPath, saveOptions);
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
 * 1. When you need to reduce the size of a multi‑gigabyte video for faster upload or storage, you can compress it to a .bz2 file using Aspose.Zip with parallel threads.
 * 2. When building a backup utility that must handle large media files efficiently, you can use Bzip2Archive with multiple compression threads to speed up the process.
 * 3. When creating a command‑line tool that prepares large video assets for distribution over limited‑bandwidth networks, this code shows how to generate a high‑compression Bzip2 archive in C#.
 * 4. When integrating video archiving into a .NET application and want to take advantage of multi‑core CPUs, you can set CompressionThreads to improve compression throughput.
 * 5. When automating a workflow that archives surveillance footage nightly, you can use this approach to compress each 2 GB file into a .bz2 archive with four parallel threads.
 */
