// HOW-TO: Extract Zip Archive With Overall Progress Logging To File In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "archive.zip";
            string outputDirectory = "Extracted";
            string progressFilePath = "zip_overall_progress.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);
            string progressDir = Path.GetDirectoryName(progressFilePath);
            if (!string.IsNullOrEmpty(progressDir))
            {
                Directory.CreateDirectory(progressDir);
            }

            using (StreamWriter writer = new StreamWriter(progressFilePath, false))
            using (Archive archive = new Archive(inputPath))
            {
                ulong totalUncompressedSize = 0UL;
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    totalUncompressedSize += entry.UncompressedSize;
                }

                ulong totalExtractedSoFar = 0UL;

                foreach (ArchiveEntry entry in archive.Entries)
                {
                    ulong entryExtractedBytes = 0UL;

                    entry.ExtractionProgressed += (sender, e) =>
                    {
                        entryExtractedBytes = e.ProceededBytes;
                        ulong overallExtracted = totalExtractedSoFar + entryExtractedBytes;
                        int percent = (int)((overallExtracted * 100UL) / totalUncompressedSize);
                        writer.WriteLine($"Overall extraction progress: {percent}%");
                    };

                    string destinationPath = Path.Combine(outputDirectory, entry.Name);
                    string destinationDir = Path.GetDirectoryName(destinationPath);
                    if (!string.IsNullOrEmpty(destinationDir))
                    {
                        Directory.CreateDirectory(destinationDir);
                    }

                    entry.Extract(destinationPath);
                    totalExtractedSoFar += entry.UncompressedSize;
                }

                writer.WriteLine("Extraction completed.");
            }

            Console.WriteLine("Archive extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to unzip a package and show a single overall percentage to users while extracting many files.
 * 2. When you want to record extraction progress in a text file for later analysis or auditing.
 * 3. When you must extract files to a specific folder and ensure the destination directory is created automatically.
 * 4. When you are handling large ZIP archives and need to compute the total uncompressed size to provide accurate progress metrics.
 * 5. When you want to capture extraction events in C# using Aspose.Zip’s ExtractionProgressed event for custom reporting.
 */
