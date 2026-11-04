// HOW-TO: Extract Multi‑Volume ZIP Archive with Split Segments in C# (Aspose.ZIP for .NET)
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
            // Input directory containing the multi‑volume archive parts
            string inputDirectory = @"C:\Archives";
            // Main archive file (first part)
            string baseArchiveFileName = "myarchive.zip";
            string mainArchivePath = Path.Combine(inputDirectory, baseArchiveFileName);

            // Verify the main archive file exists
            if (!File.Exists(mainArchivePath))
            {
                Console.Error.WriteLine($"File not found: {mainArchivePath}");
                return;
            }

            // Collect split segment files (e.g., myarchive.z01, myarchive.z02, …)
            string[] splitSegmentPaths = Directory.GetFiles(inputDirectory, "myarchive.z*")
                .OrderBy(p => p)
                .ToArray();

            // Output directory for extracted contents
            string outputDirectory = @"C:\Extracted";
            // Ensure the parent directory of the output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Open the multi‑volume archive
            using (Archive archive = new Archive(mainArchivePath, splitSegmentPaths))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputDirectory);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a large backup split into .z01, .z02 files and need to combine and extract it programmatically in a .NET application.
 * 2. When an automated deployment script must verify all parts of a multi‑part archive are present before extracting configuration files.
 * 3. When a file‑transfer service stores archives as segmented ZIP files and your C# service must reassemble and unpack them to a target folder.
 * 4. When you need to extract contents of a split archive while ensuring the output directory exists, handling missing parts gracefully.
 * 5. When building a data‑migration tool that processes multi‑volume ZIP packages and extracts their contents to a specified location on Windows.
 */
