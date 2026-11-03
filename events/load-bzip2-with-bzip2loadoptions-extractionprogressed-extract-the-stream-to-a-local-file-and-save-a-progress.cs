// HOW-TO: Extract BZIP2 Archive with Progress Reporting to File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Bzip2;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "C:\\Data\\sample.bz2";
            string outputPath = "C:\\Data\\extracted.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set up load options with extraction progress handler
            Bzip2LoadOptions loadOptions = new Bzip2LoadOptions();
            loadOptions.ExtractionProgressed += (sender, e) =>
            {
                // Calculate progress percentage
                int percent = (int)((100L * e.ProceededBytes) / ((ArchiveEntry)sender).UncompressedSize);
                Console.WriteLine($"Extraction progress: {percent}%");
            };

            // Open the BZIP2 archive with the specified options
            using (Bzip2Archive archive = new Bzip2Archive(inputPath, loadOptions))
            {
                // Extract the archive content to a file stream
                using (FileStream outputStream = File.Create(outputPath))
                {
                    archive.Extract(outputStream);
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
 * 1. When you need to decompress a .bz2 log file on a server while showing real‑time extraction progress to the console.
 * 2. When a desktop application must unpack a compressed data bundle and write the contents to a specific folder, tracking how much has been extracted.
 * 3. When an automated ETL pipeline processes large BZIP2 datasets and you want to log percentage completion for monitoring and alerts.
 * 4. When a backup restore utility extracts compressed configuration files and needs to display extraction status to users for better UX.
 * 5. When a file‑transfer service receives a BZIP2 payload and must extract it to a temporary file while reporting progress for debugging or audit purposes.
 */
