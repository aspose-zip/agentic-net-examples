// HOW-TO: Create Split ZIP of Image Thumbnails with 64KB Segments in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing thumbnail images
            string inputDirectory = @"C:\Images\Thumbnails";
            // Hardcoded output directory where split ZIP segments will be saved
            string outputDirectory = @"C:\Output";

            // Validate input directory
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);
            // Ensure parent directory of output path exists (as per safety rule)
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add each thumbnail file to the archive
                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                // Configure split (multivolume) save options: 64 KiB per segment, base name "thumbs"
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("thumbs", 64 * 1024);

                // Save the archive as split segments in the output directory
                archive.SaveSplit(outputDirectory, saveOptions);
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
 * 1. When you need to package a large collection of thumbnail images into a multi‑volume ZIP so each part stays under a specific size limit for easy upload or transfer.
 * 2. When your application must generate split archives to comply with email attachment size restrictions or legacy storage media constraints.
 * 3. When you want to automatically create a series of small ZIP files that can be downloaded sequentially by users with limited bandwidth.
 * 4. When you need to archive image previews for backup while ensuring each archive segment fits on a 64 KB flash drive partition.
 * 5. When a system requires pre‑splitting a ZIP archive to enable parallel processing or distributed extraction across multiple machines.
 */
