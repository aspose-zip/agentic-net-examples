// HOW-TO: Compress Multiple PDFs Into ZIP With 100MB Memory Limit In C# (Aspose.ZIP for .NET)
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
            string inputPath1 = @"C:\Data\file1.pdf";
            string inputPath2 = @"C:\Data\file2.pdf";
            string inputPath3 = @"C:\Data\file3.pdf";
            string inputPath4 = @"C:\Data\file4.pdf";

            // Verify each input file exists
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
            if (!File.Exists(inputPath4))
            {
                Console.Error.WriteLine($"File not found: {inputPath4}");
                return;
            }

            // Hardcoded output zip path
            string outputPath = @"C:\Output\docs.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open streams for the output zip and input PDFs
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            using (FileStream source1 = File.Open(inputPath1, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(inputPath2, FileMode.Open, FileAccess.Read))
            using (FileStream source3 = File.Open(inputPath3, FileMode.Open, FileAccess.Read))
            using (FileStream source4 = File.Open(inputPath4, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                // Add PDF files to the archive
                archive.CreateEntry("file1.pdf", source1);
                archive.CreateEntry("file2.pdf", source2);
                archive.CreateEntry("file3.pdf", source3);
                archive.CreateEntry("file4.pdf", source4);

                // Configure parallel compression options
                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.ParallelOptions = new Aspose.Zip.Saving.ParallelOptions();
                saveOptions.ParallelOptions.AvailableMemorySize = 100 * 1024 * 1024; // 100 MB

                // Save the archive to the zip file
                archive.Save(zipFile, saveOptions);
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
 * 1. When a desktop application must bundle several PDF reports into a single ZIP file while ensuring the compression process never exceeds 100 MB of RAM.
 * 2. When a server‑side service needs to create a downloadable archive of PDFs but must disable parallel compression to avoid CPU spikes.
 * 3. When an automated batch job processes large PDF documents and wants to limit memory usage by setting ParallelOptions.AvailableMemorySize.
 * 4. When a file‑management tool wants to package user‑selected PDFs into a ZIP archive using Aspose.Zip without parallel processing for deterministic performance.
 * 5. When a .NET microservice has strict memory quotas and must compress a fixed set of PDFs into a zip file with controlled resource consumption.
 */
