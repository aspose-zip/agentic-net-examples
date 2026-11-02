// HOW-TO: Compress JSON File to BZIP2 with 8 Threads in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\large_dataset.json";
            string outputPath = @"C:\Data\large_dataset.bz2";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Configure BZIP2 compression options
            Bzip2SaveOptions saveOptions = new Bzip2SaveOptions();
            saveOptions.CompressionThreads = 8;

            // Create and configure the BZIP2 archive
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
 * 1. When you need to reduce the size of a massive JSON log file before transferring it over a network, you can use this code to create a BZIP2 archive with multi‑threaded compression.
 * 2. When backing up large configuration data to save disk space, the example shows how to generate a .bz2 file using C# and control the number of compression threads.
 * 3. When preparing data for archival storage where BZIP2 is the required format, the snippet demonstrates setting up the compression options and saving the file in one step.
 * 4. When optimizing CPU usage during compression of big data files, you can adjust CompressionThreads to 8 as shown to balance speed and resource consumption.
 * 5. When integrating automated compression into a .NET application pipeline, this code provides a simple way to verify the source file, create the output directory, and produce a compressed BZIP2 file.
 */
