// HOW-TO: Generate Image Extraction Summary Report from ZIP with Aspose in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = @"C:\Data\sample.zip";
        string outputDir = @"C:\Data\Extracted";
        string reportPath = @"C:\Data\ExtractReport.txt";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(reportPath));

            int imageCount = 0;
            ulong totalBytes = 0UL;

            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                    if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".bmp")
                    {
                        string destPath = Path.Combine(outputDir, entry.Name);
                        Directory.CreateDirectory(Path.GetDirectoryName(destPath));

                        using (FileStream fs = new FileStream(destPath, FileMode.Create, FileAccess.Write))
                        {
                            entry.Extract(fs);
                        }

                        imageCount++;
                        totalBytes += entry.UncompressedSize;
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(reportPath, false, Encoding.UTF8))
            {
                writer.WriteLine($"Images extracted: {imageCount}");
                writer.WriteLine($"Total bytes processed: {totalBytes}");
            }

            Console.WriteLine("Extraction completed. Summary report written.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract only image files from a ZIP archive and log how many were extracted and their total size using Aspose.Zip in a C# application.
 * 2. When a batch processing job must unpack PNG, JPG, GIF, or BMP files from a compressed package and produce a UTF‑8 text report for auditing purposes.
 * 3. When you want to automate the creation of an extraction summary for digital asset pipelines that handle large zip bundles of pictures in .NET.
 * 4. When a desktop utility must verify the amount of data extracted from a zip to ensure it meets storage or bandwidth constraints.
 * 5. When integrating Aspose.Zip into a CI/CD workflow to extract images and record extraction statistics for compliance documentation.
 */
