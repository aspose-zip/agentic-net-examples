// HOW-TO: Track SevenZip Compression Progress and Log to CSV in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFile = @"C:\Data\sample.txt";
            string outputArchive = @"C:\Output\project.7z";
            string reportFile = @"C:\Output\project7z_report.csv";

            if (!File.Exists(inputFile))
            {
                Console.Error.WriteLine($"File not found: {inputFile}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchive));
            Directory.CreateDirectory(Path.GetDirectoryName(reportFile));

            int lastPercent = 0;

            using (FileStream source = new FileStream(inputFile, FileMode.Open, FileAccess.Read))
            using (StreamWriter csv = new StreamWriter(reportFile, false))
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                SevenZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(inputFile), source);

                entry.CompressionProgressed += (s, e) =>
                {
                    int percent = (int)(((long)e.ProceededBytes * 100L) / source.Length);
                    if (percent > lastPercent)
                    {
                        csv.WriteLine($"{DateTime.Now},{percent}");
                        csv.Flush();
                        Console.WriteLine($"Compression progress: {percent}%");
                        lastPercent = percent;
                    }
                };

                archive.Save(outputArchive);
                Console.WriteLine("Archive created successfully.");
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
 * 1. When you need to display real-time compression percentages in a UI while creating a 7z archive of large files using Aspose.Zip for .NET.
 * 2. When you must generate a timestamped CSV log of compression progress for audit or performance analysis of a SevenZipArchive operation.
 * 3. When you want to monitor and verify that a background compression task using SevenZipArchiveEntry is advancing correctly without blocking the main thread.
 * 4. When you need to record compression milestones to a CSV file for later import into reporting tools or spreadsheets after compressing data with Aspose.Zip.
 * 5. When you are building an automated backup script that tracks and records the progress of each file added to a 7z archive for monitoring and troubleshooting.
 */
