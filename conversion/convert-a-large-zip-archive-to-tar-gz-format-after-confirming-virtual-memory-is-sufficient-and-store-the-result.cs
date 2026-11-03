// HOW-TO: Convert Large ZIP to TAR.GZ in C# After Memory Check (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\large.zip";
            string outputPath = @"C:\Data\large.tar.gz";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Check available virtual memory (example threshold: 500 MB)
            long availableMemory = GC.GetGCMemoryInfo().TotalAvailableMemoryBytes;
            const long requiredMemory = 500L * 1024 * 1024; // 500 MB
            if (availableMemory < requiredMemory)
            {
                Console.Error.WriteLine("Insufficient virtual memory to perform conversion.");
                return;
            }

            // List to hold entry streams until the TAR archive is saved
            List<Stream> entryStreams = new List<Stream>();

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputPath))
            {
                // Create a new TAR archive
                using (TarArchive tarArchive = new TarArchive())
                {
                    // Iterate through ZIP entries and add them to the TAR archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        if (!zipEntry.IsDirectory)
                        {
                            // Open the ZIP entry stream (keep open until TAR save completes)
                            Stream entryStream = zipEntry.Open();
                            entryStreams.Add(entryStream);

                            // Add entry to TAR archive with the same name
                            tarArchive.CreateEntry(zipEntry.Name, entryStream);
                        }
                    }

                    // Save the TAR archive with GZIP compression
                    tarArchive.SaveGzipped(outputPath);
                }
            }

            // Dispose all entry streams after saving
            foreach (Stream s in entryStreams)
            {
                s.Dispose();
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
 * 1. When you need to migrate a massive ZIP backup to a TAR.GZ archive for Linux‑based storage while ensuring the system has enough virtual memory.
 * 2. When an automated deployment pipeline must repackage downloaded ZIP assets into compressed TAR files to meet target server requirements.
 * 3. When a data‑archiving service converts user‑uploaded ZIP files to TAR.GZ to reduce storage costs and maintain cross‑platform compatibility.
 * 4. When a backup utility validates available memory before converting large ZIP archives to TAR.GZ to avoid out‑of‑memory crashes.
 * 5. When a C# application prepares archives for long‑term archival by transforming ZIP collections into TAR.GZ after confirming sufficient resources.
 */
