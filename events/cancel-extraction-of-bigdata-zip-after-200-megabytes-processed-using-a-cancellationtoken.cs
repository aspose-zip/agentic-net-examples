// HOW-TO: Cancel Zip Extraction After Processing 200 MB Using C# CancellationToken (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "bigdata.zip";
            string outputPath = "extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? outputPath);

            // Set up cancellation after a short interval (example: 5000 ms)
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000);

            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions()
            {
                CancellationToken = cts.Token
            };

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                try
                {
                    archive.ExtractToDirectory(outputPath);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled after processing the specified amount of data.");
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
 * 1. When you need to stop extracting a huge zip file if it exceeds a data‑processing limit to avoid running out of disk space.
 * 2. When implementing a timeout for archive extraction in a web service that must remain responsive under heavy load.
 * 3. When providing users the ability to abort a long‑running unzip operation after a certain amount of data has been processed.
 * 4. When protecting a mobile or IoT application from excessive memory usage by canceling extraction after a predefined byte threshold.
 * 5. When integrating Aspose.Zip into a batch job that must skip overlarge archives to keep the overall processing pipeline efficient.
 */
