// HOW-TO: Compress Log File to Bzip2 Using Aspose.Zip With Two Threads in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "log_2023.txt";
        string outputPath = "output/log_2023.bz2";

        try
        {
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
 * 1. When you need to reduce the size of large server log files before archiving them to save disk space.
 * 2. When you want to generate Bzip2‑compressed backups of daily logs in an automated C# service.
 * 3. When you must transmit log files over a bandwidth‑limited network and need efficient compression.
 * 4. When you are building a monitoring tool that stores historical logs in a compact Bzip2 archive for later analysis.
 * 5. When you need to integrate Aspose.Zip’s multi‑threaded Bzip2 compression into an existing .NET application to speed up file processing.
 */
