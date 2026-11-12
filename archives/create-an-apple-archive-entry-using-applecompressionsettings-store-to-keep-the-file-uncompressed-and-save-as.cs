// HOW-TO: Create Uncompressed Apple Archive (.aar) Using Store Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "sample.txt";
            string outputPath = "output/uncompressed.aar";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the archive with Store (no compression) settings
            using (FileStream outStream = File.Open(outputPath, FileMode.Create))
            using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
            {
                // Add the file entry to the archive
                archive.CreateEntry(Path.GetFileName(inputPath), inputPath);

                // Save the archive to the .aar file
                archive.Save(outStream);
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
 * 1. When you need to package files for iOS or macOS distribution without compression to preserve original file size and allow fast extraction.
 * 2. When generating an Apple Archive for a CI/CD pipeline where the archive must remain uncompressed for compatibility with a third‑party tool that expects .aar files in Store mode.
 * 3. When creating a backup of log files in .aar format while keeping them uncompressed so they can be opened directly by native Apple tools.
 * 4. When delivering resources to an Apple application that requires an uncompressed .aar to avoid runtime decompression overhead.
 * 5. When converting a plain text file into an Apple Archive for archival purposes while ensuring the archive size matches the source file exactly.
 */
