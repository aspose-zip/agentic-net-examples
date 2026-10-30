// HOW-TO: Create a Gzipped TAR Archive of Images in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing images
            string inputDirectory = @"C:\Images";

            // List of image file names to include in the archive
            string[] imageFiles = new string[]
            {
                "image1.jpg",
                "image2.png",
                "image3.bmp"
            };

            // Hardcoded output path for the compressed TAR archive
            string outputPath = @"C:\Output\images.tar.gz";

            // Verify each input file exists
            foreach (string fileName in imageFiles)
            {
                string filePath = Path.Combine(inputDirectory, fileName);
                if (!File.Exists(filePath))
                {
                    Console.Error.WriteLine($"File not found: {filePath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive, add entries, and save as GZIP-compressed file
            using (TarArchive archive = new TarArchive())
            {
                foreach (string fileName in imageFiles)
                {
                    string sourcePath = Path.Combine(inputDirectory, fileName);
                    archive.CreateEntry(fileName, sourcePath);
                }

                archive.SaveGzipped(outputPath);
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
 * 1. When you need to bundle a set of image files into a single compressed package for easy transfer over a network.
 * 2. When you want to create a .tar.gz backup of website assets before deploying updates.
 * 3. When you must generate a portable archive of screenshots to store in a version‑controlled repository.
 * 4. When an application requires sending multiple images to a remote service that only accepts gzipped TAR streams.
 * 5. When you are implementing a scheduled job that archives daily generated graphics into a compressed TAR file to save disk space.
 */
