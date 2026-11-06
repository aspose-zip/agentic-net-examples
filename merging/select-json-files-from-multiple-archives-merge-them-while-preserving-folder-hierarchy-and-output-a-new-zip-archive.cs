// HOW-TO: Merge JSON Files from Multiple ZIP Archives While Preserving Folder Structure in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string sourceArchivePath1 = "C:\\Data\\Archive1.zip";
            string sourceArchivePath2 = "C:\\Data\\Archive2.zip";
            string outputArchivePath = "C:\\Data\\MergedJsons.zip";

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
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Keep streams alive until the result archive is saved
            List<Tuple<string, MemoryStream>> entryStreams = new List<Tuple<string, MemoryStream>>();

            using (Archive resultArchive = new Archive())
            {
                // Process first source archive
                using (Archive source1 = new Archive(sourceArchivePath1))
                {
                    foreach (ArchiveEntry entry in source1.Entries)
                    {
                        if (entry.Name.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                        {
                            MemoryStream ms = new MemoryStream();
                            using (Stream entryStream = entry.Open())
                            {
                                entryStream.CopyTo(ms);
                            }
                            ms.Position = 0;
                            entryStreams.Add(Tuple.Create(entry.Name, ms));
                            resultArchive.CreateEntry(entry.Name, ms);
                        }
                    }
                }

                // Process second source archive
                using (Archive source2 = new Archive(sourceArchivePath2))
                {
                    foreach (ArchiveEntry entry in source2.Entries)
                    {
                        if (entry.Name.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                        {
                            // Avoid duplicate entry names
                            string targetName = entry.Name;
                            if (resultArchive.Entries.Any(e => e.Name == targetName))
                            {
                                string directory = Path.GetDirectoryName(targetName);
                                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(entry.Name);
                                string newFileName = fileNameWithoutExt + "_2.json";
                                targetName = string.IsNullOrEmpty(directory) ? newFileName : Path.Combine(directory, newFileName);
                            }

                            MemoryStream ms = new MemoryStream();
                            using (Stream entryStream = entry.Open())
                            {
                                entryStream.CopyTo(ms);
                            }
                            ms.Position = 0;
                            entryStreams.Add(Tuple.Create(targetName, ms));
                            resultArchive.CreateEntry(targetName, ms);
                        }
                    }
                }

                // Save the merged archive
                resultArchive.Save(outputArchivePath);
            }

            // Dispose all temporary streams
            foreach (Tuple<string, MemoryStream> tuple in entryStreams)
            {
                tuple.Item2.Dispose();
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
 * 1. When you need to combine configuration JSON files scattered across several deployment packages into a single archive for centralized processing.
 * 2. When a CI/CD pipeline must extract only .json resources from multiple build artifacts and repackage them while keeping their original directory layout.
 * 3. When a data migration tool has to gather JSON payloads from legacy zip backups and create a consolidated zip for import into a new system.
 * 4. When an application needs to generate a downloadable bundle that contains only the JSON settings from several plugin zip files without losing their folder hierarchy.
 * 5. When you want to automate the creation of a master zip containing all JSON reports from multiple archived log files for auditing purposes.
 */
