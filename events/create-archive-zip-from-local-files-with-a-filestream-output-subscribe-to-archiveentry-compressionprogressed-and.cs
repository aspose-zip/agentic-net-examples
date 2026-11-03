// HOW-TO: Create ZIP Archive with Progress Reporting to Text File in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string inputPath1 = Path.Combine(dataDir, "file1.txt");
            string inputPath2 = Path.Combine(dataDir, "file2.txt");
            string outputArchivePath = Path.Combine(dataDir, "archive.zip");
            string reportPath = Path.Combine(dataDir, "zip_detail_report.txt");

            // Validate input files
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            // Prepare streams and archive
            using (FileStream zipStream = File.Open(outputArchivePath, FileMode.Create))
            using (StreamWriter reportWriter = new StreamWriter(reportPath, false))
            using (Archive archive = new Archive())
            {
                List<FileStream> sourceStreams = new List<FileStream>();

                // First file entry
                FileStream source1 = File.Open(inputPath1, FileMode.Open, FileAccess.Read);
                sourceStreams.Add(source1);
                ArchiveEntry entry1 = archive.CreateEntry(Path.GetFileName(inputPath1), source1);
                entry1.CompressionProgressed += (s, e) =>
                {
                    long total = source1.Length;
                    long progressed = (long)e.ProceededBytes;
                    double percent = (double)progressed / total * 100;
                    string line = $"Entry {entry1.Name}: {percent:F2}% ({progressed}/{total} bytes)";
                    reportWriter.WriteLine(line);
                    Console.WriteLine(line);
                };

                // Second file entry
                FileStream source2 = File.Open(inputPath2, FileMode.Open, FileAccess.Read);
                sourceStreams.Add(source2);
                ArchiveEntry entry2 = archive.CreateEntry(Path.GetFileName(inputPath2), source2);
                entry2.CompressionProgressed += (s, e) =>
                {
                    long total = source2.Length;
                    long progressed = (long)e.ProceededBytes;
                    double percent = (double)progressed / total * 100;
                    string line = $"Entry {entry2.Name}: {percent:F2}% ({progressed}/{total} bytes)";
                    reportWriter.WriteLine(line);
                    Console.WriteLine(line);
                };

                // Save the archive
                archive.Save(zipStream);

                // Dispose source streams after saving
                foreach (FileStream src in sourceStreams)
                {
                    src.Dispose();
                }
            }

            Console.WriteLine("Archive created and progress report saved.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple local files into a ZIP while tracking each file’s compression percentage and logging it for audit purposes.
 * 2. When an application must generate a compressed archive on the fly and provide a detailed progress report to a text file for monitoring long‑running uploads.
 * 3. When you want to create a ZIP archive using FileStream output to control the destination path and ensure the process can be inspected later.
 * 4. When a background service compresses user‑submitted documents and records per‑entry compression stats for troubleshooting performance issues.
 * 5. When a desktop utility needs to archive selected files and produce a human‑readable report of compression details for compliance documentation.
 */
