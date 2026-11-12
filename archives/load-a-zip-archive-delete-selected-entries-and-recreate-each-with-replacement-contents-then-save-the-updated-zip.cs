// HOW-TO: Replace Specific Files in a ZIP Archive Using Aspose.Zip C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output ZIP file paths
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

            // Open the existing ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                // Define entries to replace and their new contents
                var replacements = new (string EntryName, string NewContent)[]
                {
                    ("file1.txt", "This is the new content for file1."),
                    ("folder/file2.txt", "Updated content for file2 inside a folder.")
                };

                foreach (var (entryName, newContent) in replacements)
                {
                    // Find the existing entry by name
                    ArchiveEntry existingEntry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase));

                    // Delete the entry if it exists
                    if (existingEntry != null)
                    {
                        archive.DeleteEntry(existingEntry);
                    }

                    // Create a new entry with the same name and replacement content
                    byte[] contentBytes = Encoding.UTF8.GetBytes(newContent);
                    using (MemoryStream ms = new MemoryStream(contentBytes))
                    {
                        archive.CreateEntry(entryName, ms);
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
 * 1. When you need to update the contents of particular files inside an existing ZIP without recreating the whole archive, you can delete and replace those entries using Aspose.Zip in C#.
 * 2. When a deployment package must have its configuration files refreshed automatically before distribution, this code lets you modify those entries directly in the ZIP.
 * 3. When a backup system requires swapping out outdated log files with newer versions while preserving the archive structure, you can use this approach to replace the entries.
 * 4. When generating a downloadable archive that includes dynamically generated reports, you can insert or overwrite specific report files in the ZIP on the fly.
 * 5. When maintaining a versioned document bundle and you need to patch only selected documents without extracting the entire archive, this method updates the chosen entries efficiently.
 */
