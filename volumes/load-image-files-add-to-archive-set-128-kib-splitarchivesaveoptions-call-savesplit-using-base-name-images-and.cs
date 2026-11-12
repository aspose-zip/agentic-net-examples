// HOW-TO: Create Split ZIP Archive of Images with 128KB Parts in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDir = @"C:\ImagesInput";
            string outputDir = @"C:\ImagesOutput";

            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            Directory.CreateDirectory(outputDir);

            string[] imageFiles = Directory.GetFiles(inputDir, "*.*", SearchOption.TopDirectoryOnly)
                .Where(f => f.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".jpeg", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".bmp", StringComparison.OrdinalIgnoreCase) ||
                            f.EndsWith(".gif", StringComparison.OrdinalIgnoreCase))
                .ToArray();

            using (Archive archive = new Archive())
            {
                foreach (string filePath in imageFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("images", 128 * 1024);
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
 * 1. When you need to package a large collection of photos into a multi‑part ZIP file that can be transferred over size‑limited channels.
 * 2. When you want to automatically split a ZIP archive into 128 KB segments to meet email attachment limits.
 * 3. When you must generate a series of sequential ZIP parts for archival storage on media with a fixed block size.
 * 4. When a backup script has to create a split archive so that each part can be processed independently by downstream tools.
 * 5. When an application needs to create a portable, split ZIP of image assets for distribution to devices that only accept small file chunks.
 */
