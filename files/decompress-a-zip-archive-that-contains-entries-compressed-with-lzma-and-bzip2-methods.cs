// HOW-TO: Extract LZMA and BZip2 Compressed Files from ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input ZIP file path and output directory
        string inputPath = "C:\\Data\\sample_lzma_bzip2.zip";
        string outputDir = "C:\\Data\\Extracted";

        try
        {
            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the ZIP archive for reading
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    // Iterate through each entry in the archive
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Build the full path for the extracted entry
                        string destinationPath = Path.Combine(outputDir, entry.Name);

                        // Ensure the directory for the entry exists
                        Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));

                        // Extract the entry to the destination path
                        entry.Extract(destinationPath);

                        Console.WriteLine($"Extracted: {entry.Name}");
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
 * 1. When you need to unpack a ZIP archive that contains LZMA or BZip2 compressed resources for a desktop application.
 * 2. When a build pipeline receives third‑party packages using mixed compression methods and you must extract them automatically in C#.
 * 3. When you are migrating legacy data stored in ZIP files with LZMA/BZip2 entries to a new file system.
 * 4. When a game engine loads asset bundles packaged with LZMA and BZip2 compression and you need to extract them at runtime.
 * 5. When a cloud service processes user‑uploaded ZIP files that may use LZMA or BZip2 and you must safely extract their contents.
 */
