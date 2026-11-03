// HOW-TO: Convert Multiple ZIP Files To 7Z Archives In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP files and output directory
            string[] zipFiles = new string[]
            {
                @"C:\Input\archive1.zip",
                @"C:\Input\archive2.zip"
            };
            string outputDirectory = @"C:\Output";

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            foreach (string zipPath in zipFiles)
            {
                // Verify input ZIP file exists
                if (!File.Exists(zipPath))
                {
                    Console.Error.WriteLine($"File not found: {zipPath}");
                    return;
                }

                // Determine output 7z path
                string outputPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(zipPath) + ".7z");

                // Ensure the output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                // Open the source ZIP archive
                using (Archive zipArchive = new Archive(zipPath))
                {
                    // Create a new 7z archive
                    using (SevenZipArchive sevenZip = new SevenZipArchive())
                    {
                        // Keep entry streams open until the 7z archive is saved
                        List<Stream> openStreams = new List<Stream>();

                        foreach (ArchiveEntry entry in zipArchive.Entries)
                        {
                            // Open the entry stream from the ZIP archive
                            Stream entryStream = entry.Open();
                            openStreams.Add(entryStream);

                            // Add the entry to the 7z archive using the same name and stream
                            sevenZip.CreateEntry(entry.Name, entryStream);
                        }

                        // Save the 7z archive to the output path
                        sevenZip.Save(outputPath);

                        // Dispose all entry streams after saving
                        foreach (Stream s in openStreams)
                        {
                            s.Dispose();
                        }
                    }
                }

                Console.WriteLine($"Converted '{zipPath}' to '{outputPath}'.");
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
 * 1. When you need to reduce storage costs by re‑compressing a batch of ZIP backups into smaller 7z archives using C#.
 * 2. When migrating legacy ZIP archives to a 7z‑based distribution system that requires on‑the‑fly compression.
 * 3. When automating a nightly job that converts newly generated ZIP reports into 7z files for faster upload to cloud storage.
 * 4. When integrating a file‑processing pipeline that must read entries from existing ZIP files and immediately write them into 7z archives without intermediate extraction.
 * 5. When building a desktop utility that lets users select multiple ZIP archives and produce corresponding 7z files with a single click.
 */
