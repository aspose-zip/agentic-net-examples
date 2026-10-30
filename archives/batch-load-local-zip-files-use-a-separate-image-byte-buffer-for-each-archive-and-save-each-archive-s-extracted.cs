// HOW-TO: Batch Extract Images From Multiple ZIP Files Using Separate Buffers in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing ZIP files
            string inputDirectory = @"C:\InputZips";
            // Hardcoded base output directory for extracted images
            string outputBaseDirectory = @"C:\ExtractedImages";

            // Ensure the base output directory exists
            Directory.CreateDirectory(outputBaseDirectory);

            // Get all ZIP files in the input directory
            string[] zipFiles = Directory.GetFiles(inputDirectory, "*.zip");

            foreach (string zipPath in zipFiles)
            {
                // Verify the ZIP file exists
                if (!File.Exists(zipPath))
                {
                    Console.Error.WriteLine($"File not found: {zipPath}");
                    continue;
                }

                // Create a subdirectory for this archive's extracted images
                string archiveName = Path.GetFileNameWithoutExtension(zipPath);
                string archiveOutputDir = Path.Combine(outputBaseDirectory, archiveName);
                Directory.CreateDirectory(archiveOutputDir);

                // Separate buffer for this archive
                byte[] buffer = new byte[81920];

                // Open the ZIP archive
                using (FileStream zipStream = File.OpenRead(zipPath))
                using (Archive archive = new Archive(zipStream))
                {
                    // Iterate through entries
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Process only image files based on extension
                        string ext = Path.GetExtension(entry.Name).ToLowerInvariant();
                        if (ext == ".png" || ext == ".jpg" || ext == ".jpeg" || ext == ".bmp" || ext == ".gif")
                        {
                            string outputFilePath = Path.Combine(archiveOutputDir, entry.Name);
                            // Ensure the directory for the entry exists (handles subfolders)
                            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

                            // Extract the entry using the archive-specific buffer
                            using (Stream entryStream = entry.Open())
                            using (FileStream outputFileStream = File.Create(outputFilePath))
                            {
                                int bytesRead;
                                while ((bytesRead = entryStream.Read(buffer, 0, buffer.Length)) > 0)
                                {
                                    outputFileStream.Write(buffer, 0, bytesRead);
                                }
                            }

                            Console.WriteLine($"Extracted {entry.Name} to {outputFilePath}");
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
 * 1. When you need to process a folder of uploaded ZIP archives and extract only the photos to organized subfolders.
 * 2. When a desktop application must unpack image assets from many zip packages without mixing their data streams.
 * 3. When a server script has to read several zip files sequentially, using a dedicated byte buffer for each to avoid memory corruption.
 * 4. When you want to automatically create a separate output directory for each archive so that extracted images are kept isolated.
 * 5. When you are building a migration tool that pulls image files from legacy zip collections and saves them to a new file system hierarchy.
 */
