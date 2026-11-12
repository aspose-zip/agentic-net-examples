// HOW-TO: Extract Specific ZIP Entry Directly To File Stream In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string zipPath = "input.zip";

            // Hardcoded name of the entry to extract
            string entryName = "sample.txt";

            // Hardcoded output file path for the extracted content
            string outputFilePath = "extracted_sample.txt";

            // Validate input ZIP file existence
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Open the ZIP archive for reading
            using (FileStream zipStream = File.OpenRead(zipPath))
            using (Archive archive = new Archive(zipStream))
            {
                // Locate the specific entry by name
                ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name == entryName);
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Extract the entry directly into a writable file stream
                using (FileStream outputStream = new FileStream(outputFilePath, FileMode.Create, FileAccess.Write))
                {
                    entry.Extract(outputStream);
                }
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to pull a single configuration file out of a large ZIP archive without extracting the whole archive.
 * 2. When processing a downloaded ZIP package and you want to stream a specific document directly to disk to reduce memory usage.
 * 3. When building a server‑side service that extracts a particular log file from a user‑uploaded ZIP and saves it for further analysis.
 * 4. When creating a backup restore tool that restores only selected files from a compressed archive to a target folder.
 * 5. When integrating with a third‑party API that provides ZIP bundles and you must extract a required asset on the fly into a writable stream.
 */
