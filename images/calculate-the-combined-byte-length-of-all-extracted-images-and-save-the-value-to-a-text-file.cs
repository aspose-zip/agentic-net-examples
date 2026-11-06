// HOW-TO: Calculate Total Size Of Extracted Images From Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = "input.zip";

            // Hardcoded output directory for extracted images
            string outputDirectory = "output";

            // Hardcoded result text file path
            string resultFilePath = Path.Combine(outputDirectory, "combined_length.txt");

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            long totalBytes = 0L;

            // Open the ZIP archive
            using (Archive archive = new Archive(inputPath))
            {
                // Iterate through all entries in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Skip directories
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Determine if the entry is an image based on its extension
                    string extension = Path.GetExtension(entry.Name).ToLowerInvariant();
                    bool isImage = extension == ".png" ||
                                   extension == ".jpg" ||
                                   extension == ".jpeg" ||
                                   extension == ".gif" ||
                                   extension == ".bmp" ||
                                   extension == ".tiff" ||
                                   extension == ".tif" ||
                                   extension == ".webp";

                    if (!isImage)
                    {
                        continue;
                    }

                    // Build the destination path for the extracted image
                    string destinationPath = Path.Combine(outputDirectory, entry.Name);

                    // Ensure the directory for the entry exists (handles entries in subfolders)
                    string entryDirectory = Path.GetDirectoryName(destinationPath);
                    if (!string.IsNullOrEmpty(entryDirectory))
                    {
                        Directory.CreateDirectory(entryDirectory);
                    }

                    // Extract the image to the destination path
                    entry.Extract(destinationPath);

                    // Accumulate the size of the extracted file
                    FileInfo extractedInfo = new FileInfo(destinationPath);
                    totalBytes += extractedInfo.Length;
                }
            }

            // Write the combined byte length to the result text file
            using (StreamWriter writer = new StreamWriter(resultFilePath, false))
            {
                writer.WriteLine(totalBytes);
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
 * 1. When you need to verify that all images extracted from a ZIP archive do not exceed a storage quota, you can sum their byte lengths and store the total in a text file.
 * 2. When generating a report of image data size for a batch of uploaded ZIP files, this code lets you compute the combined size of PNG, JPEG, and other image formats automatically.
 * 3. When performing quality‑control on archived media assets, you can use the total byte count to compare against expected size thresholds before further processing.
 * 4. When building a migration tool that moves image files from ZIP archives to a file system, recording the combined length helps track data transferred and detect missing files.
 * 5. When creating a logging mechanism for a CI/CD pipeline that extracts images from packages, the total byte length saved to a text file provides a quick checksum for validation.
 */
