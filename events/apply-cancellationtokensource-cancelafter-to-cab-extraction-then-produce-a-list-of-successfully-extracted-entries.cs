// HOW-TO: Cancel CAB Extraction After Timeout and List Extracted Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input CAB file and output directory
            string inputCabPath = @"C:\Data\sample.cab";
            string outputDirectory = @"C:\Data\Extracted";

            // Verify input file exists
            if (!File.Exists(inputCabPath))
            {
                Console.Error.WriteLine($"File not found: {inputCabPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));
            Directory.CreateDirectory(outputDirectory);

            // Set up cancellation after 2 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(2000); // milliseconds

            CabLoadOptions loadOptions = new CabLoadOptions()
            {
                CancellationToken = cts.Token
            };

            using (CabArchive archive = new CabArchive(inputCabPath, loadOptions))
            {
                try
                {
                    // Extract all entries to the output directory
                    archive.ExtractToDirectory(outputDirectory);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled.");
                    return;
                }

                // List successfully extracted entries
                foreach (CabEntry entry in archive.Entries)
                {
                    string extractedPath = Path.Combine(outputDirectory, entry.Name);
                    if (File.Exists(extractedPath) || Directory.Exists(extractedPath))
                    {
                        Console.WriteLine($"Extracted: {entry.Name}");
                    }
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
 * 1. When you need to extract a large .cab archive but must stop the operation if it takes longer than a few seconds to keep the application responsive.
 * 2. When you want to identify which files were successfully written after a cancellation so you can resume or clean up the extraction.
 * 3. When building an installer that extracts resources from a CAB file and must enforce a time limit to avoid hanging the setup process.
 * 4. When programmatically extracting files from a CAB archive in a .NET service while respecting cancellation tokens for graceful shutdown.
 * 5. When you need to log or display only the entries that were successfully extracted to disk after a timed extraction attempt.
 */
