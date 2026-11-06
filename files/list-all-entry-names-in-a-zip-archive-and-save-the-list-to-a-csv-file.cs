// HOW-TO: List ZIP Archive Entries and Export to CSV in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.zip";
        string outputCsvPath = "output\\entries.csv";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputCsvPath));

            using (Archive archive = new Archive(inputPath))
            {
                using (StreamWriter writer = new StreamWriter(outputCsvPath, false, Encoding.UTF8))
                {
                    writer.WriteLine("EntryName");
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        writer.WriteLine(entry.Name);
                    }
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
 * 1. When you need to generate an inventory of all files inside a ZIP for reporting or auditing purposes.
 * 2. When a build pipeline must verify the contents of a packaged artifact without extracting it.
 * 3. When you want to create a CSV manifest to feed into a data‑processing tool that tracks archived resources.
 * 4. When a migration script has to compare the list of entries in multiple ZIP archives to detect missing or duplicate files.
 * 5. When a user interface displays a searchable list of archive members and requires the list to be stored as a CSV for later import.
 */
