// HOW-TO: Merge Multiple ZIP Files into a Single Archive Using Aspose.Zip C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded source archive paths
            string sourceArchivePath1 = @"C:\Data\archive1.zip";
            string sourceArchivePath2 = @"C:\Data\archive2.zip";
            string sourceArchivePath3 = @"C:\Data\archive3.zip";

            // Verify each source archive exists
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

            // Output merged archive path
            string outputPath = @"C:\Data\merged.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create an empty archive that will hold merged entries
            using (Archive mergedArchive = new Archive())
            {
                // Array of source archive paths for iteration
                string[] sourceArchives = new string[] { sourceArchivePath1, sourceArchivePath2, sourceArchivePath3 };

                foreach (string srcPath in sourceArchives)
                {
                    // Open each source archive
                    using (Archive srcArchive = new Archive(srcPath))
                    {
                        // Iterate through all entries in the source archive
                        foreach (ArchiveEntry srcEntry in srcArchive.Entries)
                        {
                            // Read the entry content into a memory stream
                            using (MemoryStream entryData = new MemoryStream())
                            {
                                using (Stream entryStream = srcEntry.Open())
                                {
                                    entryStream.CopyTo(entryData);
                                }
                                entryData.Position = 0;

                                // Add the entry to the merged archive with the same name
                                mergedArchive.CreateEntry(srcEntry.Name, entryData);
                            }
                        }
                    }
                }

                // Save the merged archive to the output path
                mergedArchive.Save(outputPath);
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
 * 1. When you need to combine several backup zip files into one consolidated archive for easier distribution or storage.
 * 2. When a deployment pipeline must gather assets from multiple module zip packages into a single release bundle.
 * 3. When a user downloads separate zip parts of a large dataset and you want to merge them into one file before processing.
 * 4. When an application archives logs from different services daily and then merges them into a master zip for archival compliance.
 * 5. When a cloud function receives multiple zip attachments and must create a single combined zip to send to another service.
 */
