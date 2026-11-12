// HOW-TO: Generate a Text Report of ZIP Entry Names in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
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
            string outputPath = @"C:\Data\ZipEntriesReport.txt";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                // Create a writer for the report file
                using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
                {
                    // Enumerate entries and write their full names
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        writer.WriteLine(entry.Name);
                    }
                }
            }

            Console.WriteLine("Report generated successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit the contents of a ZIP file without extracting it, you can generate a plain‑text list of all entry names.
 * 2. When building a deployment script that logs which files are packaged in an archive for compliance reporting.
 * 3. When creating an inventory of resources bundled in a ZIP to compare against a master list or version control.
 * 4. When troubleshooting missing or duplicate files in a compressed package by reviewing a generated entry list.
 * 5. When providing end‑users a readable summary of archive contents before they decide to download or extract it.
 */
