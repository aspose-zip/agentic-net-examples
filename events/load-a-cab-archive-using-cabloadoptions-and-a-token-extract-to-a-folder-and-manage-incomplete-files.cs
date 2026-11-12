// HOW-TO: Load CAB Archive With Cancellation Token And Clean Up Incomplete Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths for the CAB file and extraction folder
            string inputCabPath = @"C:\Data\sample.cab";
            string outputDirectory = @"C:\Data\Extracted";

            // Verify that the input CAB file exists
            if (!File.Exists(inputCabPath))
            {
                Console.Error.WriteLine($"File not found: {inputCabPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Set up cancellation after a timeout (e.g., 5 seconds)
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(5000);

            // Load options with the cancellation token
            CabLoadOptions loadOptions = new CabLoadOptions()
            {
                CancellationToken = cts.Token
            };

            // Open the CAB archive with the specified load options
            using (CabArchive archive = new CabArchive(inputCabPath, loadOptions))
            {
                try
                {
                    // Extract all entries to the output directory
                    archive.ExtractToDirectory(outputDirectory);
                }
                catch (OperationCanceledException)
                {
                    Console.WriteLine("Extraction was canceled.");

                    // Clean up any partially extracted files
                    if (Directory.Exists(outputDirectory))
                    {
                        foreach (string filePath in Directory.GetFiles(outputDirectory, "*", SearchOption.AllDirectories))
                        {
                            try
                            {
                                File.Delete(filePath);
                            }
                            catch
                            {
                                // Ignore any errors during cleanup
                            }
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
 * 1. When you need to extract a .cab installation package in a .NET application while allowing the operation to be cancelled if it takes too long.
 * 2. When you want to verify that a CAB file exists before extraction to prevent runtime errors.
 * 3. When you must automatically create the destination folder and ensure it exists prior to extracting files from a CAB archive.
 * 4. When you need to stop a long‑running extraction after a timeout and handle the cancellation exception gracefully.
 * 5. When you want to delete any partially extracted files after a cancelled extraction to keep the output directory clean.
 */
