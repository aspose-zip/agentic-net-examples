// HOW-TO: Cancel ZIP Extraction After Timeout and Log Extracted Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Threading;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.zip";
            string outputDir = @"C:\Data\Extracted";
            string reportPath = Path.Combine(outputDir, "ExtractionReport.txt");

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            List<string> extractedFiles = new List<string>();

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000);

            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.CancellationToken = cts.Token;
            loadOptions.EntryExtractionProgressed = (sender, e) =>
            {
                ArchiveEntry entry = (ArchiveEntry)sender;
                extractedFiles.Add(entry.Name);
            };

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                try
                {
                    archive.ExtractToDirectory(outputDir);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled.");
                }
            }

            File.WriteAllLines(reportPath, extractedFiles);
            Console.WriteLine($"Extraction report written to {reportPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When processing large zip archives on a server, you can abort extraction after a set time to prevent resource exhaustion while still recording which files were successfully extracted.
 * 2. When building a desktop utility that extracts user‑selected zip files, you may want to stop the operation if it takes too long and provide a summary of the files already extracted.
 * 3. When integrating zip extraction into a CI pipeline, you can enforce a timeout to avoid hanging builds and generate a log of extracted entries for debugging.
 * 4. When creating a mobile app that unpacks compressed content, using a cancellation token ensures the extraction stops on slow devices and produces a report for the user.
 * 5. When developing a background service that periodically extracts archives, you can limit execution time with CancelAfter and keep a text report of partial extraction for audit purposes.
 */
