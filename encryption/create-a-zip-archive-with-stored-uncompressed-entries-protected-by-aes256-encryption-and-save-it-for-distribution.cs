// HOW-TO: Create Uncompressed AES256 Encrypted ZIP Archive In C# (Aspose.ZIP for .NET)
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
            // Define input files and output ZIP path
            string inputPath1 = "C:\\Data\\file1.txt";
            string inputPath2 = "C:\\Data\\file2.txt";
            string outputPath = "C:\\Output\\archive.zip";

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

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create ZIP archive with stored entries and AES256 encryption
            using (FileStream zipStream = File.Open(outputPath, FileMode.Create))
            using (FileStream sourceStream1 = File.Open(inputPath1, FileMode.Open, FileAccess.Read))
            using (FileStream sourceStream2 = File.Open(inputPath2, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings(), new AesEcryptionSettings("StrongPassword123", EncryptionMethod.AES256))))
            {
                // Add entries without compression
                archive.CreateEntry(Path.GetFileName(inputPath1), sourceStream1);
                archive.CreateEntry(Path.GetFileName(inputPath2), sourceStream2);

                // Save the archive
                archive.Save(zipStream);
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
 * 1. When you need to distribute confidential text files without increasing their size, you can package them in an uncompressed ZIP protected by AES256 encryption using C#.
 * 2. When a deployment pipeline must bundle configuration files for secure transfer while preserving original file timestamps, this code creates a stored‑compression ZIP with strong encryption.
 * 3. When a desktop application offers users a “download all” feature for logs that must remain readable and unaltered, you can generate an AES‑256 encrypted ZIP with no compression in C#.
 * 4. When an automated backup script has to archive large binary assets quickly and keep them encrypted, using stored entries avoids the CPU cost of compression while still providing AES256 security.
 * 5. When a compliance‑driven system requires that exported reports be archived in a format that can be opened with standard ZIP tools yet remain encrypted, this C# example produces a compatible AES‑256 encrypted ZIP file.
 */
