// HOW-TO: Extract Images from ZIP and Prefix Filenames with Entry Index in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file and output directory
            string inputPath = "input.zip";
            string outputDirectory = "output";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                int entryIndex = 0;
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Process only file entries with image extensions
                    string entryName = entry.Name;
                    string extension = Path.GetExtension(entryName).ToLowerInvariant();

                    bool isImage = extension == ".png" ||
                                   extension == ".jpg" ||
                                   extension == ".jpeg" ||
                                   extension == ".gif" ||
                                   extension == ".bmp";

                    if (isImage)
                    {
                        // Build new file name with index prefix
                        string newFileName = $"{entryIndex}_{entryName}";
                        string destinationPath = Path.Combine(outputDirectory, newFileName);

                        // Extract the entry to the new file name
                        entry.Extract(destinationPath);
                    }

                    entryIndex++;
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
 * 1. When you need to extract only image files from a zip archive and keep track of their original order by adding an index to each filename.
 * 2. When processing a batch of photos packaged in a zip and you want the extracted files to be uniquely named to avoid name collisions.
 * 3. When building a migration script that moves images from archived backups to a new folder while preserving their sequence for later sorting.
 * 4. When creating a reporting tool that extracts screenshots from a zip and prefixes them with their entry number for easy reference.
 * 5. When automating a CI pipeline that unpacks image assets from a zip and renames them with an index to ensure deterministic file naming.
 */
