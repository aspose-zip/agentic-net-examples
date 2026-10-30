// HOW-TO: Flatten Nested ZIP Files and Export Removed Entry List to CSV in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.zip";
            string outputPath = "flattened.zip";
            string csvPath = "removed_entries.csv";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(csvPath) ?? ".");

            // Collections for processing
            List<ArchiveEntry> entriesToDelete = new List<ArchiveEntry>();
            List<string> namesToInsert = new List<string>();
            List<MemoryStream> contentToInsert = new List<MemoryStream>();
            List<string> removedEntryNames = new List<string>();

            // Open the outer archive
            using (Archive outer = new Archive(inputPath))
            {
                // Identify nested zip entries
                foreach (ArchiveEntry entry in outer.Entries)
                {
                    if (entry.Name.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        entriesToDelete.Add(entry);
                        removedEntryNames.Add(entry.Name);

                        // Extract nested zip into memory
                        using (MemoryStream innerCompressed = new MemoryStream())
                        {
                            entry.Open().CopyTo(innerCompressed);
                            innerCompressed.Position = 0;

                            // Open the inner archive from memory
                            using (Archive inner = new Archive(innerCompressed))
                            {
                                foreach (ArchiveEntry innerEntry in inner.Entries)
                                {
                                    namesToInsert.Add(innerEntry.Name);
                                    MemoryStream content = new MemoryStream();
                                    innerEntry.Open().CopyTo(content);
                                    content.Position = 0;
                                    contentToInsert.Add(content);
                                }
                            }
                        }
                    }
                }

                // Remove the original nested zip entries
                foreach (ArchiveEntry e in entriesToDelete)
                {
                    outer.DeleteEntry(e);
                }

                // Insert flattened entries into the outer archive
                for (int i = 0; i < namesToInsert.Count; i++)
                {
                    outer.CreateEntry(namesToInsert[i], contentToInsert[i]);
                }

                // Save the modified archive
                outer.Save(outputPath);
            }

            // Write CSV listing of removed entries
            using (StreamWriter writer = new StreamWriter(csvPath, false, Encoding.UTF8))
            {
                writer.WriteLine("RemovedEntryName");
                foreach (string name in removedEntryNames)
                {
                    writer.WriteLine(name);
                }
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
 * 1. When you receive a zip package that contains other zip files and need to produce a single flat archive while keeping a record of the removed inner archives.
 * 2. When you want to simplify deployment by extracting nested zip modules, deleting them from the original archive, and generating a CSV audit log of the deleted entries.
 * 3. When an automated build pipeline must flatten bundled resources and provide a report of all eliminated nested zip entries for compliance tracking.
 * 4. When a data migration script has to consolidate multiple compressed layers into one archive and output a spreadsheet‑compatible list of the discarded inner archives.
 * 5. When you need to clean up a backup archive by removing embedded zip files and creating a CSV file that lists the names of those removed entries for later review.
 */
