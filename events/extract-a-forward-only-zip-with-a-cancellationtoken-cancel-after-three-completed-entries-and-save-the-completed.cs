// HOW-TO: Extract First Three Files from ZIP with Cancellation Token in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.zip";
            string outputDir = "output";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            CancellationTokenSource cts = new CancellationTokenSource();

            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
            {
                CancellationToken = cts.Token
            };

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                int extractedCount = 0;

                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    string destinationPath = Path.Combine(outputDir, entry.Name);
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                    using (Stream entryStream = entry.Open())
                    using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                    {
                        entryStream.CopyTo(fileStream);
                    }

                    extractedCount++;
                    Console.WriteLine($"Extracted: {entry.Name}");

                    if (extractedCount >= 3)
                    {
                        cts.Cancel();
                    }
                }
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Extraction canceled after processing three entries.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When processing a large ZIP archive on a server, you can extract only the first few entries and abort the rest to conserve memory and CPU.
 * 2. When implementing a user‑initiated “preview” of archive contents, you may extract up to three files and stop if the user cancels the operation.
 * 3. When building a batch job that extracts a limited number of files per run to avoid time‑outs, the CancellationToken lets you halt after three successful extractions.
 * 4. When creating a diagnostic tool that logs each extracted file and stops after a set count, this code provides a simple extraction‑status report.
 * 5. When integrating Aspose.Zip into a .NET application that must respect cancellation requests during forward‑only extraction, the pattern ensures graceful termination after a predefined number of entries.
 */
