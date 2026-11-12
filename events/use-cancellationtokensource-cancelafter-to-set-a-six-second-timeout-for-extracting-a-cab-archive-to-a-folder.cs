// HOW-TO: Extract CAB Archive with 6 Second Timeout Using CancellationToken in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CAB file and output directory
            string inputPath = @"C:\Data\sample.cab";
            string outputPath = @"C:\Data\Extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set a cancellation timeout of six seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(6000);

            // Configure load options with the cancellation token
            CabLoadOptions loadOptions = new CabLoadOptions()
            {
                CancellationToken = cts.Token
            };

            // Open the CAB archive with the specified load options
            using (CabArchive archive = new CabArchive(inputPath, loadOptions))
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
 * 1. When a deployment script must unpack a CAB file but abort if extraction takes longer than a few seconds to avoid hanging the installer.
 * 2. When processing large batches of CAB archives on a server and you need to enforce a per‑file timeout to keep resource usage predictable.
 * 3. When integrating third‑party CAB packages into a Windows application and you want to cancel extraction if the user cancels the operation or the operation exceeds a set time.
 * 4. When running automated tests that extract CAB files and you need to ensure the test fails quickly if extraction stalls.
 * 5. When building a background service that extracts CAB updates and you must prevent long‑running extractions from blocking other tasks.
 */
