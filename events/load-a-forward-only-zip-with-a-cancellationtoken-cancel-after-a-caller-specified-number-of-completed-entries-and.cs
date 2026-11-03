// HOW-TO: Extract First N Entries from ZIP with Cancellation Token in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file and output directory
            string inputPath = "sample.zip";
            string outputDir = "ExtractedFiles";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Caller‑specified limit of entries to extract before cancellation
            int maxCompletedEntries = 3;

            // Set up cancellation token source
            CancellationTokenSource cts = new CancellationTokenSource();

            // Load options with cancellation token (forward‑only mode if supported)
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.CancellationToken = cts.Token;
            // If the API provides a forward‑only mode, it could be set here, e.g.:
            // loadOptions.LoadMode = LoadMode.ForwardOnly;

            // Open the archive with the load options
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                int processedEntries = 0;

                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Stop processing if cancellation was requested
                    if (cts.Token.IsCancellationRequested)
                    {
                        break;
                    }

                    // Extract the entry to the output directory
                    string destinationPath = Path.Combine(outputDir, entry.Name);
                    entry.Extract(destinationPath);

                    processedEntries++;

                    // Cancel after the specified number of completed entries
                    if (processedEntries >= maxCompletedEntries)
                    {
                        cts.Cancel();
                    }
                }

                // Report status
                if (cts.Token.IsCancellationRequested)
                {
                    Console.WriteLine($"Extraction cancelled after {processedEntries} entries.");
                }
                else
                {
                    Console.WriteLine("Extraction completed successfully.");
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
 * 1. When you need to extract only a limited number of files from a large ZIP and stop the operation if a user aborts, preserving the files already extracted.
 * 2. When processing a massive archive in a low‑memory environment, using forward‑only loading and a cancellation token prevents loading the entire archive into memory.
 * 3. When integrating ZIP extraction into a UI that allows users to cancel after a certain number of files have been processed, ensuring the UI remains responsive.
 * 4. When building a batch job that extracts a predefined count of entries from each archive and logs which files were successfully extracted before cancellation.
 * 5. When you want to safely abort extraction after extracting critical files while keeping those files on disk for later analysis or recovery.
 */
