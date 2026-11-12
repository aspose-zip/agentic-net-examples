// HOW-TO: Extract ZIP File and Track Overall Extraction Progress in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "data.zip";
            string outputDir = "extracted_data";
            string percentPath = "zip_extraction_percent.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(percentPath) ?? ".");

            ulong totalUncompressedSize = 0;
            ulong extractedBytes = 0;

            using (var archive = new Archive(inputPath, new ArchiveLoadOptions
            {
                EntryExtractionProgressed = (sender, e) =>
                {
                    extractedBytes += e.ProceededBytes;
                    int percent = totalUncompressedSize > 0 ? (int)(extractedBytes * 100 / totalUncompressedSize) : 0;
                    Console.WriteLine($"Overall extraction progress: {percent}%");
                }
            }))
            {
                foreach (var entry in archive.Entries)
                {
                    totalUncompressedSize += entry.UncompressedSize;
                }

                archive.ExtractToDirectory(outputDir);
            }

            int finalPercent = totalUncompressedSize > 0 ? (int)(extractedBytes * 100 / totalUncompressedSize) : 0;
            File.WriteAllText(percentPath, finalPercent.ToString());
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unzip a package and monitor the combined extraction progress of all files for a user‑friendly status display.
 * 2. When you want to log the final extraction percentage to a text file for later reporting or auditing.
 * 3. When you must ensure the output directory exists before extracting a ZIP archive in a .NET application.
 * 4. When you need to handle missing ZIP files gracefully by checking existence and reporting errors.
 * 5. When you want to calculate the total uncompressed size of a ZIP archive to compute accurate progress percentages during extraction.
 */
