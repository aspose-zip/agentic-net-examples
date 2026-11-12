// HOW-TO: Load BZIP2 File With Cancellation Token And Save Partial Output In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "sample.bz2";
            string outputPath = "sample.partial";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath) ?? ".");

            // Memory stream to hold extracted data (may be partial)
            using (MemoryStream memoryStream = new MemoryStream())
            {
                // Set up cancellation after a short interval
                using (CancellationTokenSource cts = new CancellationTokenSource())
                {
                    cts.CancelAfter(100); // milliseconds

                    Bzip2LoadOptions loadOptions = new Bzip2LoadOptions()
                    {
                        CancellationToken = cts.Token
                    };

                    // Open BZIP2 archive with cancellation support
                    using (Bzip2Archive archive = new Bzip2Archive(inputPath, loadOptions))
                    {
                        try
                        {
                            // Extract payload to memory stream
                            archive.Extract(memoryStream);
                        }
                        catch (OperationCanceledException)
                        {
                            Console.WriteLine("Extraction canceled.");
                        }
                    }
                }

                // Save whatever data was extracted to a .partial file
                memoryStream.Position = 0;
                using (FileStream fileStream = File.Create(outputPath))
                {
                    memoryStream.CopyTo(fileStream);
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
 * 1. When processing large BZIP2 logs on a server and you need to abort extraction if it exceeds a time limit, saving whatever data was retrieved so far.
 * 2. When implementing a responsive UI that allows users to cancel a BZIP2 decompression operation and still keep the partially extracted content for later analysis.
 * 3. When building a backup verification tool that extracts compressed files but must stop on errors or timeouts, preserving the incomplete payload for debugging.
 * 4. When streaming BZIP2 data in a microservice and you want to enforce a cancellation policy to prevent resource hogging while retaining any extracted bytes.
 * 5. When performing automated batch extraction of BZIP2 archives in a CI pipeline and you need to handle unexpected cancellations by writing the partial result to a .partial file.
 */
