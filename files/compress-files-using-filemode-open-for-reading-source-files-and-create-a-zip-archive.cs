// HOW-TO: Create ZIP Archive From Files Using FileMode.Open In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = @"data\file1.txt";
            string inputPath2 = @"data\file2.txt";

            // Verify input files exist
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

            // Hardcoded output ZIP path
            string outputPath = @"output\archive.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open source files for reading
            using (FileStream sourceStream1 = File.Open(inputPath1, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (FileStream sourceStream2 = File.Open(inputPath2, FileMode.Open, FileAccess.Read, FileShare.Read))
            // Create the ZIP file stream
            using (FileStream zipFileStream = File.Open(outputPath, FileMode.Create, FileAccess.Write, FileShare.None))
            // Create the Aspose.Zip archive
            using (Archive archive = new Archive())
            {
                // Add entries to the archive using the opened streams
                archive.CreateEntry("file1.txt", sourceStream1);
                archive.CreateEntry("file2.txt", sourceStream2);

                // Save the archive with ASCII encoding
                archive.Save(zipFileStream, new ArchiveSaveOptions() { Encoding = Encoding.ASCII });
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
 * 1. When you need to bundle multiple log files into a single ZIP for easy transfer or backup in a .NET application.
 * 2. When you want to compress configuration files on the fly without loading them entirely into memory, using FileMode.Open for efficient streaming.
 * 3. When generating downloadable archives of user‑uploaded documents in a web service and you must control the encoding of the ZIP entries.
 * 4. When automating nightly backups of specific data files and need to ensure the output directory is created before saving the archive.
 * 5. When integrating Aspose.Zip into an existing C# workflow to create ZIP files with explicit read/write file sharing settings for thread‑safe operations.
 */
