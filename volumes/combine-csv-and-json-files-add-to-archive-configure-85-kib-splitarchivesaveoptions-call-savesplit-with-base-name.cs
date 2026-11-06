// HOW-TO: Create Split ZIP Archive of CSV and JSON Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define input file paths
            string inputCsvPath = "input.csv";
            string inputJsonPath = "input.json";

            // Define output directory
            string outputDir = "output";

            // Validate input CSV file
            if (!File.Exists(inputCsvPath))
            {
                Console.Error.WriteLine($"File not found: {inputCsvPath}");
                return;
            }

            // Validate input JSON file
            if (!File.Exists(inputJsonPath))
            {
                Console.Error.WriteLine($"File not found: {inputJsonPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Create a new ZIP archive and add files
            using (Archive archive = new Archive())
            {
                // Add CSV file to the archive
                archive.CreateEntry("data.csv", new FileInfo(inputCsvPath));

                // Add JSON file to the archive
                archive.CreateEntry("data.json", new FileInfo(inputJsonPath));

                // Configure split options for 85 KiB volumes with base file name "mixed"
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("mixed", 85 * 1024);

                // Save the archive as split segments in the output directory
                archive.SaveSplit(outputDir, saveOptions);
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
 * 1. When you need to package a CSV report and its related JSON metadata into a single ZIP file that can be transferred over size‑limited channels.
 * 2. When you must split a ZIP archive into small 85 KB volumes to meet email attachment limits or legacy storage constraints.
 * 3. When you want to automate the creation of segmented ZIP files with a consistent base name for batch processing or downstream scripts.
 * 4. When you need to ensure both data and configuration files are archived together while preserving their original filenames for later extraction.
 * 5. When you are building a .NET application that must generate portable, size‑controlled ZIP parts for distribution to users with limited bandwidth.
 */
