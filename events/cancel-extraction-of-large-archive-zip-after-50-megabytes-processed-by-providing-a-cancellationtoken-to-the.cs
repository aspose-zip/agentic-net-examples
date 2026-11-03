// HOW-TO: Cancel Zip Extraction After Processing Limit Using C# CancellationToken (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "large_archive.zip";
        string outputPath = "output\\extracted";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000); // Cancel after 5 seconds (example)

            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions() { CancellationToken = cts.Token };

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                try
                {
                    archive.ExtractToDirectory(outputPath);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled after processing limit.");
                }
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
 * 1. When extracting a massive zip archive on a server, you can abort the operation after a predefined data size to prevent exhausting disk space.
 * 2. When building a responsive desktop application, you can cancel a long‑running zip extraction after a timeout to keep the UI responsive.
 * 3. When applying security policies that restrict how much data can be extracted from untrusted archives, you can stop the extraction once the processed bytes exceed the allowed limit.
 * 4. When running automated batch jobs that process many zip files, you can use a cancellation token to skip files that take too long, ensuring the overall job completes on schedule.
 * 5. When testing error‑handling logic, you can deliberately cancel zip extraction after a certain amount of data to simulate failure scenarios and verify that your code handles OperationCanceledException correctly.
 */
