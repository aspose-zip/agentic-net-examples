// HOW-TO: Extract ZIP Archive With 3 Second Timeout Using CancellationToken In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = "input.zip";

            // Hardcoded output directory path (the directory where files will be extracted)
            string outputPath = "extracted\\output";

            // Verify that the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory's parent exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up a cancellation token that triggers after 3 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(3000); // 3000 milliseconds = 3 seconds

            // Configure load options with the cancellation token
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions()
            {
                CancellationToken = cts.Token
            };

            // Open the archive with the specified load options
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                try
                {
                    // Extract all entries to the output directory
                    archive.ExtractToDirectory(outputPath);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled due to timeout.");
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
 * 1. When you need to abort a large ZIP extraction if it takes longer than a few seconds to keep a UI responsive.
 * 2. When processing user‑uploaded ZIP files on a server and you want to enforce a maximum extraction time to prevent resource exhaustion.
 * 3. When integrating Aspose.Zip into a batch job that must complete within a strict time window, such as a scheduled task.
 * 4. When extracting archives in a mobile or IoT application where limited CPU time requires a timeout to avoid hangs.
 * 5. When you want to gracefully handle slow network‑mounted ZIP files by canceling extraction after a predefined period.
 */
