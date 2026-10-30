// HOW-TO: Create a TAR Archive and Compress with LZ4 in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output file
            string dataDir = "Data";
            string outputPath = "Output/archive.tar.lz4";

            // List of files to add to the TAR archive
            string[] inputFiles = new string[]
            {
                Path.Combine(dataDir, "file1.txt"),
                Path.Combine(dataDir, "file2.txt"),
                Path.Combine(dataDir, "file3.txt")
            };

            // Verify each input file exists
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive and add entries
            using (TarArchive archive = new TarArchive())
            {
                foreach (string inputPath in inputFiles)
                {
                    // Use the file name as the entry name inside the TAR
                    string entryName = Path.GetFileName(inputPath);
                    archive.CreateEntry(entryName, inputPath);
                }

                // Save the TAR archive compressed with LZ4 (default settings)
                archive.SaveLZ4Compressed(outputPath);
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
 * 1. When you need to bundle several log files into a single TAR file and reduce size with fast LZ4 compression for quick transfer.
 * 2. When you want to package configuration files for deployment to a Linux server using a .tar.lz4 archive generated from a .NET application.
 * 3. When you must archive backup copies of text documents and store them in a compressed TAR container to save disk space while preserving file names.
 * 4. When an automated build process requires creating a TAR.LZ4 archive of generated reports before uploading them to a cloud storage service.
 * 5. When you are implementing a cross‑platform data export feature that creates a single compressed archive of multiple files for users to download.
 */
