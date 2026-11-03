// HOW-TO: Load GZIP with CancellationToken and Save Partial Data on Cancel in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Threading;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.gz";
            string outputPath = "output\\recovered.dat";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare cancellation after a short interval (e.g., 2000 ms)
            CancellationTokenSource cts = new CancellationTokenSource();
            cts.CancelAfter(2000);
            GzipLoadOptions loadOptions = new GzipLoadOptions() { CancellationToken = cts.Token };

            // Memory stream to hold extracted data
            using (MemoryStream memoryStream = new MemoryStream())
            {
                try
                {
                    // Open GZIP archive with cancellation support
                    using (GzipArchive archive = new GzipArchive(inputPath, loadOptions))
                    {
                        // Copy the decompressed payload to memory
                        using (Stream entryStream = archive.Open())
                        {
                            entryStream.CopyTo(memoryStream);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    // Save partially extracted bytes with .partial suffix
                    string partialPath = outputPath + ".partial";
                    Directory.CreateDirectory(Path.GetDirectoryName(partialPath));
                    File.WriteAllBytes(partialPath, memoryStream.ToArray());
                    Console.WriteLine("Extraction canceled. Partial data saved.");
                    return;
                }

                // Extraction completed successfully; save full data
                Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
                File.WriteAllBytes(outputPath, memoryStream.ToArray());
                Console.WriteLine("Extraction completed successfully.");
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
 * 1. When processing large GZIP logs that might need to be aborted, you can load the archive with a CancellationToken and keep any data extracted before the cancel.
 * 2. When integrating a timeout‑based extraction routine into a web service, this code lets you stop the decompression after a set time and store the partially retrieved bytes for later analysis.
 * 3. When building a desktop utility that lets users interrupt a long‑running GZIP extraction, the approach saves the already‑decompressed portion with a .partial extension so the user can resume later.
 * 4. When running batch jobs that decompress GZIP files on limited resources, you can use a CancellationToken to prevent the job from hanging and still retain whatever data was already extracted.
 * 5. When implementing a data‑recovery scenario where a corrupted GZIP file may cause extraction to stall, the code captures the bytes read up to the point of cancellation for forensic examination.
 */
