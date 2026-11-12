// HOW-TO: Extract All Files From ARJ Archive With Cancellation Token In C# (Aspose.ZIP for .NET)
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
            string inputPath = "sample.arj";

            // Hardcoded output directory for extraction
            string outputDir = "Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Create a cancellation token source that cancels after 5 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000);

            // Configure load options with the cancellation token
            ArjLoadOptions loadOptions = new ArjLoadOptions();
            loadOptions.CancellationToken = cts.Token;

            // Open the ARJ archive with the specified load options
            using (ArjArchive archive = new ArjArchive(inputPath, loadOptions))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputDir);
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Extraction was canceled.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically unpack a legacy ARJ backup while ensuring the operation stops if it takes longer than a set time.
 * 2. When processing user‑uploaded ARJ files on a server and you want to prevent long‑running extractions from consuming resources.
 * 3. When integrating ARJ extraction into a desktop utility that must remain responsive by cancelling the task after a timeout.
 * 4. When automating migration of archived data and you require graceful handling of cancellations to avoid partial extractions.
 * 5. When building a batch script that extracts multiple ARJ archives and you need to enforce a maximum extraction duration for each file.
 */
