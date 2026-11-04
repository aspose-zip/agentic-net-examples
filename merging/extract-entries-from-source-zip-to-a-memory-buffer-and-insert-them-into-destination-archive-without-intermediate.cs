// HOW-TO: Copy ZIP Entries to New Archive Using Memory Streams in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string sourceZipPath = @"C:\Data\source.zip";
            string destZipPath = @"C:\Data\dest.zip";

            // Validate input file existence
            if (!File.Exists(sourceZipPath))
            {
                Console.Error.WriteLine($"File not found: {sourceZipPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(destZipPath);
            if (string.IsNullOrEmpty(outputDir))
            {
                outputDir = ".";
            }
            Directory.CreateDirectory(outputDir);

            // List to keep memory streams alive until the destination archive is saved
            List<MemoryStream> tempStreams = new List<MemoryStream>();

            // Open source archive for reading
            using (Archive sourceArchive = new Archive(sourceZipPath))
            {
                // Create a new destination archive
                using (Archive destArchive = new Archive())
                {
                    // Iterate over each entry in the source archive
                    foreach (ArchiveEntry entry in sourceArchive.Entries)
                    {
                        // Open the entry as a stream
                        using (Stream entryStream = entry.Open())
                        {
                            // Copy entry data to a memory buffer
                            MemoryStream ms = new MemoryStream();
                            entryStream.CopyTo(ms);
                            ms.Position = 0;

                            // Add the entry to the destination archive from the memory buffer
                            destArchive.CreateEntry(entry.Name, ms);

                            // Keep the memory stream for later disposal
                            tempStreams.Add(ms);
                        }
                    }

                    // Save the destination archive to the specified path
                    destArchive.Save(destZipPath);
                }
            }

            // Dispose all temporary memory streams
            foreach (MemoryStream ms in tempStreams)
            {
                ms.Dispose();
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
 * 1. When you need to merge files from an existing ZIP into a new archive without creating temporary files on disk.
 * 2. When you want to programmatically copy selected entries from a source ZIP to a destination archive while keeping the data in memory for faster processing.
 * 3. When you are building a web service that receives a ZIP upload, modifies its contents, and returns a new ZIP without writing intermediate files to the server.
 * 4. When you need to extract entries from a ZIP, transform them in memory, and re‑package them into another archive for secure or sandboxed environments.
 * 5. When you are implementing an in‑memory backup routine that consolidates multiple ZIP archives into a single archive without consuming additional disk space.
 */
