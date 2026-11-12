// HOW-TO: Create ZIP archive with real-time compression progress log in C# (Aspose.ZIP for .NET)
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
            string inputDir = @"C:\Data";
            string outputDir = @"C:\Output";
            string archivePath = Path.Combine(outputDir, "sample.zip");
            string progressPath = Path.Combine(outputDir, "zip_progress.txt");

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Files to add to the archive
            string[] files = new string[]
            {
                Path.Combine(inputDir, "file1.txt"),
                Path.Combine(inputDir, "file2.txt")
            };

            // Prepare progress writer
            using (StreamWriter progressWriter = new StreamWriter(progressPath, false))
            {
                // List to keep source streams open until archive is saved
                List<FileStream> sourceStreams = new List<FileStream>();

                // Create the ZIP archive
                using (Archive archive = new Archive())
                {
                    foreach (string filePath in files)
                    {
                        if (!File.Exists(filePath))
                        {
                            Console.Error.WriteLine($"File not found: {filePath}");
                            return;
                        }

                        // Open source file stream
                        FileStream source = File.Open(filePath, FileMode.Open, FileAccess.Read);
                        sourceStreams.Add(source);

                        // Create entry in the archive
                        ArchiveEntry entry = archive.CreateEntry(Path.GetFileName(filePath), source);

                        // Track compression progress
                        int lastPercent = 0;
                        entry.CompressionProgressed += (s, e) =>
                        {
                            int percent = (int)(((long)e.ProceededBytes * 100L) / source.Length);
                            if (percent > lastPercent)
                            {
                                progressWriter.WriteLine($"{Path.GetFileName(filePath)}: {percent}%");
                                progressWriter.Flush();
                                lastPercent = percent;
                            }
                        };
                    }

                    // Save the archive to disk
                    archive.Save(archivePath);
                }

                // Dispose source streams after saving
                foreach (FileStream stream in sourceStreams)
                {
                    stream.Dispose();
                }
            }

            Console.WriteLine("Archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When an application needs to compress multiple local files into a ZIP while writing the current compression percentage to a log file for user feedback.
 * 2. When a background service creates backup archives and must record compression progress for monitoring or troubleshooting purposes.
 * 3. When a desktop utility packages documents for upload and wants to provide a real‑time progress indicator without using a graphical UI.
 * 4. When a server‑side process generates downloadable ZIP bundles and needs to write progress updates to a file for downstream automation.
 * 5. When developers must keep source file streams open until the archive is saved and capture compression events for custom reporting.
 */
