// HOW-TO: Calculate Average Image Size from ZIP and Save to Text in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "input.zip";
            string outputDirectory = "output";
            string outputTextPath = Path.Combine(outputDirectory, "average.txt");

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTextPath));

            long totalSize = 0L;
            int imageCount = 0;
            string[] imageExtensions = new string[] { ".png", ".jpg", ".jpeg", ".bmp", ".gif" };

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                    bool isImage = false;
                    foreach (string imgExt in imageExtensions)
                    {
                        if (extension == imgExt)
                        {
                            isImage = true;
                            break;
                        }
                    }

                    if (!isImage)
                        continue;

                    // Ensure subdirectory for entry exists
                    string entryOutputPath = Path.Combine(outputDirectory, entry.Name);
                    string entryDir = Path.GetDirectoryName(entryOutputPath);
                    Directory.CreateDirectory(entryDir);

                    // Extract the image
                    entry.Extract(entryOutputPath);

                    // Accumulate size
                    totalSize += (long)entry.UncompressedSize;
                    imageCount++;
                }
            }

            // Calculate average size
            double averageSize = imageCount > 0 ? (double)totalSize / imageCount : 0.0;

            // Write result to text file
            File.WriteAllText(outputTextPath, $"Average image size: {averageSize} bytes");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to report the average size of all photos stored in a ZIP package for quality‑control or storage‑budget analysis.
 * 2. When an application must extract images from a compressed archive, compute their mean byte size, and log the result for later auditing.
 * 3. When a batch‑processing script processes incoming ZIP uploads and needs to verify that extracted images meet expected size thresholds.
 * 4. When you want to generate a simple text summary of image dimensions after extracting them from a ZIP file for documentation purposes.
 * 5. When a data‑pipeline requires the average uncompressed image size to adjust downstream compression settings or allocate resources.
 */
