// HOW-TO: Extract RAR Archive With Timeout Cancellation In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths for the RAR archive and extraction directory
            string inputPath = "C:\\Data\\sample.rar";
            string outputPath = "C:\\Data\\Extracted";

            // Verify that the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Set up a cancellation token that triggers after 4 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(4000); // 4000 milliseconds = 4 seconds

            // Configure load options with the cancellation token
            RarArchiveLoadOptions loadOptions = new RarArchiveLoadOptions();
            loadOptions.CancellationToken = cts.Token;

            // Open the archive and attempt extraction
            using (FileStream fs = File.OpenRead(inputPath))
            using (RarArchive archive = new RarArchive(fs, loadOptions))
            {
                try
                {
                    archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to unzip a large RAR file but must abort the operation if it takes longer than a few seconds to keep the UI responsive.
 * 2. When processing user‑uploaded RAR archives on a server and you want to enforce a maximum extraction time to prevent resource exhaustion.
 * 3. When integrating Aspose.Zip into a batch job that extracts archives but must stop after a timeout to avoid hanging on corrupted files.
 * 4. When building a desktop tool that extracts RAR files while allowing the user to set a time limit for the extraction process.
 * 5. When implementing automated tests that verify your extraction code correctly respects a CancellationToken after a specified interval.
 */
