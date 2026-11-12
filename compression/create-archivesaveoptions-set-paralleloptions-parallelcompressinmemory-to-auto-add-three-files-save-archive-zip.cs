// HOW-TO: Create Zip Archive With Parallel In-Memory Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = @"C:\Data\file1.txt";
            string inputPath2 = @"C:\Data\file2.txt";
            string inputPath3 = @"C:\Data\file3.txt";

            // Hardcoded output archive path
            string outputPath = @"C:\Output\archive.zip";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open source files and create archive
            using (FileStream source1 = File.Open(inputPath1, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(inputPath2, FileMode.Open, FileAccess.Read))
            using (FileStream source3 = File.Open(inputPath3, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                // Add entries to the archive
                archive.CreateEntry("file1.txt", source1);
                archive.CreateEntry("file2.txt", source2);
                archive.CreateEntry("file3.txt", source3);

                // Configure parallel compression options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                Aspose.Zip.Saving.ParallelOptions parallelOpts = new Aspose.Zip.Saving.ParallelOptions();
                parallelOpts.ParallelCompressInMemory = Aspose.Zip.Saving.ParallelCompressionMode.Auto;
                saveOptions.ParallelOptions = parallelOpts;

                // Save the archive to the output path
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
 * 1. When you need to package multiple log files into a single ZIP quickly by leveraging multi‑core CPUs with Aspose.Zip’s parallel in‑memory compression.
 * 2. When an application must generate a compressed backup of user‑generated documents on the fly without writing temporary files to disk.
 * 3. When a server‑side service creates downloadable archives of report files and wants to minimize CPU time by using automatic parallel compression.
 * 4. When you are building a deployment tool that bundles configuration files into a ZIP and wants consistent performance across different hardware.
 * 5. When a data‑processing pipeline needs to archive processed CSV files into a ZIP archive while keeping memory usage optimal with Aspose.Zip’s ParallelCompressInMemory option.
 */
