// HOW-TO: Merge Multiple Zip Archives, Handle Name Collisions, Enforce Memory Limit In C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string[] sourceArchives = new string[]
            {
                dataDir + "archive1.zip",
                dataDir + "archive2.zip"
            };
            string outputPath = dataDir + "combined.zip";

            // Memory budget (bytes)
            long memoryBudgetBytes = 100L * 1024 * 1024; // 100 MB

            // Verify input archives exist
            foreach (string srcPath in sourceArchives)
            {
                if (!File.Exists(srcPath))
                {
                    Console.Error.WriteLine($"File not found: {srcPath}");
                    return;
                }
            }

            // Check total size against budget
            long totalSize = 0;
            foreach (string srcPath in sourceArchives)
            {
                FileInfo fi = new FileInfo(srcPath);
                totalSize += fi.Length;
            }

            if (totalSize > memoryBudgetBytes)
            {
                Console.Error.WriteLine($"Total size {totalSize} exceeds memory budget of {memoryBudgetBytes} bytes.");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Merge archives
            using (Archive resultArchive = new Archive())
            {
                HashSet<string> existingNames = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

                foreach (string srcPath in sourceArchives)
                {
                    using (Archive srcArchive = new Archive(srcPath))
                    {
                        foreach (ArchiveEntry entry in srcArchive.Entries)
                        {
                            string entryName = entry.Name;

                            // Resolve name collisions
                            if (existingNames.Contains(entryName))
                            {
                                int suffix = 1;
                                string baseName = Path.GetFileNameWithoutExtension(entryName);
                                string ext = Path.GetExtension(entryName);
                                string dir = Path.GetDirectoryName(entryName);
                                string newName;
                                do
                                {
                                    string candidate = $"{baseName}_dup{suffix}{ext}";
                                    newName = string.IsNullOrEmpty(dir) ? candidate : Path.Combine(dir, candidate);
                                    suffix++;
                                } while (existingNames.Contains(newName));
                                entryName = newName;
                            }

                            existingNames.Add(entryName);

                            // Extract entry to memory and add to result archive
                            using (MemoryStream ms = new MemoryStream())
                            {
                                entry.Extract(ms);
                                ms.Position = 0;
                                resultArchive.CreateEntry(entryName, ms);
                            }
                        }
                    }
                }

                // Save combined archive
                resultArchive.Save(outputPath);
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
 * 1. When you need to combine several zip packages into a single archive while ensuring the total size stays within a predefined memory budget.
 * 2. When you must merge zip files that may contain files with the same name and want to prevent duplicate entry errors by detecting name collisions.
 * 3. When an application processes user‑uploaded zip bundles and must create a consolidated archive without exceeding server memory limits.
 * 4. When automating backup routines that gather multiple zip snapshots into one file and need to verify available memory before compression.
 * 5. When building a deployment tool that assembles component zip archives into a final package while safely handling large file sizes.
 */
