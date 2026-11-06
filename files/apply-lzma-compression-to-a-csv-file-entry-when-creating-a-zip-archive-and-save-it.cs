// HOW-TO: Create ZIP Archive with LZMA Compression for CSV in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string inputCsvPath = dataDir + "sample.csv";
            string outputZipPath = dataDir + "output.zip";

            // Verify input file exists
            if (!File.Exists(inputCsvPath))
            {
                Console.Error.WriteLine($"File not found: {inputCsvPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Create ZIP archive with LZMA compression for entries
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                using (Archive archive = new Archive(new ArchiveEntrySettings(new LzmaCompressionSettings())))
                {
                    // Open source CSV file
                    using (FileStream sourceStream = File.Open(inputCsvPath, FileMode.Open, FileAccess.Read))
                    {
                        // Add CSV entry to the archive
                        archive.CreateEntry("sample.csv", sourceStream);
                    }

                    // Save the archive to the output file
                    archive.Save(zipStream);
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
 * 1. When you need to reduce the size of large CSV logs before transferring them over a network, you can compress them with LZMA in a ZIP file using C#.
 * 2. When you want to store CSV data in an archive that supports high compression while preserving the original file name, this code creates a LZMA‑compressed ZIP entry.
 * 3. When automating backup scripts that must package daily CSV reports into a compact archive for long‑term storage, the example shows how to generate the ZIP programmatically.
 * 4. When integrating with systems that only accept ZIP files but you require maximum compression for CSV payloads, you can use Aspose.Zip to apply LZMA compression in .NET.
 * 5. When building a data‑export feature that writes CSV files directly into a compressed archive without creating intermediate files, this approach streams the CSV into a LZMA‑compressed ZIP entry.
 */
