// HOW-TO: Flatten Nested ZIP Archive by Extracting and Repacking Files in C# (Aspose.ZIP for .NET)
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
            string inputPath = "Data\\nested.zip";
            string outputPath = "Data\\flattened.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Lists to hold entries to delete and new entries to insert
            List<ArchiveEntry> entriesToDelete = new List<ArchiveEntry>();
            List<string> namesToInsert = new List<string>();
            List<MemoryStream> contentToInsert = new List<MemoryStream>();

            // Open the outer archive
            using (Archive outer = new Archive(inputPath))
            {
                // Identify nested archive entries (e.g., .zip files)
                foreach (ArchiveEntry entry in outer.Entries)
                {
                    if (entry.Name.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        entriesToDelete.Add(entry);

                        // Copy the nested archive into a memory stream
                        using (MemoryStream innerCompressed = new MemoryStream())
                        {
                            using (Stream entryStream = entry.Open())
                            {
                                entryStream.CopyTo(innerCompressed);
                            }

                            // Open the nested archive from the memory stream
                            innerCompressed.Position = 0;
                            using (Archive inner = new Archive(innerCompressed))
                            {
                                // Extract each entry from the nested archive
                                foreach (ArchiveEntry innerEntry in inner.Entries)
                                {
                                    namesToInsert.Add(innerEntry.Name);
                                    MemoryStream content = new MemoryStream();
                                    using (Stream innerStream = innerEntry.Open())
                                    {
                                        innerStream.CopyTo(content);
                                    }
                                    content.Position = 0;
                                    contentToInsert.Add(content);
                                }
                            }
                        }
                    }
                }

                // Delete the original nested archive entries
                foreach (ArchiveEntry e in entriesToDelete)
                {
                    outer.DeleteEntry(e);
                }

                // Add extracted entries back into the outer archive
                for (int i = 0; i < namesToInsert.Count; i++)
                {
                    outer.CreateEntry(namesToInsert[i], contentToInsert[i]);
                }

                // Save the modified archive
                outer.Save(outputPath);
            }

            // Dispose the inserted content streams after saving
            foreach (MemoryStream ms in contentToInsert)
            {
                ms.Dispose();
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
 * 1. When you receive a ZIP file that contains other ZIP files and need a single‑level archive for easier distribution or processing.
 * 2. When an automated pipeline must unpack nested archives, remove the inner ZIP files, and create a new flat ZIP for downstream tools that cannot handle nested archives.
 * 3. When you want to reduce the number of archive entries before uploading to a cloud storage service that imposes a limit on nested archive depth.
 * 4. When preparing data for a legacy system that only reads files directly from the root of a ZIP and cannot navigate into embedded archives.
 * 5. When consolidating multiple compressed packages into one archive while preserving the original file hierarchy without the extra container ZIP layers.
 */
