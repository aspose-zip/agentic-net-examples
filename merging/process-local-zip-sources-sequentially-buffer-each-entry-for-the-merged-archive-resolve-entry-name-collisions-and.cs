// HOW-TO: Merge Multiple ZIP Files Sequentially with Name Collision Handling in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP file paths
            string sourceArchivePath1 = @"C:\Data\source1.zip";
            string sourceArchivePath2 = @"C:\Data\source2.zip";
            string sourceArchivePath3 = @"C:\Data\source3.zip";

            // Verify each input file exists
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
            if (!File.Exists(sourceArchivePath3))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath3}");
                return;
            }

            // Hardcoded output ZIP file path
            string outputPath = @"C:\Data\sequential_merge.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collection of source archive paths
            string[] sourceArchives = new string[] { sourceArchivePath1, sourceArchivePath2, sourceArchivePath3 };

            // Keep track of entry names to resolve collisions
            HashSet<string> existingEntryNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Create a new empty archive for merging
            using (Archive mergedArchive = new Archive())
            {
                foreach (string sourcePath in sourceArchives)
                {
                    // Open each source archive
                    using (Archive sourceArchive = new Archive(sourcePath))
                    {
                        foreach (ArchiveEntry entry in sourceArchive.Entries)
                        {
                            // Determine a unique entry name
                            string originalName = entry.Name;
                            string uniqueName = originalName;
                            int duplicateIndex = 1;
                            while (existingEntryNames.Contains(uniqueName))
                            {
                                string nameWithoutExt = Path.GetFileNameWithoutExtension(originalName);
                                string ext = Path.GetExtension(originalName);
                                uniqueName = $"{nameWithoutExt}_{duplicateIndex}{ext}";
                                duplicateIndex++;
                            }
                            existingEntryNames.Add(uniqueName);

                            // Read entry data into memory
                            using (Stream entryStream = entry.Open())
                            {
                                using (MemoryStream memory = new MemoryStream())
                                {
                                    entryStream.CopyTo(memory);
                                    memory.Position = 0;

                                    // Add the entry to the merged archive
                                    mergedArchive.CreateEntry(uniqueName, memory);
                                }
                            }
                        }
                    }
                }

                // Save the merged archive
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
 * 1. When you need to combine several project ZIP packages into a single archive for easier distribution while preserving the order of files.
 * 2. When duplicate file names exist across source ZIPs and you must automatically rename or skip them to avoid overwriting during the merge.
 * 3. When you want to create a consolidated backup of multiple log archives without loading all entries into memory at once.
 * 4. When a build pipeline must generate a single deployment bundle from separate component ZIPs using Aspose.Zip in C#.
 * 5. When an application has to read ZIP files sequentially, buffer each entry, and write them into a new archive on disk for later extraction.
 */
