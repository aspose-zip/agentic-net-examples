// HOW-TO: Extract ZIP Archive with Cancellation Token Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip;
using Aspose.Zip.ArchiveInfo;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Archives\sample.zip";
            string outputDirectory = @"C:\Extracted\ZipArchive";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (CancellationTokenSource cts = new CancellationTokenSource())
            {
                CancellationToken token = cts.Token;

                ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                loadOptions.CancellationToken = token;

                using (Archive archive = new Archive(inputPath, loadOptions))
                {
                    try
                    {
                        archive.ExtractToDirectory(outputDirectory);
                        Console.WriteLine("Extraction completed successfully.");
                    }
                    catch (OperationCanceledException)
                    {
                        Console.WriteLine("Extraction was canceled.");
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
 * 1. When processing a large ZIP file in a desktop application and you need to let the user abort the extraction if it takes too long.
 * 2. When building a server‑side service that extracts uploaded archives and must respect a cancellation request to free resources promptly.
 * 3. When integrating Aspose.Zip into a background worker that extracts files while monitoring a CancellationToken to stop on timeout or user interruption.
 * 4. When automating deployment scripts that unpack ZIP packages and require graceful handling of cancellation to avoid partial installations.
 * 5. When creating a command‑line tool that extracts archives to a specific folder and needs to report whether the operation completed or was cancelled.
 */
