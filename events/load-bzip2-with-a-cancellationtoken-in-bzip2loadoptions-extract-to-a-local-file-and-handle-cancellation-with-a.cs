// HOW-TO: Extract BZIP2 Archive With Cancellation Token In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input BZIP2 file path
            string inputPath = @"C:\Data\sample.bz2";

            // Hardcoded output directory for extraction
            string outputDir = @"C:\Data\Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Set up a cancellation token that triggers after 5 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000); // milliseconds

            // Configure load options with the cancellation token
            Bzip2LoadOptions loadOptions = new Bzip2LoadOptions()
            {
                CancellationToken = cts.Token
            };

            // Open the BZIP2 archive with the specified load options
            using (Bzip2Archive archive = new Bzip2Archive(inputPath, loadOptions))
            {
                try
                {
                    // Extract all entries to the output directory
                    archive.Extract(outputDir);
                }
                catch (OperationCanceledException)
                {
                    // Handle cancellation gracefully
                    Console.WriteLine("Extraction was canceled.");
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When processing large BZIP2 logs on a server, you can extract them to a folder while allowing the operation to be cancelled if it exceeds a time limit.
 * 2. When building a desktop utility that unpacks user‑uploaded BZIP2 files, you can use a CancellationToken to stop extraction if the user aborts the task.
 * 3. When integrating BZIP2 extraction into a background service, the code lets you monitor and gracefully handle time‑outs without leaving partial files.
 * 4. When automating data pipelines that decompress BZIP2 archives, you can enforce a maximum extraction duration to keep downstream processes responsive.
 * 5. When creating a test harness that validates BZIP2 extraction, the cancellation handling provides a clear status message for interrupted runs.
 */
