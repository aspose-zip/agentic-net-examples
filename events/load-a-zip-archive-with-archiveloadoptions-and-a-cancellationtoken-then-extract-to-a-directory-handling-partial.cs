// HOW-TO: Extract ZIP With Cancellation Token And Preserve Partial Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Temp\\sample.zip";
            string outputPath = "C:\\Temp\\Extracted";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000); // Cancel after 5 seconds (example)

            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions()
            {
                CancellationToken = cts.Token
            };

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                try
                {
                    archive.ExtractToDirectory(outputPath);
                    Console.WriteLine("Extraction completed successfully.");
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled. Partial files may exist in the output directory.");
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
 * 1. When you need to unzip a large archive in a .NET application but want to abort the operation after a timeout while keeping any files already extracted.
 * 2. When processing user‑uploaded ZIP files on a server and you must stop extraction if it exceeds a time limit, ensuring already extracted data remains available.
 * 3. When implementing a responsive desktop tool that extracts archives and should cancel the operation if the user presses a cancel button, leaving partially extracted content intact.
 * 4. When running batch extraction jobs in a background service and you need to handle unexpected cancellations without losing the files that were successfully written.
 * 5. When integrating Aspose.Zip into a CI pipeline that extracts build artifacts, and you want the pipeline to continue with whatever files were extracted before a cancellation occurs.
 */
