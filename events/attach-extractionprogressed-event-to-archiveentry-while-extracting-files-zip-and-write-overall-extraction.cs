// HOW-TO: Track Zip Extraction Progress and Log to CSV with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "files.zip";
            string extractDir = "ExtractedFiles";
            string csvPath = "zip_extract_progress.csv";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(extractDir);
            Directory.CreateDirectory(Path.GetDirectoryName(csvPath) ?? ".");

            using (StreamWriter csvWriter = new StreamWriter(csvPath, false))
            {
                csvWriter.WriteLine("EntryName,Percent");

                using (Archive archive = new Archive(inputPath, new ArchiveLoadOptions()
                {
                    EntryExtractionProgressed = (s, e) =>
                    {
                        ArchiveEntry entry = (ArchiveEntry)s;
                        int percent = 0;
                        if (entry.UncompressedSize > 0)
                        {
                            percent = (int)((e.ProceededBytes * 100) / entry.UncompressedSize);
                        }
                        csvWriter.WriteLine($"{entry.Name},{percent}");
                    }
                }))
                {
                    archive.ExtractToDirectory(extractDir);
                }
            }

            Console.WriteLine("Extraction completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to monitor the extraction percentage of each file in a large ZIP archive and record it for reporting or debugging.
 * 2. When you want to extract all files from a ZIP archive to a specific folder while automatically creating the output directory if it doesn't exist.
 * 3. When you need to generate a CSV file that lists each entry name and its extraction progress for integration with analytics or monitoring tools.
 * 4. When you must handle missing ZIP files gracefully by checking existence before starting the extraction process.
 * 5. When you require a simple C# solution that uses Aspose.Zip to extract archives and capture real‑time progress without writing custom event handling code.
 */
