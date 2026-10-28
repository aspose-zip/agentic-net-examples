// HOW-TO: Export Image Names and Sizes from ZIP to CSV in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputZipPath = "input.zip";

            // Hardcoded output CSV file path
            string outputCsvPath = "output.csv";

            // Validate input file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputCsvPath));

            // Open the ZIP archive
            using (Archive archive = new Archive(inputZipPath))
            {
                // Prepare CSV writer
                using (StreamWriter writer = new StreamWriter(outputCsvPath, false, Encoding.UTF8))
                {
                    // Write CSV header
                    writer.WriteLine("Name,Size");

                    // Iterate through entries
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Check for image file extensions (case-insensitive)
                        string entryNameLower = entry.Name.ToLowerInvariant();
                        if (entryNameLower.EndsWith(".png") ||
                            entryNameLower.EndsWith(".jpg") ||
                            entryNameLower.EndsWith(".jpeg") ||
                            entryNameLower.EndsWith(".gif") ||
                            entryNameLower.EndsWith(".bmp") ||
                            entryNameLower.EndsWith(".tiff"))
                        {
                            ulong sizeInBytes = entry.UncompressedSize;
                            writer.WriteLine($"{entry.Name},{sizeInBytes}");
                        }
                    }
                }
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
 * 1. When you need to create an inventory of all image files inside a ZIP archive for reporting or auditing purposes.
 * 2. When a C# application must extract metadata such as file names and uncompressed sizes of pictures without actually decompressing the images.
 * 3. When generating a CSV manifest to feed into downstream tools that analyze image storage usage in compressed archives.
 * 4. When automating a build pipeline that validates that image assets in a package meet size constraints before deployment.
 * 5. When building a lightweight catalog of image resources in a zip to display in a UI grid without loading the image data.
 */
