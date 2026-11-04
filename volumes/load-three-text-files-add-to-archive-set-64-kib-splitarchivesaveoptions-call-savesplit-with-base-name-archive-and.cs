// HOW-TO: Create a Split ZIP Archive of Multiple Text Files in C# (Aspose.ZIP for .NET)
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
            string inputPath1 = "input1.txt";
            string inputPath2 = "input2.txt";
            string inputPath3 = "input3.txt";

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

            // Output directory for split archive segments
            string outputDirectory = "output";
            Directory.CreateDirectory(outputDirectory);

            // Base path for split archive (without extension)
            string basePath = Path.Combine(outputDirectory, "archive");
            Directory.CreateDirectory(Path.GetDirectoryName(basePath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add three text files as entries
                archive.CreateEntry("file1.txt", new FileInfo(inputPath1));
                archive.CreateEntry("file2.txt", new FileInfo(inputPath2));
                archive.CreateEntry("file3.txt", new FileInfo(inputPath3));

                // Configure split options (64 KiB per segment)
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(64 * 1024);

                // Save the archive as split files
                archive.SaveSplit(basePath, saveOptions);
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
 * 1. When you need to package several log files into a ZIP that is automatically divided into 64 KB parts to meet size restrictions for email or legacy storage systems.
 * 2. When you want to create a multi‑segment archive for incremental download or streaming scenarios where each segment must be small enough for low‑bandwidth connections.
 * 3. When you are backing up configuration files and must ensure each backup piece fits on a removable medium such as a 64 KB flash card.
 * 4. When you are generating a split archive to comply with a third‑party API that only accepts ZIP segments of a specific maximum size.
 * 5. When you need to programmatically split a ZIP archive in C# so that the resulting files can be processed independently by separate extraction jobs.
 */
