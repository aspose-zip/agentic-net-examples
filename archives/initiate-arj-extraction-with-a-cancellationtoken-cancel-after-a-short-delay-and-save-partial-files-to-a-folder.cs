// HOW-TO: Cancel ARJ Extraction After Delay and Save Partial Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ARJ archive path
            string inputPath = "C:\\Data\\sample.arj";

            // Hardcoded output directory for extracted files
            string outputDir = "C:\\Data\\Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Set up a cancellation token that triggers after 2 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(2000); // milliseconds

            // Configure load options with the cancellation token
            ArjLoadOptions loadOptions = new ArjLoadOptions();
            loadOptions.CancellationToken = cts.Token;

            // Open the ARJ archive with the specified load options
            using (ArjArchive archive = new ArjArchive(inputPath, loadOptions))
            {
                try
                {
                    // Extract entries to the output directory; may be canceled
                    archive.ExtractToDirectory(outputDir);
                    Console.WriteLine("Extraction completed.");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled.");
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
 * 1. When processing large ARJ archives on a server, you can abort extraction after a timeout to avoid resource exhaustion while still keeping any files extracted before cancellation.
 * 2. When building a responsive desktop application, you can let users stop a long‑running ARJ extraction operation and retain the files that were already written to the output folder.
 * 3. When integrating with a batch job scheduler, you can enforce a maximum extraction time for each ARJ file, automatically canceling the job if it exceeds the limit.
 * 4. When implementing a safety net for corrupted or malicious ARJ archives, you can cancel extraction after a short delay and examine the partially extracted files for analysis.
 * 5. When creating a progress‑aware utility that extracts ARJ archives, you can use a CancellationToken to allow users to interrupt the process and still have the extracted files saved up to the point of cancellation.
 */
