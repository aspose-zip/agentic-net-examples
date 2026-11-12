// HOW-TO: Remove Non‑Archive Files From ZIP While Keeping Nested Archives In C# (Aspose.ZIP for .NET)
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
            string inputPath = "C:\\Data\\input.zip";
            string outputPath = "C:\\Data\\output.zip";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Open the source ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                // Define archive file extensions to preserve
                HashSet<string> archiveExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".zip", ".7z", ".tar", ".gz", ".bz2", ".xz", ".iso",
                    ".cab", ".arj", ".lz", ".lzma", ".zst", ".z", ".rar"
                };

                // Collect entries that are not archives
                List<ArchiveEntry> entriesToDelete = new List<ArchiveEntry>();
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string extension = Path.GetExtension(entry.Name);
                    if (!archiveExtensions.Contains(extension))
                    {
                        entriesToDelete.Add(entry);
                    }
                }

                // Delete non‑archive entries
                foreach (ArchiveEntry entryToDelete in entriesToDelete)
                {
                    archive.DeleteEntry(entryToDelete);
                }

                // Save the modified archive
                archive.Save(outputPath);
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
 * 1. When you need to clean a distribution package by deleting all regular files but preserving embedded archive files for later extraction.
 * 2. When processing a backup ZIP that contains other archives and you want to discard logs, documents, and other non‑archive items before uploading to cloud storage.
 * 3. When creating a minimal archive for a CI pipeline that should only include nested archives such as .zip or .tar, removing source code and resource files that are not required.
 * 4. When preparing a ZIP to be sent to a third‑party system that only accepts archive files inside the package, so you strip out all other file types.
 * 5. When automating compliance checks that require only archive formats to remain in a ZIP, eliminating any prohibited file types before final archiving.
 */
