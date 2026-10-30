// HOW-TO: Create Uncompressed ZIP Archive Using Store Compression in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input files
            string inputFile1 = "data/file1.txt";
            string inputFile2 = "data/file2.txt";

            // Hardcoded output file
            string outputPath = "uncompressed_all.zip";

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(string.IsNullOrEmpty(outputDir) ? "." : outputDir);

            // Create ZIP archive with Store (no compression) settings
            using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
            {
                archive.CreateEntry("file1.txt", inputFile1);
                archive.CreateEntry("file2.txt", inputFile2);

                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    archive.Save(outStream);
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
 * 1. When you need to package log files for quick extraction without CPU overhead, you can create an uncompressed ZIP using Store compression.
 * 2. When transferring large binary assets that are already compressed (e.g., images or videos) and you want to avoid double‑compression, storing them uncompressed preserves original size and speeds up archiving.
 * 3. When generating archives for legacy systems that only support uncompressed entries, this code ensures compatibility by using the Store method.
 * 4. When creating a ZIP for a checksum or digital signature process where the file bytes must remain unchanged, storing entries without compression is required.
 * 5. When building a deployment package that will be unpacked on the fly by a script or installer, an uncompressed archive reduces extraction time and simplifies streaming.
 */
