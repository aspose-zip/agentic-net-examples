// HOW-TO: Extract ZIP to Memory and Create BZip2 7z Archive in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            // Validate input ZIP file
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(output7zPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            // Extract ZIP entries to memory
            List<(string Name, byte[] Data)> extractedEntries = new List<(string, byte[])>();
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    using (Stream entryStream = zipEntry.Open())
                    using (MemoryStream ms = new MemoryStream())
                    {
                        entryStream.CopyTo(ms);
                        extractedEntries.Add((zipEntry.Name, ms.ToArray()));
                    }
                }
            }

            // Create 7z archive with BZip2 compression for each entry
            using (SevenZipArchive sevenArchive = new SevenZipArchive())
            {
                foreach ((string name, byte[] data) in extractedEntries)
                {
                    MemoryStream entryDataStream = new MemoryStream(data);
                    SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(new SevenZipBZip2CompressionSettings());
                    sevenArchive.CreateEntry(name, entryDataStream, entrySettings);
                }

                // Save the 7z archive
                sevenArchive.Save(output7zPath);
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
 * 1. When you need to read files from an existing ZIP, compress each file with BZip2, and package them into a 7z archive without writing intermediate files to disk.
 * 2. When a cloud service must transform uploaded ZIP bundles into smaller 7z packages for efficient storage or transfer.
 * 3. When a backup utility wants to re‑compress extracted ZIP contents using BZip2 to meet a specific compression policy before archiving.
 * 4. When an application processes user‑provided ZIP archives in memory for security reasons and then creates a 7z archive for downstream processing.
 * 5. When a CI/CD pipeline needs to convert legacy ZIP artifacts into 7z format with BZip2 compression to reduce artifact size for artifact repositories.
 */
