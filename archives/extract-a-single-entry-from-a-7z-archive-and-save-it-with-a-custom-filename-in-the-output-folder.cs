// HOW-TO: Extract a Specific File from 7z Archive with Custom Name in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string inputArchivePath = "input.7z";
        string entryName = "file.txt";
        string outputFolder = "output";
        string customFileName = "extracted_custom.txt";
        string outputPath = Path.Combine(outputFolder, customFileName);

        try
        {
            // Validate input archive existence
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the 7z archive
            using (SevenZipArchive archive = new SevenZipArchive(inputArchivePath))
            {
                // Find the entry to extract
                SevenZipArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract the entry to the custom output file
                using (FileStream outStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                {
                    entry.Extract(outStream);
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
 * 1. When you need to pull a single configuration file out of a large 7z backup and store it under a specific name for further processing.
 * 2. When an application must retrieve a particular log file from a compressed archive and place it in a designated output directory with a renamed filename.
 * 3. When a deployment script extracts a required resource from a 7z package and saves it with a custom name to avoid naming conflicts.
 * 4. When a data migration tool reads a specific document from a 7z archive and writes it to a target folder using a user‑defined filename.
 * 5. When you want to programmatically extract one entry from a 7z archive in C# and control the exact output path and filename.
 */
