// HOW-TO: Calculate Total Size of Extracted Images from ZIP and Save to Text in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "C:\\Data\\images.zip";
            string outputDir = "C:\\Data\\ExtractedImages";
            string resultFile = "C:\\Data\\combined_length.txt";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(resultFile));

            ulong totalBytes = 0;

            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                        if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".bmp")
                        {
                            string destPath = Path.Combine(outputDir, entry.Name);
                            Directory.CreateDirectory(Path.GetDirectoryName(destPath));
                            entry.Extract(destPath);
                            totalBytes += entry.UncompressedSize;
                        }
                    }
                }
            }

            File.WriteAllText(resultFile, totalBytes.ToString());

            Console.WriteLine($"Combined byte length: {totalBytes}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to report the combined uncompressed size of all image files extracted from a ZIP archive for storage budgeting.
 * 2. When generating a summary file that lists the total bytes of extracted PNG, JPEG, GIF, or BMP images for audit logs.
 * 3. When validating that the extracted images do not exceed a predefined size limit before further processing in a .NET application.
 * 4. When creating a simple checksum‑like report by writing the total image byte count to a text file for downstream scripts.
 * 5. When automating a workflow that extracts images from a zip, calculates their total size, and stores the result for display in a UI dashboard.
 */
