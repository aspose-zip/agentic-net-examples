// HOW-TO: Generate Text Report of Image Files Inside a ZIP Using C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP path
            string inputPath = @"C:\Data\sample.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output report path
            string outputPath = @"C:\Data\ImageEntriesReport.txt";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // List to hold image entry names
            List<string> imageEntryNames = new List<string>();

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                // Iterate through entries and select image files
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string entryName = entry.Name;
                    if (entryName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".gif", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".tiff", StringComparison.OrdinalIgnoreCase) ||
                        entryName.EndsWith(".webp", StringComparison.OrdinalIgnoreCase))
                    {
                        imageEntryNames.Add(entryName);
                    }
                }
            }

            // Write the collected names to the report file
            File.WriteAllLines(outputPath, imageEntryNames);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit which image files are stored in a ZIP archive without extracting them.
 * 2. When you want to create an inventory list of photos in a compressed package for documentation purposes.
 * 3. When a build pipeline must verify that required image assets are present in a distribution ZIP before release.
 * 4. When a desktop application needs to display a summary of image resources inside a ZIP before allowing users to download them.
 * 5. When a server script must log the names of image entries in a ZIP for compliance or licensing checks.
 */
