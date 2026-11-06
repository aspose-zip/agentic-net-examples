// HOW-TO: Extract All Files From a ZIP Archive to a Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.zip";
            string outputPath = @"C:\Data\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputPath);

            using (FileStream zipFile = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipFile))
                {
                    archive.ExtractToDirectory(outputPath);
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unpack a downloaded ZIP package containing configuration files before initializing an application.
 * 2. When a server receives user‑uploaded ZIP archives and must extract their contents to a temporary directory for processing.
 * 3. When automating deployment, you extract a ZIP bundle of compiled binaries into the target installation folder.
 * 4. When restoring a backup, you extract the archived data files from a ZIP archive to the original location on disk.
 * 5. When processing batch jobs, you extract multiple CSV files stored in a ZIP archive to a working directory for analysis.
 */
