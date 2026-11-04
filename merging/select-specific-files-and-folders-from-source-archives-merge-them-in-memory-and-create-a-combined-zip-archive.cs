// HOW-TO: Merge Selected Folders from Multiple ZIP Files into One ZIP in C# (Aspose.ZIP for .NET)
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
            string sourceArchivePath1 = @"C:\Data\source1.zip";
            string sourceArchivePath2 = @"C:\Data\source2.zip";
            string outputPath = @"C:\Data\combined.zip";

            // Validate input files
            if (!File.Exists(sourceArchivePath1))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath1}");
                return;
            }
            if (!File.Exists(sourceArchivePath2))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold temporary streams that must stay alive until the archive is saved
            List<MemoryStream> tempStreams = new List<MemoryStream>();

            using (Archive source1 = new Archive(sourceArchivePath1))
            using (Archive source2 = new Archive(sourceArchivePath2))
            using (Archive combined = new Archive())
            {
                // Select entries from the first archive (e.g., entries under "folderA/")
                foreach (ArchiveEntry entry in source1.Entries)
                {
                    if (entry.Name.StartsWith("folderA/"))
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream ms = new MemoryStream();
                            entryStream.CopyTo(ms);
                            ms.Position = 0;
                            combined.CreateEntry(entry.Name, ms);
                            tempStreams.Add(ms);
                        }
                    }
                }

                // Select entries from the second archive (e.g., entries under "folderB/")
                foreach (ArchiveEntry entry in source2.Entries)
                {
                    if (entry.Name.StartsWith("folderB/"))
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream ms = new MemoryStream();
                            entryStream.CopyTo(ms);
                            ms.Position = 0;
                            combined.CreateEntry(entry.Name, ms);
                            tempStreams.Add(ms);
                        }
                    }
                }

                // Save the combined archive
                combined.Save(outputPath);
            }

            // Dispose temporary streams
            foreach (MemoryStream ms in tempStreams)
            {
                ms.Dispose();
            }

            Console.WriteLine($"Combined archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine only certain directories from several existing ZIP archives into a single package for distribution without extracting them to disk.
 * 2. When a build pipeline must gather specific resources from multiple third‑party ZIP bundles and create a consolidated archive for deployment.
 * 3. When an application has to programmatically merge selected files from user‑uploaded ZIP files into a new archive while keeping the operation in memory to improve performance.
 * 4. When you want to generate a combined ZIP containing only the required folders from backup archives to reduce download size for end users.
 * 5. When a data migration tool must extract particular subfolders from multiple ZIP sources and repackage them into one archive for easy import into another system.
 */
