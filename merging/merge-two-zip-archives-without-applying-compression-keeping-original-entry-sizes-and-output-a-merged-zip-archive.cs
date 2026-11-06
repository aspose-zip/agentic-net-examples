// HOW-TO: Merge Two ZIP Files Without Compression Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = "C:\\Data\\archive1.zip";
            string inputPath2 = "C:\\Data\\archive2.zip";
            string outputPath = "C:\\Data\\merged.zip";

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to keep entry streams alive until the archive is saved
            List<MemoryStream> entryStreams = new List<MemoryStream>();

            // Create a new archive with Store (no compression) settings
            using (Archive mergedArchive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
            {
                // Local function to copy entries from a source archive
                Action<string> copyFromArchive = (string sourcePath) =>
                {
                    using (Archive sourceArchive = new Archive(sourcePath))
                    {
                        foreach (ArchiveEntry entry in sourceArchive.Entries)
                        {
                            // Skip directory entries
                            if (entry.IsDirectory)
                                continue;

                            // Open the source entry stream
                            using (Stream sourceStream = entry.Open())
                            {
                                // Read entry data into a memory stream
                                MemoryStream ms = new MemoryStream();
                                sourceStream.CopyTo(ms);
                                ms.Position = 0; // Reset position for reading

                                // Keep the memory stream alive
                                entryStreams.Add(ms);

                                // Add entry to the merged archive without compression
                                mergedArchive.CreateEntry(entry.Name, ms);
                            }
                        }
                    }
                };

                // Copy entries from both source archives
                copyFromArchive(inputPath1);
                copyFromArchive(inputPath2);

                // Save the merged archive to the output file
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    mergedArchive.Save(outStream, new ArchiveSaveOptions());
                }
            }

            // Dispose entry streams after saving
            foreach (MemoryStream ms in entryStreams)
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
 * 1. When you need to combine multiple backup ZIP archives into a single archive while preserving the original file sizes and avoiding any additional compression overhead.
 * 2. When you want to create a consolidated package of log files from separate ZIP bundles for easier distribution without altering their stored data.
 * 3. When you are building a deployment tool that merges feature‑specific ZIP resources into one installer archive while keeping the entries stored as‑is.
 * 4. When you must concatenate archived datasets from different sources for archival compliance, ensuring the entries remain uncompressed for fast random access.
 * 5. When you are developing a file‑transfer service that joins client‑provided ZIP parts into a final ZIP without recompressing the content to maintain integrity and speed.
 */
