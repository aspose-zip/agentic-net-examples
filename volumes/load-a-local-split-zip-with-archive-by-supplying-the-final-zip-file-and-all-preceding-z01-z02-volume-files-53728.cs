// HOW-TO: Extract Multi-Volume Split ZIP by Supplying Final and Prior Segments in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string dataDir = "data";
            string outputDir = "ordered_zip_output";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Path to the final .zip segment
            string mainSegment = Path.Combine(dataDir, "archive.zip");
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"File not found: {mainSegment}");
                return;
            }

            // Collect preceding volume files (e.g., .z01, .z02) and order them
            string[] segmentFiles = Directory.GetFiles(dataDir, "archive.z*")
                                             .OrderBy(f => f)
                                             .ToArray();

            // Open the multivolume archive
            using (Archive archive = new Archive(mainSegment, segmentFiles))
            {
                // Extract each entry to the output directory
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
 * 1. When you receive a large archive that was divided into .z01, .z02, and a final .zip file and need to combine and extract its contents in a C# application.
 * 2. When an automated backup system stores data in split ZIP volumes and your C# program must reconstruct the archive with Aspose.Zip to restore the files.
 * 3. When distributing software installers as multi‑part ZIP files and you want to programmatically unpack them without manual reassembly using .NET.
 * 4. When processing email attachments that arrive as segmented ZIP archives and you need to extract the full set of documents in order with C#.
 * 5. When migrating legacy split archives to a new storage location and you require a reliable way to read the final segment together with preceding parts using Aspose.Zip for .NET.
 */
