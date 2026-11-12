// HOW-TO: Extract Multi-Volume Split ZIP Files in C# Using Aspose.Zip (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing the split ZIP parts
            string dataDir = @"C:\Data\SplitZip";
            // Hardcoded output directory for extracted files
            string outputDir = @"C:\Data\split_zip_output";

            // Path to the final .zip segment (main segment)
            string mainSegment = Path.Combine(dataDir, "archive.zip");
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"File not found: {mainSegment}");
                return;
            }

            // Collect preceding split parts (e.g., archive.z01, archive.z02, archive.z03)
            string[] segmentFiles = Directory.GetFiles(dataDir, "archive.z*")
                .OrderBy(f => f)
                .ToArray();

            // Verify each split part exists
            foreach (string segment in segmentFiles)
            {
                if (!File.Exists(segment))
                {
                    Console.Error.WriteLine($"File not found: {segment}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the multivolume archive
            using (Archive archive = new Archive(mainSegment, segmentFiles))
            {
                // Iterate through all entries in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Determine full output path for the entry
                    string outPath = Path.Combine(outputDir, entry.Name);
                    // Ensure the directory for the entry exists
                    Directory.CreateDirectory(Path.GetDirectoryName(outPath));

                    // Extract the entry to the output file
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
 * 1. When a developer receives a large archive that was divided into .z01, .z02, .z03 and a final .zip file and needs to programmatically combine and extract its contents in a .NET application.
 * 2. When an automated build or deployment pipeline must unpack split ZIP packages delivered over limited‑size media or network transfers before installing the files.
 * 3. When a backup solution stores data in multi‑volume ZIP archives and the restoration script must locate the main segment and preceding parts to restore the original files.
 * 4. When a file‑sharing service provides split ZIP downloads and a C# client application needs to reassemble and extract the files without manual user intervention.
 * 5. When a data migration tool processes large compressed datasets that were split into several segments to bypass file‑size limits and must extract them to a target directory using Aspose.Zip.
 */
