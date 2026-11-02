// HOW-TO: Compress CSV to BZ2 With Three Threads In C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\large_dataset.csv";
            string outputPath = @"C:\Data\large_dataset.bz2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create Bzip2 archive, set source file, configure options, and save
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);

                Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
                saveOptions.CompressionThreads = 3;

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
 * 1. When you need to reduce the size of a massive CSV file for faster network transfer, you can compress it to a BZ2 archive using three parallel threads in C#.
 * 2. When a data‑processing pipeline stores intermediate results as CSV and wants to save disk space while keeping the file easily decompressible, this code creates a multithreaded Bzip2 archive.
 * 3. When deploying a .NET application that must generate BZ2 backups of log or export files on a server with limited CPU cores, setting CompressionThreads to three balances speed and resource usage.
 * 4. When integrating with Linux‑based systems that expect .bz2 files, you can programmatically produce the required format from C# without external tools.
 * 5. When automating nightly archiving of large datasets and you want to control the number of compression threads to avoid overloading the machine, this snippet provides a simple solution.
 */
