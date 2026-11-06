// HOW-TO: Count Images in ZIP and Save Summary to JSON in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.zip";
            string outputPath = "output/summary.json";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Archive archive = new Archive(inputPath))
            {
                int totalImages = 0;

                foreach (ArchiveEntry entry in archive.Entries)
                {
                    if (!entry.IsDirectory)
                    {
                        string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                        if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".gif" || ext == ".bmp" || ext == ".tiff")
                        {
                            totalImages++;
                        }
                    }
                }

                string json = $"{{\"totalImages\":{totalImages}}}";
                File.WriteAllText(outputPath, json);
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
 * 1. When you need to generate a quick report of how many image files are stored in a ZIP package for inventory or compliance purposes.
 * 2. When an automated build process must verify that a zipped asset bundle contains the expected number of images before publishing.
 * 3. When a web service extracts metadata from uploaded ZIP archives and returns a JSON payload summarizing image counts to the client.
 * 4. When a desktop application logs the quantity of pictures inside user‑provided ZIP files to aid in storage‑usage analysis.
 * 5. When a data‑migration script records image statistics from legacy ZIP archives into JSON files for downstream processing.
 */
