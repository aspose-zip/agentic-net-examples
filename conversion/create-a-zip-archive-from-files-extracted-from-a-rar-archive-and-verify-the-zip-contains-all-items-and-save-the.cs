// HOW-TO: Convert RAR Archive to ZIP and Verify Contents in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string rarPath = @"C:\Data\sample.rar";
            string extractDirectory = @"C:\Data\ExtractedFromRar";
            string zipPath = @"C:\Data\converted.zip";

            // Validate input RAR file
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

            // Extract RAR archive
            using (FileStream rarStream = File.OpenRead(rarPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            {
                rarArchive.ExtractToDirectory(extractDirectory);
            }

            // Ensure output directory for ZIP exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            // Create ZIP archive from extracted files
            using (Archive zipArchive = new Archive())
            {
                zipArchive.CreateEntries(new DirectoryInfo(extractDirectory));
                zipArchive.Save(zipPath);
            }

            // Verify ZIP contains all extracted items
            int extractedFileCount = Directory.GetFiles(extractDirectory, "*", SearchOption.AllDirectories).Length;
            using (Archive zipToVerify = new Archive(zipPath))
            {
                int zipEntryCount = zipToVerify.Entries.Count;
                Console.WriteLine($"Extracted files: {extractedFileCount}");
                Console.WriteLine($"ZIP entries: {zipEntryCount}");
                if (extractedFileCount == zipEntryCount)
                {
                    Console.WriteLine("Verification succeeded: all items are present in the ZIP archive.");
                }
                else
                {
                    Console.WriteLine("Verification failed: mismatch between extracted files and ZIP entries.");
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
 * 1. When you need to replace legacy RAR files with ZIP files for compatibility with Windows Explorer or other tools.
 * 2. When an automated build pipeline must extract RAR packages, re‑package them as ZIP, and confirm that no files were lost during conversion.
 * 3. When a cloud service only accepts ZIP uploads, so you convert user‑provided RAR archives to ZIP before sending them.
 * 4. When you want to archive extracted data into a single ZIP file while ensuring the entry count matches the original extraction.
 * 5. When you are building a backup utility that normalizes different archive formats into ZIP and validates the conversion for data integrity.
 */
