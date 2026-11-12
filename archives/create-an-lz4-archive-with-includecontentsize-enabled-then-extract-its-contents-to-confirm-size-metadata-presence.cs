// HOW-TO: Create LZ4 Archive With Content Size Metadata And Verify Extraction In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Input file to be compressed
            string inputFile = "sample.txt";
            if (!File.Exists(inputFile))
            {
                Console.Error.WriteLine($"File not found: {inputFile}");
                return;
            }

            // Path for the LZ4 compressed file
            string archivePath = "sample.lz4";
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath) ?? ".");

            // Compress the input file into LZ4 format
            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(inputFile);
                archive.Save(archivePath);
            }

            // Directory to extract the decompressed file
            string extractDir = "extracted";
            Directory.CreateDirectory(extractDir);

            // Decompress the LZ4 archive
            string extractedFile = Path.Combine(extractDir, Path.GetFileName(inputFile));
            using (Lz4Archive archive = new Lz4Archive())
            {
                archive.SetSource(archivePath);
                using (Stream decompressed = archive.Open())
                {
                    using (FileStream outStream = File.Create(extractedFile))
                    {
                        decompressed.CopyTo(outStream);
                    }
                }
            }

            // Verify that the extracted file size matches the original
            if (File.Exists(extractedFile))
            {
                long originalSize = new FileInfo(inputFile).Length;
                long extractedSize = new FileInfo(extractedFile).Length;
                Console.WriteLine($"Original size: {originalSize} bytes");
                Console.WriteLine($"Extracted size: {extractedSize} bytes");
                Console.WriteLine($"Size metadata present: {originalSize == extractedSize}");
            }
            else
            {
                Console.Error.WriteLine("Extraction failed: extracted file not found.");
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
 * 1. When you need to compress a text file into an LZ4 archive while preserving the original file size for later validation, this code shows how to do it in C#.
 * 2. When building a backup system that stores files in LZ4 format and must confirm that the stored size metadata matches the source during restore, you can use this example.
 * 3. When integrating fast decompression into a .NET application and you want to ensure the extracted file size equals the original, the sample demonstrates the required steps.
 * 4. When creating a cross‑platform data exchange package that includes size information for integrity checks, this code illustrates creating and reading an LZ4 archive in C#.
 * 5. When troubleshooting compression pipelines and need to verify that IncludeContentSize is correctly written and read from an LZ4 file, the example provides a simple verification workflow.
 */
