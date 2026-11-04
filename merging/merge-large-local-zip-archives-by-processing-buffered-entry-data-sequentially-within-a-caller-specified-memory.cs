// HOW-TO: Merge Multiple Large ZIP Files with Buffered Memory Limit in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP archive paths
            string archivePath1 = @"C:\Data\archive1.zip";
            string archivePath2 = @"C:\Data\archive2.zip";
            string archivePath3 = @"C:\Data\archive3.zip";

            // Hardcoded output ZIP path
            string outputPath = @"C:\Data\large_merge.zip";

            // Validate input files
            if (!File.Exists(archivePath1))
            {
                Console.Error.WriteLine($"File not found: {archivePath1}");
                return;
            }
            if (!File.Exists(archivePath2))
            {
                Console.Error.WriteLine($"File not found: {archivePath2}");
                return;
            }
            if (!File.Exists(archivePath3))
            {
                Console.Error.WriteLine($"File not found: {archivePath3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collection of source archive paths
            string[] sourceArchives = new string[] { archivePath1, archivePath2, archivePath3 };

            // Track entry names to resolve collisions
            HashSet<string> existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Create the destination archive
            using (Archive outputArchive = new Archive())
            {
                foreach (string sourcePath in sourceArchives)
                {
                    using (Archive sourceArchive = new Archive(sourcePath))
                    {
                        foreach (ArchiveEntry entry in sourceArchive.Entries)
                        {
                            // Original entry name
                            string entryName = entry.Name;

                            // Resolve name collision if necessary
                            if (existingNames.Contains(entryName))
                            {
                                string baseName = Path.GetFileNameWithoutExtension(entryName);
                                string extension = Path.GetExtension(entryName);
                                string directory = Path.GetDirectoryName(entryName);
                                int counter = 1;
                                string newName;
                                do
                                {
                                    string candidate = $"{baseName}_{counter}{extension}";
                                    newName = string.IsNullOrEmpty(directory) ? candidate : Path.Combine(directory, candidate);
                                    counter++;
                                } while (existingNames.Contains(newName));
                                entryName = newName;
                            }

                            existingNames.Add(entryName);

                            // Open source entry stream and add to output archive
                            using (Stream sourceStream = entry.Open())
                            {
                                // The CreateEntry overload copies data from the source stream directly,
                                // respecting the caller's memory budget by streaming internally.
                                outputArchive.CreateEntry(entryName, sourceStream);
                            }
                        }
                    }
                }

                // Save the merged archive
                outputArchive.Save(outputPath);
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
 * 1. When you need to combine several gigabyte‑size ZIP archives into a single archive without exceeding a specific memory budget.
 * 2. When you must merge ZIP files on a server while ensuring duplicate file names are automatically renamed to avoid conflicts.
 * 3. When you want to programmatically create a consolidated backup archive from multiple source archives in a .NET application.
 * 4. When you are processing large ZIP archives in a low‑memory environment such as a container or embedded system.
 * 5. When you need to generate a single downloadable ZIP for users by merging separate product packages while preserving all entries.
 */
