// HOW-TO: Extract Specific CAB Entry to MemoryStream and Save Partial Data in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Cab;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths and entry name
            string inputPath = @"C:\Data\sample.cab";
            string outputPath = @"C:\Data\partial.bin";
            string entryName = "file.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Prepare cancellation token (not cancelled in this example)
            CancellationTokenSource cts = new CancellationTokenSource();
            CabLoadOptions loadOptions = new CabLoadOptions() { CancellationToken = cts.Token };

            // Open the CAB archive with load options
            using (FileStream fileStream = File.OpenRead(inputPath))
            {
                using (CabArchive archive = new CabArchive(fileStream, loadOptions))
                {
                    // Locate the specific entry
                    CabEntry targetEntry = archive.Entries.FirstOrDefault(e => e.Name == entryName);
                    if (targetEntry == null)
                    {
                        Console.Error.WriteLine($"Entry not found: {entryName}");
                        return;
                    }

                    // Extract entry to a memory stream
                    using (MemoryStream memoryStream = new MemoryStream())
                    {
                        targetEntry.Extract(memoryStream);
                        memoryStream.Position = 0;

                        // Determine how many bytes to write (e.g., first 1024 bytes or less)
                        int bytesToWrite = (int)Math.Min(1024, memoryStream.Length);
                        byte[] buffer = new byte[bytesToWrite];
                        memoryStream.Read(buffer, 0, bytesToWrite);

                        // Ensure output directory exists
                        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

                        // Write the partial data to disk
                        File.WriteAllBytes(outputPath, buffer);
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
 * 1. When you need to read only the first part of a large file inside a CAB archive without extracting the whole archive to disk.
 * 2. When you want to process a specific file from a CAB package in memory for validation or preview before full extraction.
 * 3. When you must support cancellation of archive loading while extracting a particular entry in a responsive UI application.
 * 4. When you need to extract a file from a CAB archive and write only a limited number of bytes to a temporary file for checksum calculation.
 * 5. When you are building a tool that extracts configuration files from CAB installers and stores a snippet for logging or analysis.
 */
