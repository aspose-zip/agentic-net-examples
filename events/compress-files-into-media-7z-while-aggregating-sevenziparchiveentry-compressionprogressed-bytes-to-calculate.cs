// HOW-TO: Compress Multiple Files to 7z Archive With Overall Progress Log in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = "input";
            string outputArchivePath = "output/media.7z";
            string progressLogPath = "output/media7z_overall.txt";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Gather files to compress
            string[] files = Directory.GetFiles(inputDirectory);
            if (files.Length == 0)
            {
                Console.Error.WriteLine("No files found to compress.");
                return;
            }

            // Calculate total size of all files
            ulong totalSize = 0;
            foreach (string filePath in files)
            {
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
                FileInfo info = new FileInfo(filePath);
                totalSize += (ulong)info.Length;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Prepare progress tracking
            ulong totalProgressed = 0;
            int lastPercent = 0;
            object syncLock = new object();
            Dictionary<SevenZipArchiveEntry, ulong> entryProgress = new Dictionary<SevenZipArchiveEntry, ulong>();

            // Open progress log file
            using (StreamWriter progressWriter = new StreamWriter(progressLogPath, false))
            {
                // Create SevenZip archive
                using (SevenZipArchive archive = new SevenZipArchive())
                {
                    foreach (string filePath in files)
                    {
                        // Open source file stream
                        using (FileStream source = File.OpenRead(filePath))
                        {
                            // Create entry in the archive
                            SevenZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(filePath), source);
                            entryProgress[entry] = 0;

                            // Subscribe to compression progress event
                            entry.CompressionProgressed += (sender, e) =>
                            {
                                lock (syncLock)
                                {
                                    ulong previous = entryProgress[entry];
                                    ulong delta = e.ProceededBytes - previous;
                                    totalProgressed += delta;
                                    entryProgress[entry] = e.ProceededBytes;

                                    int percent = (int)(totalProgressed * 100 / totalSize);
                                    if (percent > lastPercent)
                                    {
                                        Console.WriteLine($"Overall compression progress: {percent}%");
                                        progressWriter.WriteLine($"Overall compression progress: {percent}%");
                                        progressWriter.Flush();
                                        lastPercent = percent;
                                    }
                                }
                            };
                        }
                    }

                    // Save the archive
                    archive.Save(outputArchivePath);
                }

                // Write completion message
                Console.WriteLine("Compression completed.");
                progressWriter.WriteLine("Compression completed.");
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
 * 1. When you need to package a batch of media files into a single 7z archive while providing a real‑time overall progress indicator for user feedback.
 * 2. When an application must generate a compressed backup of a folder and record the cumulative bytes processed to a log file for monitoring or auditing.
 * 3. When you want to ensure that the total size of all files is calculated beforehand to display accurate percentage completion during compression.
 * 4. When a service creates a 7z archive in a specific output directory and needs to create the directory automatically if it does not exist.
 * 5. When you have to handle missing files or directories gracefully during batch compression and report errors without crashing the program.
 */
