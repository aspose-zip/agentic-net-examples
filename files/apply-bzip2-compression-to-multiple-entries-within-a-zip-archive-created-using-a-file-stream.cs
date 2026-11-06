// HOW-TO: Create ZIP Archive With BZip2 Compression For Multiple Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath1 = "data/file1.txt";
        string inputPath2 = "data/file2.txt";
        string outputPath = "output/compressed.zip";

        // Validate input files
        if (!File.Exists(inputPath1))
        {
            Console.Error.WriteLine($"File not found: {inputPath1}");
            return;
        }
        if (!File.Exists(inputPath2))
        {
            Console.Error.WriteLine($"File not found: {inputPath2}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Create the ZIP file stream
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            {
                // Create an archive with BZip2 compression for its entries
                using (Archive archive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
                {
                    // Open source files
                    using (FileStream source1 = File.Open(inputPath1, FileMode.Open, FileAccess.Read))
                    using (FileStream source2 = File.Open(inputPath2, FileMode.Open, FileAccess.Read))
                    {
                        // Add entries to the archive
                        archive.CreateEntry("file1.txt", source1);
                        archive.CreateEntry("file2.txt", source2);

                        // Save the archive while source streams are still open
                        archive.Save(zipStream);
                    }
                }
            }

            Console.WriteLine("ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several log files into a single ZIP while reducing size with BZip2 for efficient storage or transfer in a .NET application.
 * 2. When an automated backup service must create compressed archives on the fly using file streams to avoid loading entire files into memory.
 * 3. When you want to generate a downloadable package of user‑uploaded documents with BZip2 compression to meet bandwidth constraints.
 * 4. When a server‑side process must archive configuration files and send them to a remote system, using BZip2 to achieve higher compression than Deflate.
 * 5. When integrating Aspose.Zip into a CI pipeline to compress build artifacts with BZip2 before publishing them as release assets.
 */
