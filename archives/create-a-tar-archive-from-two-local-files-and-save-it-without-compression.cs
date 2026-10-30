// HOW-TO: Create a TAR Archive from Multiple Files Without Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input file paths
            string inputPath1 = @"C:\Temp\file1.txt";
            string inputPath2 = @"C:\Temp\file2.txt";

            // Hardcoded output TAR file path
            string outputPath = @"C:\Temp\output.tar";

            // Verify first input file exists
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }

            // Verify second input file exists
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            Directory.CreateDirectory(outputDir);

            // Create TAR archive and add files
            using (TarArchive tar = new TarArchive())
            {
                // Add first file to the archive
                tar.CreateEntry(inputPath1, Path.GetFileName(inputPath1));

                // Add second file to the archive
                tar.CreateEntry(inputPath2, Path.GetFileName(inputPath2));

                // Save the TAR archive without compression
                tar.Save(outputPath);
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
 * 1. When you need to bundle several log files into a single TAR package for easy transfer to a Linux server without applying any compression.
 * 2. When you want to create an uncompressed archive of configuration files to preserve their original size for checksum verification during deployment.
 * 3. When you are generating a TAR bundle of source code snippets to include in a documentation package that must remain readable without decompression.
 * 4. When you need to package data files for a legacy system that only accepts plain TAR archives and cannot handle compressed formats.
 * 5. When you are automating a backup script that archives daily reports into a TAR file so they can be streamed directly to cloud storage without extra CPU overhead.
 */
