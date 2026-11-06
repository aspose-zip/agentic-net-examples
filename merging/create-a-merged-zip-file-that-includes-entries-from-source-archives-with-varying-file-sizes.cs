// HOW-TO: Merge Multiple ZIP Files into a Single Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string sourceArchivePath1 = @"C:\Data\source1.zip";
            string sourceArchivePath2 = @"C:\Data\source2.zip";
            string mergedArchivePath = @"C:\Data\merged.zip";

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
            Directory.CreateDirectory(Path.GetDirectoryName(mergedArchivePath));

            // Create the destination archive
            using (Archive mergedArchive = new Archive())
            {
                // Process first source archive
                using (Archive sourceArchive1 = new Archive(sourceArchivePath1))
                {
                    foreach (ArchiveEntry entry in sourceArchive1.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            mergedArchive.CreateEntry(entry.Name, entryStream);
                        }
                    }
                }

                // Process second source archive
                using (Archive sourceArchive2 = new Archive(sourceArchivePath2))
                {
                    foreach (ArchiveEntry entry in sourceArchive2.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            mergedArchive.CreateEntry(entry.Name, entryStream);
                        }
                    }
                }

                // Save the merged archive
                mergedArchive.Save(mergedArchivePath);
            }

            Console.WriteLine("Merged archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine several backup zip files into one consolidated archive for easier distribution.
 * 2. When you want to package resources from different modules into a single zip before uploading to cloud storage.
 * 3. When you have generated separate zip reports for different departments and must merge them for a master report.
 * 4. When you need to create a unified installer by merging component zip packages without losing any file size information.
 * 5. When you are consolidating log archives from multiple servers into one zip for long‑term retention.
 */
