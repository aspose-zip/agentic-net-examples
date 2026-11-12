// HOW-TO: Delete Specific Files From a ZIP Archive In C# Using Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.zip";
            string outputPath = @"C:\Data\modified\sample_modified.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List of entry names to remove from the archive
            string[] entriesToDelete = new string[]
            {
                "document.txt",
                "images/photo.jpg",
                "folder/subfolder/notes.docx"
            };

            // Open the source archive
            using (Archive archive = new Archive(inputPath))
            {
                // Iterate over the list and delete matching entries
                foreach (string entryName in entriesToDelete)
                {
                    ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase));
                    if (entry != null)
                    {
                        archive.DeleteEntry(entry);
                    }
                }

                // Save the modified archive to the output path
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
 * 1. When you need to programmatically remove confidential documents from an existing ZIP before sharing it with external partners.
 * 2. When a build pipeline must strip out large media files from a packaged archive to reduce deployment size.
 * 3. When an application cleans up outdated logs stored inside a ZIP to keep the archive lightweight.
 * 4. When a migration tool deletes obsolete configuration files from a backup ZIP before importing it into a new system.
 * 5. When a user interface allows end‑users to select and permanently erase selected items from a compressed archive without extracting it.
 */
