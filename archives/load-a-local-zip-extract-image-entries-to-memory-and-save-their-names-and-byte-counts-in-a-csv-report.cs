// HOW-TO: Extract Images From ZIP and Generate CSV Report in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = @"C:\Data\sample.zip";
            // Hardcoded output CSV report path
            string outputCsvPath = @"C:\Data\Report\image_report.csv";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCsvPath));

            // List to hold image entry information
            List<ImageInfo> imageInfos = new List<ImageInfo>();

            // Open the ZIP archive
            using (Archive archive = new Archive(File.OpenRead(inputPath)))
            {
                // Iterate through entries
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Check for image file extensions (case-insensitive)
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                    if (extension == ".png" || extension == ".jpg" || extension == ".jpeg" ||
                        extension == ".gif" || extension == ".bmp")
                    {
                        // Extract entry to memory stream
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (Stream entryStream = entry.Open())
                            {
                                entryStream.CopyTo(ms);
                            }
                            // Record name and byte count
                            ImageInfo info = new ImageInfo
                            {
                                Name = entry.Name,
                                ByteCount = ms.Length
                            };
                            imageInfos.Add(info);
                        }
                    }
                }
            }

            // Write CSV report
            using (StreamWriter writer = new StreamWriter(outputCsvPath, false, Encoding.UTF8))
            {
                writer.WriteLine("Name,ByteCount");
                foreach (ImageInfo info in imageInfos)
                {
                    writer.WriteLine($"{info.Name},{info.ByteCount}");
                }
            }

            Console.WriteLine($"Report generated: {outputCsvPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }

    private class ImageInfo
    {
        public string Name { get; set; }
        public long ByteCount { get; set; }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to audit all image files inside a ZIP package and produce a quick summary of their names and sizes for reporting or validation purposes.
 * 2. When an automated build process must extract thumbnails from a distribution archive and log their byte counts to a CSV for downstream analytics.
 * 3. When a desktop application allows users to upload a ZIP of photos and you want to display a table of each image’s filename and file size without writing the images to disk.
 * 4. When a data migration script has to read image entries from legacy ZIP backups and generate a CSV inventory to compare against a new storage system.
 * 5. When a compliance tool scans compressed archives to verify that only allowed image formats are present and records their metadata in a CSV audit log.
 */
