// HOW-TO: Extract BZIP2 File With Cancellation Token And Partial Output In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hard‑coded paths for the BZIP2 source and the extracted file
            string inputPath = "data/sample.bz2";
            string outputPath = "output/payload.txt";

            // Verify that the source BZIP2 file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up a cancellation token that will trigger after 5 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000);

            // Load options with the cancellation token
            Aspose.Zip.Bzip2.Bzip2LoadOptions loadOptions = new Aspose.Zip.Bzip2.Bzip2LoadOptions()
            {
                CancellationToken = cts.Token
            };

            // Open the BZIP2 archive with the specified load options
            using (Aspose.Zip.Bzip2.Bzip2Archive archive = new Aspose.Zip.Bzip2.Bzip2Archive(inputPath, loadOptions))
            {
                try
                {
                    // Extract the single entry to the target file
                    archive.Extract(outputPath);
                }
                catch (OperationCanceledException)
                {
                    // Extraction was cancelled; the output file may be only partially written
                    Console.WriteLine("Extraction was canceled. The output file may be incomplete.");
                }
            }
        }
        catch (Exception ex)
        {
            // Report any unexpected errors
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When processing large BZIP2 logs on a server and you need to abort extraction if it takes too long, preserving any data already written.
 * 2. When building a desktop utility that extracts compressed configuration files but must respect user‑initiated cancel actions.
 * 3. When integrating a data pipeline that reads BZIP2 archives and you want to ensure the program can stop gracefully on timeout while still having a partially extracted file for debugging.
 * 4. When deploying an automated backup‑restore script that may be interrupted by system shutdown and you need to know which files were only partially recovered.
 * 5. When creating a cloud function that extracts a single payload from a BZIP2 archive and must handle cancellation tokens to avoid exceeding execution time limits.
 */
