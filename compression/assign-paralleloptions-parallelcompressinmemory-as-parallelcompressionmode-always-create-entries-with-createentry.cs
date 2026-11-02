// HOW-TO: Create ZIP Archive With Always Parallel Compression Using Aspose.Zip C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath1 = "data\\file1.txt";
            string inputPath2 = "data\\file2.txt";
            string outputPath = "output\\alwaysEntry.zip";

            // Validate input files
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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add entries from the input files
                archive.CreateEntry("file1.txt", new FileInfo(inputPath1));
                archive.CreateEntry("file2.txt", new FileInfo(inputPath2));

                // Configure parallel compression options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                Aspose.Zip.Saving.ParallelOptions parallelOpts = new Aspose.Zip.Saving.ParallelOptions();
                saveOptions.ParallelOptions = parallelOpts;

                // Save the archive to the output path with the specified options
                archive.Save(outputPath, saveOptions);
            }

            Console.WriteLine($"Archive created successfully at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package multiple log files into a ZIP quickly by leveraging multi‑core CPUs with Aspose.Zip’s always‑on parallel compression in a C# application.
 * 2. When a backend service must generate compressed reports on the fly and wants deterministic parallel compression to guarantee consistent performance.
 * 3. When an automated build pipeline creates deployment bundles and wants to ensure the ZIP creation uses maximum CPU parallelism without manually managing threads.
 * 4. When a desktop utility compresses user‑selected documents and you want to use Aspose.Zip’s ParallelOptions to speed up the process on multi‑core machines.
 * 5. When a cloud function processes incoming files and must archive them efficiently, using Aspose.Zip’s always parallel mode to reduce latency.
 */
