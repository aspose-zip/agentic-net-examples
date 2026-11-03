// HOW-TO: Extract BZIP2 Archive to File with Cancellation Token in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input BZIP2 archive and output file paths
            string inputPath = "input.bz2";
            string outputPath = "output.txt";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Create a cancellation token that triggers after 5 seconds
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000); // milliseconds

            // Load options with the cancellation token
            Bzip2LoadOptions loadOptions = new Bzip2LoadOptions()
            {
                CancellationToken = cts.Token
            };

            // Open the BZIP2 archive with the specified load options
            using (Bzip2Archive archive = new Bzip2Archive(inputPath, loadOptions))
            {
                // Extract the archive content to the specified output file
                archive.Extract(outputPath);
            }
        }
        catch (OperationCanceledException)
        {
            Console.WriteLine("Extraction was canceled.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to decompress a large .bz2 log file on a server but want to abort the operation if it takes too long.
 * 2. When a desktop application must extract a single text file from a BZIP2 backup and ensure the output directory exists before writing.
 * 3. When an automated data pipeline processes compressed sensor data and requires a cancellation token to stop extraction during a timeout.
 * 4. When integrating Aspose.Zip into a C# service that validates the presence of the source .bz2 file and extracts it safely to a configurable path.
 * 5. When building a command‑line tool that extracts BZIP2 archives while handling user‑initiated cancellations and reporting errors gracefully.
 */
