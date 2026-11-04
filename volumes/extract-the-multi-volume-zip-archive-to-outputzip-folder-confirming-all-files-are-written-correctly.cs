// HOW-TO: Extract Multi-Volume ZIP Archive to Folder with Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Input directory containing the multi‑volume ZIP parts
            string dataDir = "Data";
            // Output directory where files will be extracted
            string outputDir = "OutputZip";

            // Main segment of the multi‑volume archive
            string mainSegment = Path.Combine(dataDir, "archive.zip");

            // Verify the main segment exists
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"File not found: {mainSegment}");
                return;
            }

            // Collect additional volume files (e.g., .z01, .z02, …) and order them
            string[] segmentFiles = Directory.GetFiles(dataDir, "archive.*")
                .Where(f => !f.EndsWith(".zip", StringComparison.OrdinalIgnoreCase))
                .OrderBy(f => f)
                .ToArray();

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the multi‑volume archive
            using (Archive archive = new Archive(mainSegment, segmentFiles))
            {
                // Iterate through each entry and extract it
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string outPath = Path.Combine(outputDir, entry.Name);
                    // Create subdirectories for entries that reside in folders
                    string outDir = Path.GetDirectoryName(outPath);
                    if (!string.IsNullOrEmpty(outDir))
                    {
                        Directory.CreateDirectory(outDir);
                    }

                    using (FileStream output = new FileStream(outPath, FileMode.Create))
                    {
                        entry.Extract(output);
                    }

                    Console.WriteLine($"Extracted: {entry.Name}");
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
 * 1. When you receive a large compressed backup split into .zip, .z01, .z02 files and need to combine and extract them programmatically in a .NET application.
 * 2. When an automated deployment script must unpack a multi‑part software package onto a server using C#.
 * 3. When a data‑migration tool has to read archived logs stored as segmented ZIP files and write them to a target directory.
 * 4. When a desktop utility needs to verify that all parts of a split archive are present and extract their contents while preserving folder hierarchy.
 * 5. When a cloud service processes user‑uploaded multi‑volume ZIP uploads and extracts the files to a temporary workspace for further processing.
 */
