// HOW-TO: Extract ZIP Files to Memory and Create PPMd 7z Archive in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP file and output 7z file paths
            string inputZipPath = @"C:\Data\input.zip";
            string output7zPath = @"C:\Data\output.7z";

            // Validate input file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath));

            // List to hold entry names and their in‑memory data
            List<(string Name, MemoryStream Data)> entries = new List<(string, MemoryStream)>();

            // Open the ZIP archive and read each entry into memory
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    using (Stream entryStream = zipEntry.Open())
                    {
                        MemoryStream memory = new MemoryStream();
                        entryStream.CopyTo(memory);
                        memory.Position = 0; // Reset for later reading
                        entries.Add((zipEntry.Name, memory));
                    }
                }
            }

            // Create a 7z archive with PPMd compression for all entries
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(new SevenZipPPMdCompressionSettings());
            using (SevenZipArchive sevenZip = new SevenZipArchive(entrySettings))
            {
                foreach ((string name, MemoryStream data) in entries)
                {
                    // Add each in‑memory entry to the 7z archive
                    sevenZip.CreateEntry(name, data);
                }

                // Save the 7z archive to the specified output path
                sevenZip.Save(output7zPath);
            }

            // Dispose all memory streams after saving
            foreach ((_, MemoryStream data) in entries)
            {
                data.Dispose();
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
 * 1. When you need to read the contents of a ZIP file into memory, re‑compress them with high‑ratio PPMd, and deliver a single 7z package to a client application.
 * 2. When a build pipeline must convert legacy ZIP assets into a 7z archive for reduced size before uploading to cloud storage.
 * 3. When an automated backup system extracts files from an incoming ZIP, processes them in memory, and stores them in a PPMd‑compressed 7z file for long‑term retention.
 * 4. When a desktop utility offers users the ability to merge multiple ZIP entries into a single 7z archive with advanced compression without writing temporary files to disk.
 * 5. When a server‑side service receives ZIP uploads, needs to validate and recompress the data using PPMd to meet compliance or bandwidth constraints before saving the archive.
 */
