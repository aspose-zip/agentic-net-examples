// HOW-TO: Extract .Txt Files From a Zip And Create New Archive In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output archive paths
            string inputArchivePath = "input.zip";
            string outputArchivePath = "output.zip";

            // Verify input archive exists
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Ensure output directory exists (if any)
            string outputDir = Path.GetDirectoryName(outputArchivePath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the source archive
            using (Archive sourceArchive = new Archive(inputArchivePath))
            {
                // Create a new archive for the moved entries
                using (Archive targetArchive = new Archive())
                {
                    // Iterate over a copy of the entries list because we will modify the collection
                    ArchiveEntry[] entries = new ArchiveEntry[sourceArchive.Entries.Count];
                    sourceArchive.Entries.CopyTo(entries, 0);

                    foreach (ArchiveEntry entry in entries)
                    {
                        // Check file extension (case‑insensitive)
                        if (entry.Name != null && entry.Name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                        {
                            // Read entry data into a memory stream
                            using (Stream entryStream = entry.Open())
                            using (MemoryStream ms = new MemoryStream())
                            {
                                entryStream.CopyTo(ms);
                                ms.Position = 0; // Reset stream position for reading

                                // Add the entry to the target archive
                                targetArchive.CreateEntry(entry.Name, ms);
                            }

                            // Remove the entry from the source archive
                            sourceArchive.DeleteEntry(entry);
                        }
                    }

                    // Save the new archive containing the moved entries
                    targetArchive.Save(outputArchivePath);
                }

                // Save the modified source archive (entries removed)
                sourceArchive.Save(inputArchivePath);
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
 * 1. When you need to extract all .txt reports from a large ZIP and package them into a separate archive for easier distribution.
 * 2. When you want to isolate configuration files (.txt) from a backup archive before sending the rest to long‑term storage.
 * 3. When a build pipeline must filter source code comments stored as .txt files and create a lightweight archive for code review.
 * 4. When an application must separate user‑generated text logs from other resources in a downloaded ZIP to comply with data‑retention policies.
 * 5. When you have to programmatically move documentation files (.txt) from an existing archive into a new compressed package for versioning.
 */
