// HOW-TO: Create Split ZIP Archive of PNG Files with 64KB Segments in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing PNG files
            string inputDirectory = @"C:\Images\PNGs";
            // Hardcoded output directory for split archive segments
            string outputDirectory = @"C:\Output";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Base name for split archive (segments will be pngset.zip, pngset.z01, etc.)
            string baseOutputPath = Path.Combine(outputDirectory, "pngset");

            // Ensure the directory for the base output path exists
            Directory.CreateDirectory(Path.GetDirectoryName(baseOutputPath));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Get all PNG files in the input directory (non-recursive)
                string[] pngFiles = Directory.GetFiles(inputDirectory, "*.png");

                foreach (string filePath in pngFiles)
                {
                    // Verify each file exists before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Use the file name as the entry name inside the archive
                    string entryName = Path.GetFileName(filePath);

                    // Add the file to the archive
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                // Configure split options: 64 KiB per segment
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(65536);

                // Save the archive as split segments
                archive.SaveSplit(baseOutputPath, saveOptions);
            }

            Console.WriteLine("Split archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a large collection of PNG images for distribution but must keep each ZIP part under 64 KB to meet email attachment limits.
 * 2. When an application must generate split ZIP files for legacy systems that only support small archive segments during automated backups.
 * 3. When you want to create a multi‑part archive of screenshots to upload to a cloud service that imposes a maximum file size per request.
 * 4. When a deployment script requires a split ZIP of UI assets so that each segment can be transferred over a low‑bandwidth network without exceeding size constraints.
 * 5. When you need to archive PNG resources for a game mod and ensure the archive can be extracted by tools that expect standard ZIP split naming conventions.
 */
