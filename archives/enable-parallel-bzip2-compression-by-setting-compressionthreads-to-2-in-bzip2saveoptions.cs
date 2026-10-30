// HOW-TO: How to Enable Parallel BZIP2 Compression with Two Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "data/input.txt";
            string outputPath = "output/output.bz2";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);

                Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                saveOptions.CompressionThreads = 2;

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
 * 1. When processing large log files that need to be archived quickly, a developer can use this code to compress them into BZIP2 format using two parallel threads for faster performance.
 * 2. When building a backup utility that must reduce CPU usage while still speeding up compression, setting CompressionThreads to 2 allows balanced multi‑threaded BZIP2 compression in C#.
 * 3. When integrating file compression into a .NET service that handles multiple simultaneous requests, this approach lets each request compress its data concurrently without blocking the main thread.
 * 4. When preparing data for transfer over limited bandwidth, developers can create smaller BZIP2 archives faster by enabling two compression threads, improving overall throughput.
 * 5. When migrating legacy BZIP2 archives to a modern .NET application, this code demonstrates how to generate new compressed files with controlled parallelism for consistent processing times.
 */
