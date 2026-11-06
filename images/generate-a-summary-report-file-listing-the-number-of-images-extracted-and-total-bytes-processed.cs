// HOW-TO: Generate Image Extraction Summary Report From ZIP In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputZipPath = @"C:\Data\archive.zip";
            // Hardcoded output directory for extracted images
            string outputDir = @"C:\Data\ExtractedImages";
            // Path for the summary report file
            string reportPath = Path.Combine(outputDir, "summary.txt");

            // Verify that the input ZIP file exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);
            // Ensure the directory for the report file exists
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            int imageCount = 0;
            ulong totalBytes = 0;

            // Open the ZIP archive
            using (Archive archive = new Archive(inputZipPath))
            {
                // Iterate through all entries in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Determine file extension (case‑insensitive)
                    string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                    bool isImage = ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".bmp";

                    if (isImage)
                    {
                        // Build the destination path for the extracted image
                        string destPath = Path.Combine(outputDir, entry.Name);
                        // Ensure the directory for the entry exists
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                        // Extract the entry to the destination file
                        using (FileStream fs = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                        {
                            entry.Extract(fs);
                        }

                        imageCount++;
                        totalBytes += entry.UncompressedSize;
                    }
                }
            }

            // Create the summary report content
            string reportContent = $"Images extracted: {imageCount}{Environment.NewLine}Total bytes processed: {totalBytes}";
            // Write the report to the file system
            File.WriteAllText(reportPath, reportContent);

            Console.WriteLine($"Extraction completed. Summary report written to {reportPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to pull all picture files out of a zip archive and log how many were extracted and their total size.
 * 2. When you want to automate processing of user‑uploaded zip bundles containing photos, extracting only image formats and creating a concise report for auditing.
 * 3. When a batch job must unpack image assets from archived backups and record the extraction statistics for monitoring storage usage.
 * 4. When integrating a .NET application with Aspose.Zip to filter and extract PNG, JPG, GIF, BMP files while summarizing the operation in a text file.
 * 5. When generating documentation or logs that show the count and byte count of images extracted from a compressed package for compliance or quality checks.
 */
