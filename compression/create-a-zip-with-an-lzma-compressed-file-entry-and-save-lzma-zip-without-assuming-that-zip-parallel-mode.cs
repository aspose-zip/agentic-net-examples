// HOW-TO: Create a ZIP with LZMA Compression in C# Using Aspose.Zip (Aspose.ZIP for .NET)
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
            string inputPath = "data/input.txt";
            string outputPath = "output/lzma.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open the source file for reading
            using (FileStream sourceStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                // Create the ZIP archive with LZMA compression for its entries
                using (Archive archive = new Archive(new ArchiveEntrySettings(new LzmaCompressionSettings())))
                {
                    // Add the file entry to the archive
                    archive.CreateEntry("input.txt", sourceStream);

                    // Save the archive to the output file
                    using (FileStream zipFileStream = File.Open(outputPath, FileMode.Create))
                    {
                        archive.Save(zipFileStream);
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
 * 1. When you need to package a text file into a highly compressed ZIP for distribution while ensuring the archive uses the LZMA algorithm with Aspose.Zip in a .NET application.
 * 2. When your application must generate a ZIP archive on the fly from user‑uploaded files and you want to minimize size without relying on ZIP parallel mode support.
 * 3. When you are automating backup of configuration files and require LZMA compression to reduce storage costs in a C# service.
 * 4. When you need to create a ZIP archive that can be opened by standard ZIP tools but uses LZMA for better compression, and you must control the compression settings programmatically.
 * 5. When integrating Aspose.Zip into a CI/CD pipeline to compress build artifacts with LZMA before publishing them to an artifact repository.
 */
