// HOW-TO: Merge Two Zip Archives In Memory While Preserving Folder Hierarchy In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath1 = @"C:\Data\archive1.zip";
            string inputPath2 = @"C:\Data\archive2.zip";
            string outputPath = @"C:\Data\merged.zip";

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

            // Load first archive into memory
            byte[] archiveBytes1 = File.ReadAllBytes(inputPath1);
            using (MemoryStream ms1 = new MemoryStream(archiveBytes1))
            using (Archive archive1 = new Archive(ms1))
            // Load second archive into memory
            using (MemoryStream ms2 = new MemoryStream(File.ReadAllBytes(inputPath2)))
            using (Archive archive2 = new Archive(ms2))
            // Create a new archive for the merged result
            using (Archive mergedArchive = new Archive())
            {
                // Append entries from the first archive
                foreach (ArchiveEntry entry in archive1.Entries)
                {
                    using (Stream entryStream = entry.Open())
                    {
                        mergedArchive.CreateEntry(entry.Name, entryStream);
                    }
                }

                // Append entries from the second archive
                foreach (ArchiveEntry entry in archive2.Entries)
                {
                    using (Stream entryStream = entry.Open())
                    {
                        mergedArchive.CreateEntry(entry.Name, entryStream);
                    }
                }

                // Save the merged archive to the output path
                mergedArchive.Save(outputPath);
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
 * 1. When you need to combine multiple zip packages into a single archive without losing their internal folder structure, such as bundling separate project releases.
 * 2. When you want to merge user‑uploaded zip files on a server before sending a consolidated download link.
 * 3. When building a backup utility that consolidates daily zip snapshots into one master archive while keeping each snapshot’s directory layout.
 * 4. When integrating third‑party zip resources into your application’s deployment package without extracting them to disk.
 * 5. When creating a downloadable bundle that includes documentation and binaries stored in separate zip files, ensuring the original hierarchy is retained.
 */
