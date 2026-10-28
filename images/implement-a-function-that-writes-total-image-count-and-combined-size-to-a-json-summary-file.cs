// HOW-TO: Generate JSON Summary of Image Count and Total Size in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = "input_images";
            string outputFile = "summary.json";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            string[] imageExtensions = new string[] { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff" };
            int imageCount = 0;
            long totalSize = 0L;

            string[] files = Directory.GetFiles(inputDirectory);
            foreach (string filePath in files)
            {
                string extension = Path.GetExtension(filePath);
                foreach (string imgExt in imageExtensions)
                {
                    if (string.Equals(extension, imgExt, StringComparison.OrdinalIgnoreCase))
                    {
                        imageCount++;
                        FileInfo info = new FileInfo(filePath);
                        totalSize += info.Length;
                        break;
                    }
                }
            }

            string outputDir = Path.GetDirectoryName(outputFile);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string json = $"{{\"totalImageCount\":{imageCount},\"combinedSizeBytes\":{totalSize}}}";
            using (StreamWriter writer = new StreamWriter(outputFile, false, Encoding.UTF8))
            {
                writer.Write(json);
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
 * 1. When you need to create a quick inventory report of all images in a folder for a web gallery deployment.
 * 2. When a build script must verify that the expected number of assets and their total size stay within a CI/CD pipeline limit.
 * 3. When a desktop application logs the count and combined byte size of user‑uploaded photos to include in a JSON analytics payload.
 * 4. When a migration tool needs to compare source and destination image collections by reading a JSON summary file.
 * 5. When an automated backup process records the total image count and storage usage before compressing the files into a ZIP archive.
 */
