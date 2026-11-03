// HOW-TO: Convert ZIP Archive To 7z In Memory Using C# Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP and output 7z paths
            string inputPath = "input.zip";
            string outputPath = "output.7z";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold entry data in memory
            List<Tuple<string, MemoryStream>> entryData = new List<Tuple<string, MemoryStream>>();

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputPath))
            {
                // Iterate over entries and copy file entries to memory
                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    if (!zipEntry.IsDirectory)
                    {
                        MemoryStream ms = new MemoryStream();
                        using (Stream entryStream = zipEntry.Open())
                        {
                            entryStream.CopyTo(ms);
                        }
                        ms.Position = 0;
                        entryData.Add(Tuple.Create(zipEntry.Name, ms));
                    }
                }
            }

            // Create a new 7z archive and add the in‑memory entries
            using (SevenZipArchive sevenZip = new SevenZipArchive())
            {
                foreach (Tuple<string, MemoryStream> item in entryData)
                {
                    // Add each entry; default settings are used
                    sevenZip.CreateEntry(item.Item1, item.Item2);
                }

                // Save the 7z archive to the output path
                sevenZip.Save(outputPath);
            }

            // Dispose the memory streams after the archive has been saved
            foreach (Tuple<string, MemoryStream> item in entryData)
            {
                item.Item2.Dispose();
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to re‑package files from an existing ZIP into a 7z archive without writing intermediate files to disk.
 * 2. When you want to exclude folder entries and only compress actual files from a ZIP for a smaller 7z output.
 * 3. When a web service receives a ZIP upload and must return a 7z version directly from memory for faster response.
 * 4. When you are building a backup tool that transforms legacy ZIP backups into modern 7z archives while preserving file names.
 * 5. When you need to integrate Aspose.Zip with SevenZip to convert archives in a CI pipeline without creating temporary files.
 */
