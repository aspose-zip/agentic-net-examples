// HOW-TO: Extract Image.png From ARJ Archive To MemoryStream And Save In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Arj;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "sample.arj";
        string outputPath = "output\\image.png";

        // Ensure input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Open the ARJ archive
            using (ArjArchive archive = new ArjArchive(inputPath))
            {
                // Locate the entry named "image.png"
                var entry = archive.Entries.FirstOrDefault(e => e.Name.Equals("image.png", StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine("Entry 'image.png' not found in the archive.");
                    return;
                }

                // Extract the entry into a writable MemoryStream
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    entry.Extract(memoryStream);
                    memoryStream.Position = 0; // Reset stream position for reading

                    // Save the MemoryStream content to disk
                    using (FileStream fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write))
                    {
                        memoryStream.CopyTo(fileStream);
                    }
                }
            }

            Console.WriteLine($"Entry extracted successfully to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically pull a single image out of an ARJ backup without writing the entire archive to disk.
 * 2. When you want to process the extracted file in memory before persisting it, such as resizing or analyzing the image.
 * 3. When you are building a .NET application that must extract resources from legacy ARJ archives on the fly.
 * 4. When you need to verify the presence of a specific entry in an ARJ file and store it to a known output folder.
 * 5. When you are migrating data from old ARJ archives to modern file systems and require a safe, stream‑based extraction.
 */
