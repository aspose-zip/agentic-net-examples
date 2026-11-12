// HOW-TO: Extract Text Files From ZIP And 7z, Merge, And Create New ZIP In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string zipInputPath = "input.zip";
            string sevenZipInputPath = "input.7z";
            string outputPath = "merged_output.zip";

            // Validate input files
            if (!File.Exists(zipInputPath))
            {
                Console.Error.WriteLine($"File not found: {zipInputPath}");
                return;
            }
            if (!File.Exists(sevenZipInputPath))
            {
                Console.Error.WriteLine($"File not found: {sevenZipInputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir ?? ".");

            // List to hold temporary streams for the merged entries
            List<MemoryStream> tempStreams = new List<MemoryStream>();

            // Open source archives
            using (Archive zipArchive = new Archive(zipInputPath))
            using (SevenZipArchive sevenArchive = new SevenZipArchive(sevenZipInputPath))
            using (Archive outputArchive = new Archive())
            {
                // Process .txt entries from ZIP archive
                foreach (ArchiveEntry entry in zipArchive.Entries)
                {
                    if (entry.Name != null && entry.Name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream ms = new MemoryStream();
                            entryStream.CopyTo(ms);
                            ms.Position = 0;
                            tempStreams.Add(ms);
                            outputArchive.CreateEntry(entry.Name, ms);
                        }
                    }
                }

                // Process .txt entries from 7z archive
                foreach (SevenZipArchiveEntry entry in sevenArchive.Entries)
                {
                    if (entry.Name != null && entry.Name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream ms = new MemoryStream();
                            entryStream.CopyTo(ms);
                            ms.Position = 0;
                            tempStreams.Add(ms);
                            outputArchive.CreateEntry(entry.Name, ms);
                        }
                    }
                }

                // Save merged ZIP archive
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    outputArchive.Save(outStream, new ArchiveSaveOptions());
                }
            }

            // Dispose temporary streams
            foreach (MemoryStream ms in tempStreams)
            {
                ms.Dispose();
            }

            Console.WriteLine("Merged ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine all text documents from multiple archive formats into a single ZIP for easier distribution.
 * 2. When a reporting system stores logs in separate .txt files inside ZIP and 7z packages and you must consolidate them before uploading.
 * 3. When automating backup cleanup, you want to extract only .txt configuration files from existing archives and re‑archive them into a new ZIP.
 * 4. When integrating third‑party data that arrives as mixed ZIP and 7z bundles, you can pull the relevant text files and create a unified archive for downstream processing.
 * 5. When building a document‑management workflow that requires merging textual resources from legacy 7z archives with newer ZIP collections into one compressed package.
 */
