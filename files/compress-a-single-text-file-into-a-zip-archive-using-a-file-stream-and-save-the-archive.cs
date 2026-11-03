// HOW-TO: Compress a Single Text File into a ZIP Archive Using File Streams in C# (Aspose.ZIP for .NET)
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
            string outputPath = "sample.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists (guard against null or empty directory name)
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }
            else
            {
                Directory.CreateDirectory(Directory.GetCurrentDirectory());
            }

            // Create streams for the ZIP file and the source file
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                using (FileStream source = File.Open(inputPath, FileMode.Open, FileAccess.Read))
                {
                    // Create a new ZIP archive with default entry settings
                    using (Archive archive = new Archive(new ArchiveEntrySettings()))
                    {
                        // Add the source file to the archive; entry name is the file name only
                        archive.CreateEntry(Path.GetFileName(inputPath), source);

                        // Save the archive to the ZIP file stream
                        archive.Save(zipFile);
                    }
                }
            }

            Console.WriteLine("Compression completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically zip a log file before uploading it to a server.
 * 2. When you want to archive a configuration text file for backup while preserving its original name.
 * 3. When an application must create a downloadable ZIP package containing a single report generated at runtime.
 * 4. When you need to compress user‑generated notes into a ZIP to reduce storage space on disk.
 * 5. When a service must bundle a temporary text file into a ZIP for secure email attachment.
 */
