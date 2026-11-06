// HOW-TO: Extract Multi-Volume ZIP Archive with Segment Validation in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string dataDir = @"C:\Data\MultivolumeZip";
            string outputDir = Path.Combine(dataDir, "Extracted");
            string mainSegment = Path.Combine(dataDir, "archive.zip");

            // Collect split segment files (e.g., .z01, .z02, ...)
            string[] segmentFiles = Directory.GetFiles(dataDir, "archive.z*")
                .OrderBy(f => f)
                .Where(f => !f.EndsWith(".zip"))
                .ToArray();

            // Validate main segment existence
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"File not found: {mainSegment}");
                return;
            }

            // Validate each split segment existence
            foreach (string seg in segmentFiles)
            {
                if (!File.Exists(seg))
                {
                    Console.Error.WriteLine($"File not found: {seg}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Open multivolume archive
            using (Archive archive = new Archive(mainSegment, segmentFiles))
            {
                // Iterate through entries and extract
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string outPath = Path.Combine(outputDir, entry.Name);
                    string outDir = Path.GetDirectoryName(outPath);
                    if (!string.IsNullOrEmpty(outDir))
                    {
                        Directory.CreateDirectory(outDir);
                    }

                    using (FileStream output = new FileStream(outPath, FileMode.Create))
                    {
                        entry.Extract(output);
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
 * 1. When you receive a large split ZIP file (e.g., .z01, .z02, .zip) from a partner and need to verify each segment before extracting its contents in a C# application.
 * 2. When an automated backup system creates multi‑volume archives and you must programmatically ensure all parts are present and then unpack them to a target folder using Aspose.Zip for .NET.
 * 3. When a deployment pipeline distributes a compressed package across several files and you need to combine and extract them safely on a Windows server with C#.
 * 4. When a user downloads a segmented archive from a web portal and your desktop utility must check the integrity of each segment before extracting the full file set.
 * 5. When you are building a file‑migration tool that processes large archives split into .zxx parts and requires validation and extraction to a specific directory in a .NET environment.
 */
