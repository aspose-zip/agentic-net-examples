// HOW-TO: Compress File to Bzip2 with Progress Logging to Text File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "input/backup.txt";
            string outputPath = "output/backup.bz2";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Bzip2 archive and compress the file
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
 * 1. When you need to reduce the size of a backup file before transferring it over a network and want to monitor compression progress in a log file.
 * 2. When automating nightly data archiving in a .NET application and require a Bzip2 archive with real‑time percentage updates saved for audit purposes.
 * 3. When integrating file compression into a backup utility that must produce a .bz2 file and record overall compression stats for reporting.
 * 4. When building a C# service that compresses large log files and needs to write the cumulative compression percentage to a text file for monitoring.
 * 5. When creating a portable archive of configuration files and want to track how much data has been compressed at each step using a progress handler.
 */
