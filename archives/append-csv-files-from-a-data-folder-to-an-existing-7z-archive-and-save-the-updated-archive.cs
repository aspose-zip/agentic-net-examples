// HOW-TO: Append CSV Files to Existing 7z Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputArchivePath = "C:\\Archives\\existing.7z";
            string dataFolderPath = "C:\\Data\\CsvFiles";
            string outputArchivePath = "C:\\Archives\\updated.7z";

            // Validate input archive
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Validate data folder
            if (!Directory.Exists(dataFolderPath))
            {
                Console.Error.WriteLine($"Directory not found: {dataFolderPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputArchivePath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open existing 7z archive, add CSV files, and save updated archive
            using (SevenZipArchive archive = new SevenZipArchive(inputArchivePath))
            {
                archive.CreateEntries(dataFolderPath);
                archive.Save(outputArchivePath);
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
 * 1. When you need to regularly add daily generated CSV reports to a master 7z backup without recreating the archive.
 * 2. When a data‑pipeline must compress new CSV export files into an existing 7z package for efficient storage and transfer.
 * 3. When an application must update a distributed archive with additional CSV logs while preserving previously archived content.
 * 4. When you want to automate the inclusion of CSV configuration files into a pre‑existing 7z archive as part of a deployment script.
 * 5. When a scheduled job has to merge CSV data files from a folder into an existing 7z archive to keep a consolidated, compressed dataset.
 */
