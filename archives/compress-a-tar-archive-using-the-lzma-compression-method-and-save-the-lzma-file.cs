// HOW-TO: Compress a TAR Archive to LZMA File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = "Data";
            string inputFileName = "sample.txt";
            string inputFilePath = Path.Combine(dataDir, inputFileName);
            string outputDir = "Output";
            string outputFilePath = Path.Combine(outputDir, "archive.lzma");

            // Validate input file
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Create TAR archive and compress with LZMA
            using (TarArchive archive = new TarArchive())
            {
                // Add the file to the archive
                archive.CreateEntry(inputFileName, inputFilePath);

                // Save the archive with LZMA compression
                archive.SaveLZMACompressed(outputFilePath);
            }

            Console.WriteLine($"TAR archive compressed with LZMA saved to: {outputFilePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple log files into a single TAR and shrink them with high‑ratio LZMA compression for efficient storage or transfer.
 * 2. When a backup routine must create .lzma archives from configuration files to meet strict size‑limit requirements.
 * 3. When distributing software resources that must be delivered as a compressed TAR/LZMA package for cross‑platform extraction.
 * 4. When integrating with legacy systems that only accept LZMA‑compressed TAR archives for data ingestion.
 * 5. When building a .NET service that archives user‑generated documents and stores them in a compact LZMA format to save disk space.
 */
