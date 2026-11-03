// HOW-TO: Extract GZIP Archive To Temporary Folder With 5‑Second Cancellation In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input GZIP file and output directory
            string inputPath = "C:\\Temp\\sample.gz";
            string outputDir = "C:\\Temp\\Extracted";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Set up cancellation after 5 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(5));
            GzipLoadOptions loadOptions = new GzipLoadOptions
            {
                CancellationToken = cts.Token
            };

            // Path for the extracted file
            string outputPath = Path.Combine(outputDir, "extracted.dat");

            using (GzipArchive archive = new GzipArchive(inputPath, loadOptions))
            using (FileStream extracted = File.Create(outputPath))
            {
                try
                {
                    // Extract the GZIP content to the output file
                    archive.Extract(extracted);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled after timeout.");
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
 * 1. When you need to decompress a .gz file into a safe location while ensuring the operation doesn’t hang longer than a few seconds.
 * 2. When processing large log files received as GZIP streams and you want to abort extraction if it exceeds a timeout to keep the application responsive.
 * 3. When building a background service that extracts temporary data files and must respect cancellation requests from a user or system watchdog.
 * 4. When integrating Aspose.Zip into an automated pipeline that extracts compressed payloads but must fail fast if the archive is corrupted or slow to read.
 * 5. When deploying a desktop tool that unpacks configuration bundles and you want to limit extraction time to avoid blocking the UI thread.
 */
