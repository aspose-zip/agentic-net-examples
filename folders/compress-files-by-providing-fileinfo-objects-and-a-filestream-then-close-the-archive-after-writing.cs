// HOW-TO: Compress Multiple Files into ZIP Using FileInfo and FileStream in C# (Aspose.ZIP for .NET)
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
            string inputPath1 = @"Data\input1.txt";
            string inputPath2 = @"Data\input2.txt";

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

            // Hardcoded output zip path
            string outputPath = @"Output\compressed.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open a FileStream for the zip archive
            using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
            {
                // Create FileInfo objects for the input files
                FileInfo fileInfo1 = new FileInfo(inputPath1);
                FileInfo fileInfo2 = new FileInfo(inputPath2);

                // Create the archive and add entries using FileInfo
                using (Archive archive = new Archive())
                {
                    archive.CreateEntry("input1.txt", fileInfo1);
                    archive.CreateEntry("input2.txt", fileInfo2);

                    // Save the archive with ASCII encoding
                    archive.Save(zipFile, new ArchiveSaveOptions() { Encoding = Encoding.ASCII });
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
 * 1. When you need to programmatically bundle several text logs into a single ZIP file for easy transfer or backup using Aspose.Zip in a .NET application.
 * 2. When an automated build process must compress generated report files on the fly without loading them into memory, by passing FileInfo objects to a FileStream.
 * 3. When a Windows service has to archive user‑uploaded documents into a ZIP archive with a specific encoding before storing them in a secure location.
 * 4. When you want to create a ZIP archive from files located in different directories and ensure the archive is properly closed after writing to avoid file locks.
 * 5. When a cloud‑based C# service must compress files for download, using Aspose.Zip’s ArchiveSaveOptions to control the character encoding of entry names.
 */
