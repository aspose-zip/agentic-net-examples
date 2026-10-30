// HOW-TO: Extract Specific File From .tar.xz Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "logs_crc64.tar.xz";
            string outputPath = "logA.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            // Decompress the .xz archive to obtain the inner TAR stream
            using (XzArchive xzArchive = new XzArchive(inputPath))
            using (MemoryStream tarStream = new MemoryStream())
            {
                // Extract the TAR payload into the memory stream
                xzArchive.Extract(tarStream);
                tarStream.Position = 0;

                // Load the TAR archive from the decompressed stream
                using (TarArchive tarArchive = new TarArchive(tarStream))
                {
                    // Locate the entry named logA.txt (case‑insensitive)
                    TarEntry logEntry = tarArchive.Entries
                        .FirstOrDefault(e => string.Equals(e.Name, "logA.txt", StringComparison.OrdinalIgnoreCase));

                    if (logEntry == null)
                    {
                        Console.Error.WriteLine("Entry 'logA.txt' not found in the TAR archive.");
                        return;
                    }

                    // Extract the entry to the specified output file
                    using (FileStream outputFile = File.Create(outputPath))
                    {
                        logEntry.Extract(outputFile);
                    }
                }
            }

            Console.WriteLine($"Extracted 'logA.txt' to '{outputPath}'.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to decompress a .xz‑compressed tar backup and retrieve a single log file for analysis in a C# application.
 * 2. When a monitoring system stores daily logs in a logs_crc64.tar.xz package and you must programmatically extract logA.txt for further processing.
 * 3. When automating deployment scripts that receive tar.xz bundles and you have to pull out a configuration file without extracting the entire archive.
 * 4. When building a forensic tool in .NET that reads compressed tar archives and isolates specific evidence files such as logA.txt.
 * 5. When integrating Aspose.Zip into a C# service to handle mixed compression formats and selectively extract needed entries from large archives.
 */
