// HOW-TO: Create TAR LZ4 Archive From Multiple Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing the documents to be archived
            string inputDirectory = @"C:\Data\Input";

            // Hardcoded output TAR.LZ4 archive path
            string outputArchivePath = @"C:\Data\Output\archive.tar.lz4";

            // List of document file names to include in the TAR archive
            string[] documentFiles = new string[]
            {
                "doc1.txt",
                "doc2.pdf",
                "doc3.docx"
            };

            // Verify that each input file exists before proceeding
            foreach (string fileName in documentFiles)
            {
                string inputFilePath = Path.Combine(inputDirectory, fileName);
                if (!File.Exists(inputFilePath))
                {
                    Console.Error.WriteLine($"File not found: {inputFilePath}");
                    return;
                }
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Create a TAR archive, add entries, and save it with LZ4 compression
            using (TarArchive archive = new TarArchive())
            {
                foreach (string fileName in documentFiles)
                {
                    string sourcePath = Path.Combine(inputDirectory, fileName);
                    // Add each file to the TAR archive; the entry name inside the archive is the file name
                    archive.CreateEntry(fileName, sourcePath);
                }

                // Save the TAR archive compressed with LZ4
                archive.SaveLZ4Compressed(outputArchivePath);
            }

            Console.WriteLine($"Archive created successfully at: {outputArchivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several documents into a single TAR file and compress it with LZ4 for fast network transfer in a .NET application.
 * 2. When you want to generate a lightweight, LZ4‑compressed backup of text, PDF, and Word files before uploading them to cloud storage using C#.
 * 3. When an automated build process must package generated reports into a TAR.LZ4 archive for archiving or distribution to downstream services.
 * 4. When you are implementing a custom export feature that creates a portable TAR archive with LZ4 compression for end‑users to download multiple files at once.
 * 5. When you need to prepare a set of files for secure archival on a Linux system, using Aspose.Zip’s TarArchive and LZ4 compression from a Windows C# service.
 */
