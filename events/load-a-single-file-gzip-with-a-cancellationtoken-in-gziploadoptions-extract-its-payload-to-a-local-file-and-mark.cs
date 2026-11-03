// HOW-TO: Extract GZIP File with Cancellation Token and Partial Output in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.gz";
            string outputPath = "extracted.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Set up cancellation to trigger after 5 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000); // milliseconds

            // Load GZIP archive with cancellation token
            GzipLoadOptions loadOptions = new GzipLoadOptions()
            {
                CancellationToken = cts.Token
            };

            using (GzipArchive archive = new GzipArchive(inputPath, loadOptions))
            {
                try
                {
                    // Extract payload to output file
                    using (FileStream outStream = File.Create(outputPath))
                    {
                        archive.Extract(outStream);
                    }
                }
                catch (OperationCanceledException)
                {
                    // Mark incomplete output as partial
                    string partialPath = outputPath + ".partial";
                    if (File.Exists(outputPath))
                    {
                        File.Move(outputPath, partialPath);
                    }
                    Console.WriteLine("Extraction was canceled. Output marked as partial.");
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
 * 1. When you need to decompress a large .gz log file but want to abort if it takes too long, using a CancellationToken.
 * 2. When processing user‑uploaded GZIP archives on a server and you must ensure the operation can be cancelled to free resources.
 * 3. When extracting data from a compressed backup and you want any incomplete file to be clearly marked as a partial result.
 * 4. When integrating Aspose.Zip into a Windows service that monitors a folder and must stop extraction after a timeout.
 * 5. When building a command‑line tool that extracts a single‑file GZIP and needs graceful handling of interruptions for reliable downstream processing.
 */
