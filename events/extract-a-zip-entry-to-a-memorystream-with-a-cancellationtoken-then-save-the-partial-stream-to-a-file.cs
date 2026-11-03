// HOW-TO: Extract a ZIP Entry to MemoryStream with Cancellation Token in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Threading;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputZipPath = "input.zip";
            string entryName = "sample.txt";
            string outputFilePath = "extracted_partial.bin";

            // Validate input file
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Prepare cancellation token (cancel after 10 seconds)
            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                cts.CancelAfter(10000);
                ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
                {
                    CancellationToken = cts.Token
                };

                // Open the ZIP archive with cancellation support
                using (Archive archive = new Archive(inputZipPath, loadOptions))
                {
                    // Find the requested entry
                    ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase));
                    if (entry == null)
                    {
                        Console.Error.WriteLine($"Entry not found: {entryName}");
                        return;
                    }

                    // Extract entry to a memory stream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.CopyTo(memoryStream);
                        }

                        // Ensure output directory exists
                        string outputDir = Path.GetDirectoryName(outputFilePath);
                        if (!string.IsNullOrEmpty(outputDir))
                        {
                            Directory.CreateDirectory(outputDir);
                        }

                        // Save the partial stream to a file
                        memoryStream.Position = 0;
                        using (FileStream fileStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                        {
                            memoryStream.CopyTo(fileStream);
                        }

                        Console.WriteLine($"Entry '{entryName}' extracted to memory and saved as '{outputFilePath}'.");
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.Error.WriteLine("Operation was canceled.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to read a large file from a ZIP archive into memory while allowing the operation to be cancelled if it takes too long.
 * 2. When you want to extract a specific entry from a ZIP archive and later write only a portion of its data to a separate file.
 * 3. When you are building a responsive UI that must stop a ZIP extraction task after a timeout to avoid freezing the application.
 * 4. When you need to process the contents of a ZIP entry in memory before deciding whether to persist it to disk.
 * 5. When you are implementing server‑side logic that extracts compressed logs from a ZIP archive but must enforce a cancellation policy for long‑running extractions.
 */
