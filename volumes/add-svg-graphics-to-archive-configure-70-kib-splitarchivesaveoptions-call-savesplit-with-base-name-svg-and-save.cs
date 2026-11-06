// HOW-TO: Create Split ZIP Archive of SVG Files with 70 KiB Segments in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing SVG files
            string dataDir = "Data";

            // Verify input directory exists
            if (!Directory.Exists(dataDir))
            {
                Console.Error.WriteLine($"Directory not found: {dataDir}");
                return;
            }

            // Prepare output base folder for split archive segments
            string outputBasePath = "svg";

            // Ensure the output folder exists
            Directory.CreateDirectory(outputBasePath);

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                // Add each SVG file from the input directory to the archive
                string[] svgFiles = Directory.GetFiles(dataDir, "*.svg");
                foreach (string filePath in svgFiles)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    FileInfo fileInfo = new FileInfo(filePath);
                    archive.CreateEntry(entryName, fileInfo);
                }

                // Configure split archive options with 70 KiB segment size
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(70 * 1024);

                // Save the archive as split segments under the base folder 'svg'
                archive.SaveSplit(outputBasePath, saveOptions);
            }

            Console.WriteLine("Split ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a collection of SVG graphics for distribution over networks that limit file size, you can split the ZIP into 70 KB parts using C#.
 * 2. When an application must store vector images in a portable archive while ensuring each segment fits on removable media such as small USB drives, this code creates split ZIP files.
 * 3. When a web service generates SVG assets on the fly and must send them to clients in chunks that can be reassembled, the split‑archive approach simplifies incremental download.
 * 4. When a backup routine requires archiving SVG resources into manageable pieces to avoid exceeding email attachment size limits, the C# split‑save method handles it automatically.
 * 5. When a CI/CD pipeline needs to archive SVG documentation and split it into fixed‑size parts for parallel processing or storage in chunk‑based blob containers, this code provides a straightforward solution.
 */
