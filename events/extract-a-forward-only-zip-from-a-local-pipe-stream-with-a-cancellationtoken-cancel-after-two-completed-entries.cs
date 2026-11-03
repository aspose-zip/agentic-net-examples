// HOW-TO: Extract Forward-Only ZIP from Stream with Cancellation Token in C# (Aspose.ZIP for .NET)
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
            string inputZipPath = "input.zip";
            string outputDirectory = "output";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(2000); // Cancel after 2 seconds

            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
            {
                CancellationToken = cts.Token
            };

            using (Archive archive = new Archive(inputZipPath, loadOptions))
            {
                try
                {
                    archive.ExtractToDirectory(outputDirectory);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled.");
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
 * 1. When processing a huge ZIP file on a server and you need to abort the extraction after a timeout to free resources.
 * 2. When building a desktop utility that extracts user‑selected archives but must stop if the operation takes too long to keep the UI responsive.
 * 3. When integrating Aspose.Zip into a pipeline that reads ZIP data from a pipe stream and you want to cancel after a few entries to test partial extraction.
 * 4. When deploying a microservice that extracts incoming ZIP payloads but must enforce a maximum processing time for each request.
 * 5. When creating a backup restoration script that extracts files but needs to handle cancellation gracefully to avoid corrupted output.
 */
