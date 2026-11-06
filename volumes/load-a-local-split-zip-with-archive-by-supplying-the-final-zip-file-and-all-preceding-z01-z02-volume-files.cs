// HOW-TO: Extract Multi-Volume Split ZIP Archive in C# With Aspose (Aspose.ZIP for .NET)
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
            string dataDir = @"C:\Data";
            string outputDir = @"C:\last_volume_output";

            // Main .zip segment (final part)
            string mainSegment = Path.Combine(dataDir, "archive.zip");

            // Verify main segment exists
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"File not found: {mainSegment}");
                return;
            }

            // Collect preceding volume files (e.g., .z01, .z02, ...)
            string[] precedingSegments = Directory.GetFiles(dataDir, "archive.z*")
                .OrderBy(f => f)
                .ToArray();

            // Verify each preceding segment exists
            foreach (string seg in precedingSegments)
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
            using (Archive archive = new Archive(mainSegment, precedingSegments))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string outPath = Path.Combine(outputDir, entry.Name);
                    // Ensure directory for the entry exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));

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
 * 1. When you receive a large backup divided into .z01, .z02, and .zip files and need to programmatically combine and extract them in a .NET application.
 * 2. When an automated deployment pipeline must unpack a multi-part ZIP delivered via FTP or email before installing software components.
 * 3. When a file‑sharing service provides a split archive and your C# utility has to reconstruct and extract its contents without manual concatenation.
 * 4. When you need to programmatically extract logs stored in a split ZIP created by a legacy system for analysis in a C# analytics tool.
 * 5. When a desktop application must read and extract a large compressed dataset that was divided into multiple volumes to bypass file‑size limits.
 */
