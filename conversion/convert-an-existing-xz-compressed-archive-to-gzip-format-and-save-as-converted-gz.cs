// HOW-TO: Convert XZ Archive to GZIP File in C# with Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Xz;
using Aspose.Zip.Gzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = @"C:\Data\archive.xz";
            string extractedPath = @"C:\Data\extracted.tmp";
            string outputPath = @"C:\Data\converted.gz";

            // Validate input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure directories for extracted file and output exist
            Directory.CreateDirectory(Path.GetDirectoryName(extractedPath));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Decompress XZ archive to a temporary file
            using (XzArchive xzArchive = new XzArchive(inputPath))
            {
                using (FileStream extractedStream = File.Create(extractedPath))
                {
                    xzArchive.Extract(extractedStream);
                }
            }

            // Compress the extracted file into GZIP format
            using (GzipArchive gzipArchive = new GzipArchive())
            {
                gzipArchive.SetSource(extractedPath);
                gzipArchive.Save(outputPath);
            }

            // Optionally delete the temporary extracted file
            if (File.Exists(extractedPath))
            {
                File.Delete(extractedPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate legacy XZ‑compressed log files to GZIP so they can be processed by tools that only support GZIP archives.
 * 2. When a deployment pipeline requires converting XZ packages into GZIP to meet the compression format expected by a Linux container registry.
 * 3. When you must extract data from an XZ archive and immediately re‑compress it as GZIP to reduce storage size while preserving compatibility with .NET applications.
 * 4. When integrating with third‑party APIs that accept only GZIP streams, you can convert incoming XZ payloads to GZIP before sending them.
 * 5. When automating data archival, you may convert XZ backups to GZIP to standardize compression across multiple backup locations.
 */
