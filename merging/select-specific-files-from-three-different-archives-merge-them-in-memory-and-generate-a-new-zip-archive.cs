// HOW-TO: Extract Specific Files from Multiple ZIPs and Merge into New ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input archive paths
            string inputPath1 = "archive1.zip";
            string inputPath2 = "archive2.zip";
            string inputPath3 = "archive3.zip";

            // Hardcoded output archive path
            string outputPath = "merged.zip";

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
            if (!File.Exists(inputPath3))
            {
                Console.Error.WriteLine($"File not found: {inputPath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold selected entries (name and data)
            List<(string EntryName, MemoryStream Data)> selectedEntries = new List<(string, MemoryStream)>();

            // Helper to extract a specific entry from an archive into memory
            void ExtractEntry(string archivePath, string entryFileName)
            {
                using (Archive archive = new Archive(archivePath))
                {
                    ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryFileName, StringComparison.OrdinalIgnoreCase));
                    if (entry != null)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream ms = new MemoryStream();
                            entryStream.CopyTo(ms);
                            ms.Position = 0;
                            selectedEntries.Add((entryFileName, ms));
                        }
                    }
                    else
                    {
                        Console.Error.WriteLine($"Entry '{entryFileName}' not found in archive '{archivePath}'.");
                    }
                }
            }

            // Extract required entries from each archive
            ExtractEntry(inputPath1, "fileA.txt");
            ExtractEntry(inputPath2, "imageB.png");
            ExtractEntry(inputPath3, "docC.pdf");

            // Create a new ZIP archive and add the selected entries
            using (Archive newArchive = new Archive())
            {
                foreach (var (entryName, data) in selectedEntries)
                {
                    // Add entry using the in‑memory stream; keep the stream open until Save completes
                    newArchive.CreateEntry(entryName, data);
                }

                // Save the merged archive to the output path
                newArchive.Save(outputPath);
            }

            // Dispose memory streams after the archive has been saved
            foreach (var (_, data) in selectedEntries)
            {
                data.Dispose();
            }

            Console.WriteLine($"Merged archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to pull only certain documents from several ZIP packages and combine them into a single archive for distribution.
 * 2. When building a deployment pipeline that gathers configuration files from multiple versioned ZIP releases into one compressed bundle.
 * 3. When creating a backup solution that extracts specific logs from different archive sources and stores them together in a new ZIP file.
 * 4. When implementing a feature that consolidates selected assets from multiple third‑party ZIP downloads into a single package for offline use.
 * 5. When developing a reporting tool that collects particular CSV reports from various archived datasets and merges them into one ZIP for easy download.
 */
