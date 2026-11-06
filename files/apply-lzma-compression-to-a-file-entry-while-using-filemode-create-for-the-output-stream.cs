// HOW-TO: Create LZMA Compressed ZIP File with FileMode Create in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;
using Aspose.Zip.LZMA;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "input.txt";
            string outputPath = "output_lzma.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                using (Archive archive = new Archive(new ArchiveEntrySettings(new LzmaCompressionSettings())))
                {
                    using (FileStream source = File.Open(inputPath, FileMode.Open, FileAccess.Read))
                    {
                        archive.CreateEntry("input.txt", source);
                    }

                    archive.Save(zipFile);
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
 * 1. When you need to package a text file into a ZIP archive using high‑ratio LZMA compression for efficient storage or transmission.
 * 2. When you want to generate a new ZIP file from scratch, ensuring the output stream is created fresh with FileMode.Create to avoid appending to existing files.
 * 3. When your application must compress logs or configuration files on the fly before uploading them to a cloud service, using Aspose.Zip’s LZMA settings for maximum reduction.
 * 4. When you are building a backup utility that stores individual files in a compressed archive and requires deterministic file creation without overwriting existing archives.
 * 5. When you need to integrate .NET code that reads a source file, compresses it with LZMA, and writes the result to a newly created ZIP file for later extraction by standard ZIP tools.
 */
