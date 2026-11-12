// HOW-TO: Create Zip Archive From Binary File Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string inputPath = "data/input.bin";
            string outputPath = "output/compressed.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open streams and create ZIP archive
            using (FileStream sourceStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            using (Archive archive = new Archive(new ArchiveEntrySettings()))
            {
                // Add the file as an entry
                archive.CreateEntry("input.bin", sourceStream);

                // Save the archive
                archive.Save(zipFile);
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
 * 1. When you need to package a large binary payload into a ZIP file for distribution in a .NET application.
 * 2. When you want to programmatically create a compressed archive of log or data files before uploading them to cloud storage.
 * 3. When you must generate a ZIP archive on the fly in a web service without relying on external command‑line tools.
 * 4. When you need to ensure the output directory exists and handle missing input files gracefully while compressing files in C#.
 * 5. When you are integrating Aspose.Zip to add entries to an archive and save it directly to a stream for further processing.
 */
