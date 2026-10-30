// HOW-TO: Flatten Nested ZIP Files and Remove Inner Archives in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.zip";
            string outputPath = "output.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the outer archive
            using (Archive outer = new Archive(inputPath))
            {
                // Lists to hold entries to delete and new entries to add
                List<ArchiveEntry> entriesToDelete = new List<ArchiveEntry>();
                List<string> namesToInsert = new List<string>();
                List<MemoryStream> contentToInsert = new List<MemoryStream>();

                // Scan for nested zip entries
                foreach (ArchiveEntry entry in outer.Entries)
                {
                    if (entry.Name.EndsWith(".zip", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // Mark the nested zip for removal
                        entriesToDelete.Add(entry);

                        // Read the nested zip into memory
                        using (MemoryStream innerCompressed = new MemoryStream())
                        {
                            entry.Open().CopyTo(innerCompressed);
                            innerCompressed.Position = 0;

                            // Open the inner archive from the memory stream
                            using (Archive inner = new Archive(innerCompressed))
                            {
                                // Extract each entry from the inner archive
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

                // Delete the original nested zip entries
                foreach (ArchiveEntry e in entriesToDelete)
                {
                    outer.DeleteEntry(e);
                }

                // Add the extracted entries to the outer archive
                for (int i = 0; i < namesToInsert.Count; i++)
                {
                    outer.CreateEntry(namesToInsert[i], contentToInsert[i]);
                }

                // Save the cleaned archive
                outer.Save(outputPath);

                // Dispose the temporary content streams
                foreach (MemoryStream ms in contentToInsert)
                {
                    ms.Dispose();
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
 * 1. When you receive a ZIP package that contains other ZIP files and need a single‑level archive for easier distribution.
 * 2. When an automated build process must combine files from nested archives into one flat ZIP before uploading to cloud storage.
 * 3. When a data migration script has to extract contents of embedded ZIPs and discard the original nested archives to reduce storage size.
 * 4. When a backup utility must flatten nested archives to ensure compatibility with systems that cannot handle multi‑level ZIP structures.
 * 5. When a compliance audit requires removing embedded archives from a ZIP to prevent hidden files from being concealed inside nested containers.
 */
