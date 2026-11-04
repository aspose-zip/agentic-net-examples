// HOW-TO: Extract Split Multi-Volume ZIP Archive in C# With Aspose.Zip (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Define the directory containing the split ZIP parts
            string dataDir = "C:\\Data";

            // Path to the final .zip segment
            string mainSegment = Path.Combine(dataDir, "archive.zip");

            // Paths to the preceding split segments
            string[] precedingSegments = new string[]
            {
                Path.Combine(dataDir, "archive.z01"),
                Path.Combine(dataDir, "archive.z02")
            };

            // Verify that the main segment exists
            if (!File.Exists(mainSegment))
            {
                Console.Error.WriteLine($"File not found: {mainSegment}");
                return;
            }

            // Verify that each preceding segment exists
            foreach (string segment in precedingSegments)
            {
                if (!File.Exists(segment))
                {
                    Console.Error.WriteLine($"File not found: {segment}");
                    return;
                }
            }

            // Output directory for extracted files
            string outputDir = "C:\\split_zip_output";
            Directory.CreateDirectory(outputDir);

            // Open the multivolume ZIP archive
            using (Archive archive = new Archive(mainSegment, precedingSegments))
            {
                // Iterate through each entry in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Determine the full output path for the entry
                    string outPath = Path.Combine(outputDir, entry.Name);

                    // Ensure the directory for the entry exists
                    string outDirectory = Path.GetDirectoryName(outPath);
                    if (!string.IsNullOrEmpty(outDirectory))
                    {
                        Directory.CreateDirectory(outDirectory);
                    }

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
 * 1. When you receive a large ZIP that was divided into .z01, .z02, and a final .zip part and need to combine and extract it programmatically in a .NET application.
 * 2. When an automated deployment script must unpack a multi-volume archive stored on a server without manually merging the parts first.
 * 3. When a backup solution creates split ZIP files to fit storage limits and you need to restore the original files using C# code.
 * 4. When a file-transfer process splits a ZIP into smaller segments for email or FTP and the receiving application must reassemble and extract the contents.
 * 5. When a data-processing pipeline processes archives that are split across several files and you need to read each entry directly from the combined archive in memory.
 */
