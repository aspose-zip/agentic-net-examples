// HOW-TO: Extract BZIP2 Archive With Timeout Cancellation In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\sample.bz2";
            string outputPath = @"C:\Data\Extracted\sample.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a cancellation token that triggers after 7 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(7));

            // Configure load options with the cancellation token
            Bzip2LoadOptions loadOptions = new Bzip2LoadOptions()
            {
                CancellationToken = cts.Token
            };

            // Open the BZIP2 archive with cancellation support
            using (Bzip2Archive archive = new Bzip2Archive(inputPath, loadOptions))
            {
                try
                {
                    // Extract the decompressed content to the output path
                    archive.Extract(outputPath);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled after the timeout.");
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
 * 1. When processing large BZIP2 log files on a server, you can abort the extraction if it exceeds a predefined time to keep the application responsive.
 * 2. When integrating a file‑upload service that receives compressed BZIP2 payloads, you can limit extraction time to prevent denial‑of‑service attacks.
 * 3. When building a desktop utility that extracts user‑selected BZIP2 archives, you can automatically cancel the operation after a short period if the user aborts or the file is corrupted.
 * 4. When running batch jobs that decompress nightly backups, you can enforce a seven‑second timeout to detect stalled archives and log an error.
 * 5. When developing a cloud function that unpacks BZIP2 data streams, you can use a cancellation token to stop the extraction if the function exceeds its execution quota.
 */
