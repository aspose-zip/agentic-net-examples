// HOW-TO: Extract First RAR Entry to MemoryStream With Cancellation Token In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "data/sample.rar";
            string outputPath = "output/incomplete.bin";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up cancellation to trigger after a short delay
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(100); // milliseconds

            // Load RAR archive with cancellation support
            RarArchiveLoadOptions loadOptions = new RarArchiveLoadOptions();
            loadOptions.CancellationToken = cts.Token;

            using (FileStream fs = File.OpenRead(inputPath))
            using (RarArchive archive = new RarArchive(fs, loadOptions))
            {
                // Ensure there is at least one entry
                if (archive.Entries.Count > 0)
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        try
                        {
                            // Attempt to extract the first entry to memory
                            archive.Entries[0].Extract(ms);
                        }
                        catch (OperationCanceledException)
                        {
                            Console.WriteLine("Extraction was canceled.");
                        }

                        // Write whatever data was extracted (may be incomplete) to output file
                        File.WriteAllBytes(outputPath, ms.ToArray());
                    }
                }
                else
                {
                    Console.WriteLine("No entries found in the archive.");
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
 * 1. When you need to preview part of a large RAR file without fully extracting it, using a cancellation token to stop if it takes too long.
 * 2. When building a UI that lets users abort archive extraction and you want to store whatever data was retrieved before cancellation.
 * 3. When processing RAR archives on a server and must limit extraction time to avoid blocking resources.
 * 4. When you want to extract a single file from a RAR archive directly into memory for further in‑memory processing while handling possible cancellation.
 * 5. When you need to log or analyze partially extracted data from a corrupted or incomplete RAR entry without crashing the application.
 */
