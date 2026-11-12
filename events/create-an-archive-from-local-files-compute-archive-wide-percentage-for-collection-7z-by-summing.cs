// HOW-TO: Create 7z Archive with Aspose.Zip and Record Compression Progress in C# (Aspose.ZIP for .NET)
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
            string inputDir = @"C:\Data\Input";
            string outputDir = @"C:\Data\Output";

            string[] inputFiles = new string[]
            {
                Path.Combine(inputDir, "file1.txt"),
                Path.Combine(inputDir, "file2.txt")
            };

            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            Directory.CreateDirectory(outputDir);

            string archivePath = Path.Combine(outputDir, "collection.7z");
            string percentFilePath = Path.Combine(outputDir, "7z_percent.txt");

            long totalSize = 0;
            foreach (string inputPath in inputFiles)
            {
                FileInfo info = new FileInfo(inputPath);
                totalSize += info.Length;
            }

            ulong totalProcessed = 0;
            int lastPercent = 0;
            ulong totalSizeU = (ulong)totalSize;

            List<FileStream> openStreams = new List<FileStream>();

            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            using (SevenZipArchive archive = new SevenZipArchive())
            {
                foreach (string inputPath in inputFiles)
                {
                    FileStream source = new FileStream(inputPath, FileMode.Open, FileAccess.Read);
                    openStreams.Add(source);

                    SevenZipArchiveEntry entry = archive.CreateEntry(Path.GetFileName(inputPath), source);

                    entry.CompressionProgressed += (sender, e) =>
                    {
                        totalProcessed += e.ProceededBytes;
                        int percent = (int)((totalProcessed * 100UL) / totalSizeU);
                        if (percent > lastPercent)
                        {
                            Console.WriteLine($"Compression progress: {percent}%");
                            lastPercent = percent;
                        }
                    };
                }

                archive.Save(archivePath);
            }

            foreach (FileStream stream in openStreams)
            {
                stream.Dispose();
            }

            File.WriteAllText(percentFilePath, $"{lastPercent}%");

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
 * 1. When you need to bundle multiple log files into a single 7z archive and store the overall compression percentage for reporting purposes.
 * 2. When an automated backup script must create a compressed archive using Aspose.Zip for .NET and log the compression progress to a text file.
 * 3. When a desktop application compresses user‑selected documents into a 7z file and displays the final compression ratio after the operation completes.
 * 4. When a server‑side process generates a 7z package of generated reports and writes the compression efficiency to a monitoring file for analytics.
 * 5. When a CI/CD pipeline archives build artifacts with 7z compression and records the compression percentage to verify size reduction thresholds.
 */
