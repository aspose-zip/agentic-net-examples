// HOW-TO: Compress CSV to BZ2 With 5 Threads Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output file paths
            string inputPath = @"C:\Data\dataset.csv";
            string outputPath = @"C:\Data\dataset.bz2";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BZIP2 compression options
            Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
            saveOptions.CompressionThreads = 5;

            // Create BZIP2 archive, set source, and save with options
            using (Bzip2Archive archive = new Bzip2Archive())
            {
                archive.SetSource(inputPath);
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
 * 1. When you need to reduce the size of a large CSV file for faster network transfer or storage, you can compress it to a BZ2 archive using Aspose.Zip with multiple threads in C#.
 * 2. When a data‑processing pipeline requires BZIP2‑compressed input files, this code lets you generate the .bz2 file from a CSV source programmatically.
 * 3. When you want to take advantage of multi‑core CPUs to speed up compression of log or dataset files, setting CompressionThreads to five accelerates the operation.
 * 4. When deploying a .NET application that must archive daily export files in a portable BZIP2 format, the snippet shows how to create the archive on the fly.
 * 5. When you need to ensure the output directory exists and handle missing source files gracefully while compressing, the example includes validation and error handling for reliable execution.
 */
