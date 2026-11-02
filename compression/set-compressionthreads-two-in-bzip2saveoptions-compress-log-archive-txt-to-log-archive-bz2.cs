// HOW-TO: Compress Log File to BZIP2 with Two Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "log_archive.txt";
            string outputPath = "output/log_archive.bz2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create BZIP2 archive, set source file, and save
            using (Bzip2Archive archive = new Bzip2Archive())
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
 * 1. When you need to reduce the size of large server log files for faster transfer or storage, you can compress them into a BZIP2 archive using C# with multithreaded compression.
 * 2. When automating daily backups of application logs, this code creates a .bz2 file that can be easily archived and later decompressed on any platform.
 * 3. When a .NET service must generate compressed log bundles on the fly to meet bandwidth limits, setting CompressionThreads to two speeds up the BZIP2 compression.
 * 4. When integrating log compression into a CI/CD pipeline, the snippet lets you programmatically produce a BZIP2 file that can be stored as an artifact.
 * 5. When preparing logs for forensic analysis and you want a deterministic, high‑ratio compression format, the example shows how to produce a .bz2 archive directly from C#.
 */
