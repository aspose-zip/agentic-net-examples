// HOW-TO: Track Zip Entry Compression Progress and Save Percentage to JSON in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFilePath = "input.txt";
            string zipPath = "data.zip";
            string jsonPath = "zip_entry_progress.json";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(zipPath) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(jsonPath) ?? ".");

            using (FileStream source = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(new ArchiveEntrySettings(new PPMdCompressionSettings())))
            {
                ArchiveEntry entry = archive.CreateEntry(Path.GetFileName(inputFilePath), source);
                int percentReady = 0;

                entry.CompressionProgressed += (s, e) =>
                {
                    int percent = (int)((100L * (long)e.ProceededBytes) / source.Length);
                    if (percent > percentReady)
                    {
                        Console.WriteLine($"Compression progress: {percent}%");
                        percentReady = percent;
                    }
                };

                archive.Save(zipPath);

                string jsonContent = $"{{\"compressionPercentage\":{percentReady}}}";
                File.WriteAllText(jsonPath, jsonContent);
                Console.WriteLine("Compression completed.");
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
 * 1. When you need to display real‑time compression status to users while creating a ZIP file in a desktop application.
 * 2. When you want to log the final compression percentage of a file for audit or analytics after archiving it.
 * 3. When a background service must monitor large file compression and write the progress result to a JSON file for later processing.
 * 4. When integrating zip creation into a CI/CD pipeline and you need a machine‑readable summary of compression efficiency.
 * 5. When building a reporting tool that aggregates compression metrics from multiple archives stored as JSON files.
 */
