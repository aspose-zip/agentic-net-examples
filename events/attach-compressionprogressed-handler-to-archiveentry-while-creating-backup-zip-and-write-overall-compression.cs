// HOW-TO: Track ZIP Compression Progress and Save Percentage to File in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string inputPath = @"C:\Data\input.txt";
            string zipPath = @"C:\Output\backup.zip";
            string progressPath = @"C:\Output\zip_creation_progress.txt";

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));
            Directory.CreateDirectory(Path.GetDirectoryName(progressPath));

            // Create ZIP archive with compression progress reporting
            using (FileStream source = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive())
                {
                    ArchiveEntry entry = archive.CreateEntry("input.txt", source);
                    int lastPercent = 0;

                    entry.CompressionProgressed += (s, e) =>
                    {
                        long length = source.Length;
                        int percent = (int)((e.ProceededBytes * 100UL) / (ulong)length);
                        if (percent > lastPercent)
                        {
                            File.WriteAllText(progressPath, percent.ToString());
                            lastPercent = percent;
                        }
                    };

                    archive.Save(zipPath);
                }
            }

            Console.WriteLine("ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to monitor how much of a large file has been compressed into a ZIP archive and log the progress for user feedback.
 * 2. When building a backup utility that creates ZIP files and wants to write the current compression percentage to a status file for external monitoring tools.
 * 3. When integrating Aspose.Zip into an automated deployment pipeline and you must record compression milestones to a log for audit purposes.
 * 4. When developing a desktop application that shows real‑time compression stats by reading a progress file updated during ZIP creation.
 * 5. When creating a scheduled task that compresses files and needs a simple text file indicating completion percentage for downstream scripts.
 */
