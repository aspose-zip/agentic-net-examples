// HOW-TO: Cancel BZIP2 Extraction After Timeout Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;
using Aspose.Zip.Bzip2;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input BZIP2 archive and output directory paths
            string inputPath = @"C:\Data\sample.bz2";
            string outputDir = @"C:\Data\Extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Set up cancellation after 5 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(5));

            // Load options with cancellation token
            Bzip2LoadOptions loadOptions = new Bzip2LoadOptions()
            {
                CancellationToken = cts.Token
            };

            // Open the BZIP2 archive with the load options
            using (Bzip2Archive archive = new Bzip2Archive(inputPath, loadOptions))
            {
                try
                {
                    // Extract all entries to the output directory
                    archive.Extract(outputDir);
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
 * 1. When processing large BZIP2 log files on a server, you can stop the extraction if it exceeds five seconds to keep the application responsive.
 * 2. When integrating Aspose.Zip into a desktop tool that extracts user‑selected archives, you may need to enforce a timeout to avoid long‑running operations on slow disks.
 * 3. When building an automated ETL pipeline that extracts compressed data, you can cancel the extraction if network latency causes the operation to stall.
 * 4. When providing a web API that unpacks BZIP2 uploads, you can use a cancellation token to terminate extraction after a short period and return an error to the client.
 * 5. When running batch jobs that handle many BZIP2 archives, you can prevent a single corrupt or oversized file from blocking the entire job by timing out the extraction.
 */
