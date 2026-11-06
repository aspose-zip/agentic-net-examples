// HOW-TO: Merge Multiple ZIP Files In Memory And Resolve Duplicate Entries In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory and archive paths
            string dataDir = @"C:\Data\Zips\";
            string[] sourceArchives = new string[]
            {
                dataDir + "archive1.zip",
                dataDir + "archive2.zip"
            };
            string outputPath = dataDir + "merged.zip";

            // Validate input archives
            foreach (string srcPath in sourceArchives)
            {
                if (!File.Exists(srcPath))
                {
                    Console.Error.WriteLine($"File not found: {srcPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Prepare structures for merging
            HashSet<string> existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            List<MemoryStream> tempStreams = new List<MemoryStream>();

            using (Archive mergedArchive = new Archive())
            {
                foreach (string srcPath in sourceArchives)
                {
                    using (Archive srcArchive = new Archive(srcPath))
                    {
                        foreach (ArchiveEntry srcEntry in srcArchive.Entries)
                        {
                            string originalName = srcEntry.Name;
                            string finalName = originalName;
                            int duplicateIndex = 1;

                            // Resolve name collisions
                            while (existingNames.Contains(finalName))
                            {
                                string nameWithoutExt = Path.GetFileNameWithoutExtension(originalName);
                                string ext = Path.GetExtension(originalName);
                                finalName = $"{nameWithoutExt}_{duplicateIndex}{ext}";
                                duplicateIndex++;
                            }

                            existingNames.Add(finalName);

                            // Read entry into memory
                            using (Stream entryStream = srcEntry.Open())
                            {
                                MemoryStream ms = new MemoryStream();
                                entryStream.CopyTo(ms);
                                ms.Position = 0;

                                // Add entry to merged archive using in‑memory buffer
                                mergedArchive.CreateEntry(finalName, ms);
                                tempStreams.Add(ms);
                            }
                        }
                    }
                }

                // Save merged archive
                mergedArchive.Save(outputPath);
            }

            // Dispose temporary memory streams
            foreach (MemoryStream ms in tempStreams)
            {
                ms.Dispose();
            }

            Console.WriteLine($"Merged archive created at: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine several ZIP archives into a single file without creating temporary files on disk.
 * 2. When you must ensure that files with the same name from different archives do not overwrite each other in the merged ZIP.
 * 3. When you want to merge ZIP contents in a .NET application while keeping the operation fast by using memory streams.
 * 4. When you are building a deployment package that aggregates resources from multiple source ZIPs into one archive.
 * 5. When you need to programmatically create a consolidated backup ZIP from several existing archives on a server.
 */
