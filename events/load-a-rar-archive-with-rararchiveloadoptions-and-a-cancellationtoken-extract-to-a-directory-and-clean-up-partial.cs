// HOW-TO: Extract RAR Archive with Cancellation Token and Cleanup in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "data/sample.rar";
        string outputDir = "output/extracted";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000); // Cancel after 5 seconds

            RarArchiveLoadOptions loadOptions = new RarArchiveLoadOptions();
            loadOptions.CancellationToken = cts.Token;

            using (FileStream fs = File.OpenRead(inputPath))
            {
                using (RarArchive archive = new RarArchive(fs, loadOptions))
                {
                    try
                    {
                        archive.ExtractToDirectory(outputDir);
                        Console.WriteLine("Extraction completed.");
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("Extraction was canceled.");
                        if (Directory.Exists(outputDir))
                        {
                            Directory.Delete(outputDir, true);
                        }
                    }
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
 * 1. When you need to extract large RAR files in a C# application but want to abort the operation if it takes too long, preventing the app from hanging.
 * 2. When you want to ensure that partially extracted data is removed automatically if the extraction is canceled or fails, keeping the output folder clean.
 * 3. When you are processing user‑uploaded RAR archives on a server and must enforce a time limit to protect resources.
 * 4. When you integrate RAR extraction into a background service and need to pass a CancellationToken to support graceful shutdown.
 * 5. When you need to verify the existence of the RAR file, create the destination directory, and handle extraction errors in a robust try‑catch structure.
 */
