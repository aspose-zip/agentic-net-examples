// HOW-TO: List ARJ Archive Entries and Export Names to CSV in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "input.arj";
        string outputPath = "output/entries.csv";

        try
        {
            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the ARJ archive and enumerate entries
            using (ArjArchive archive = new ArjArchive(inputPath))
            using (StreamWriter writer = new StreamWriter(outputPath, false, Encoding.UTF8))
            {
                // Write each entry name to the CSV file
                foreach (var entry in archive.Entries)
                {
                    writer.WriteLine(entry.Name);
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
 * 1. When you need to create an inventory of all files inside an ARJ archive for reporting or auditing purposes.
 * 2. When a migration script must read ARJ archive contents and store the file list in a CSV to feed downstream processing tools.
 * 3. When a backup validation tool has to verify which files were packaged in an ARJ archive by comparing the CSV list with expected entries.
 * 4. When generating documentation that lists the structure of legacy ARJ archives, exporting the entry names to CSV simplifies copy‑paste into spreadsheets.
 * 5. When integrating ARJ archive handling into a C# application that logs extracted file names for compliance or troubleshooting.
 */
