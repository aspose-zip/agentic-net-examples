// HOW-TO: Extract CAB Archive in C# and Cancel After Specific File (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = @"C:\Data\archive.cab";
            string outputDirectory = @"C:\Data\Extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Set up cancellation token source
            CancellationTokenSource cts = new CancellationTokenSource();

            // Load CAB archive with cancellation support
            CabLoadOptions loadOptions = new CabLoadOptions();
            loadOptions.CancellationToken = cts.Token;

            using (CabArchive archive = new CabArchive(inputPath, loadOptions))
            {
                try
                {
                    foreach (CabEntry entry in archive.Entries)
                    {
                        // Build full path for the extracted entry
                        string destinationPath = Path.Combine(outputDirectory, entry.Name);

                        // Ensure the directory for the entry exists
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                        // Extract entry to file
                        using (Stream entryStream = entry.Open())
                        using (FileStream fileStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                        {
                            entryStream.CopyTo(fileStream);
                        }

                        // Cancel after processing the specific entry
                        if (string.Equals(entry.Name, "backup.bak", StringComparison.OrdinalIgnoreCase))
                        {
                            cts.Cancel();
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled after processing backup.bak.");
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
 * 1. When you need to extract files from a Windows CAB package in a .NET application but want to stop the process once a particular backup file has been retrieved.
 * 2. When building an automated deployment tool that unpacks CAB resources and must abort further extraction after confirming the presence of a critical configuration file.
 * 3. When processing large CAB archives on a server and you want to conserve resources by cancelling the extraction after a designated log or backup entry is handled.
 * 4. When integrating Aspose.Zip.Cab into a backup restoration workflow that extracts only up to a specific .bak file and then halts to avoid overwriting newer data.
 * 5. When implementing user‑initiated cancellation in a GUI that extracts CAB contents, using a CancellationToken to terminate extraction after the target entry is processed.
 */
