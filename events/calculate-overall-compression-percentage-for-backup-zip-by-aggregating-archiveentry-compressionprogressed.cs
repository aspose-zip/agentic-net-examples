// HOW-TO: How to Track Compression Progress and Save Zip File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string sourceFileName = "sample.txt";
            string zipFileName = "sample.zip";

            string sourcePath = Path.Combine(dataDir, sourceFileName);
            string zipPath = Path.Combine(dataDir, zipFileName);

            // Validate input file
            if (!File.Exists(sourcePath))
            {
                Console.Error.WriteLine($"File not found: {sourcePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            using (FileStream source = File.Open(sourcePath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(new ArchiveEntrySettings(new PPMdCompressionSettings())))
            {
                ArchiveEntry entry = archive.CreateEntry(sourceFileName, source);

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
            }

            Console.WriteLine("Compression completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to monitor real‑time compression percentage while creating a ZIP archive in a C# application.
 * 2. When you want to ensure a large file is successfully added to a ZIP archive and get console feedback on progress.
 * 3. When you must create a ZIP archive using PPMd compression and need to validate that the source file exists before compressing.
 * 4. When you are building an automated backup routine that writes compressed files to a specific directory and logs completion status.
 * 5. When you need to handle errors gracefully during archive creation and provide clear messages to the user.
 */
