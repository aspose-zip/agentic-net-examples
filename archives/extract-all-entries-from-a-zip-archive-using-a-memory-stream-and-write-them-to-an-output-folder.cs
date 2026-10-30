// HOW-TO: Extract All Files From Zip Using MemoryStream In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file and output folder paths
            string inputPath = "C:\\Data\\sample.zip";
            string outputPath = "C:\\Data\\Extracted";

            // Verify the input ZIP file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory (and its parent) exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            // Load the ZIP archive into a memory stream
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (MemoryStream memoryStream = new MemoryStream())
            {
                fileStream.CopyTo(memoryStream);
                memoryStream.Position = 0;

                // Open the archive from the memory stream
                using (Archive archive = new Archive(memoryStream))
                {
                    // Iterate over all entries in the archive
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Determine the full path for the extracted entry
                        string destinationPath = Path.Combine(outputPath, entry.Name);

                        // Create any necessary subdirectories for the entry
                        string entryDir = Path.GetDirectoryName(destinationPath);
                        if (!string.IsNullOrEmpty(entryDir))
                        {
                            Directory.CreateDirectory(entryDir);
                        }

                        // Extract the entry to the destination file
                        using (FileStream outStream = File.OpenWrite(destinationPath))
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.CopyTo(outStream);
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
 * 1. When you need to unpack a downloaded ZIP file entirely in memory before saving its contents to a specific directory in a C# application.
 * 2. When processing large ZIP archives on a server where reading the file into a MemoryStream avoids locking the original file during extraction.
 * 3. When extracting nested folders from a ZIP archive to recreate the original directory structure on disk using Aspose.Zip in .NET.
 * 4. When you want to programmatically verify that a ZIP file exists, create the target folder hierarchy, and extract every entry without using temporary files.
 * 5. When building a Windows service that periodically extracts configuration files from a ZIP bundle stored on disk into a configurable output location.
 */
