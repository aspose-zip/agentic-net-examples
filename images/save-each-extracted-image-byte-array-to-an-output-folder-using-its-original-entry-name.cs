// HOW-TO: Extract Images from ZIP and Save with Original Names in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        string inputPath = "input.zip";
        string outputFolder = "ExtractedImages";

        try
        {
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(outputFolder);

            using (Archive archive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string entryName = entry.Name;
                    string lowerName = entryName.ToLowerInvariant();

                    if (lowerName.EndsWith(".png") ||
                        lowerName.EndsWith(".jpg") ||
                        lowerName.EndsWith(".jpeg") ||
                        lowerName.EndsWith(".gif") ||
                        lowerName.EndsWith(".bmp"))
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            using (MemoryStream memory = new MemoryStream())
                            {
                                entryStream.CopyTo(memory);
                                byte[] data = memory.ToArray();

                                string outputPath = Path.Combine(outputFolder, entryName);
                                string directory = Path.GetDirectoryName(outputPath);
                                if (!string.IsNullOrEmpty(directory))
                                {
                                    Directory.CreateDirectory(directory);
                                }

                                File.WriteAllBytes(outputPath, data);
                            }
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
 * 1. When you need to batch‑extract all PNG, JPG, GIF, or BMP files from a ZIP package and store them in a folder preserving their original filenames.
 * 2. When building a .NET service that processes uploaded zip files containing product photos and must save each image to a directory structure for further manipulation.
 * 3. When creating a migration tool that unpacks image assets from legacy zip archives and writes them to a new file system while keeping the original folder hierarchy.
 * 4. When developing a desktop application that lets users open a zip archive and automatically extracts embedded screenshots to a user‑specified location.
 * 5. When automating a CI/CD pipeline that validates and extracts image resources from zipped documentation bundles for quality‑check scripts.
 */
