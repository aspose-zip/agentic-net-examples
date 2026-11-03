// HOW-TO: Extract Encrypted RAR Files and Convert to 7z Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string rarFilePath = @"C:\Data\encrypted.rar";
            string rarPassword = "password123";
            string extractionDir = @"C:\Data\Extracted";
            string sevenZipPath = @"C:\Data\converted.7z";

            // Validate input RAR file
            if (!File.Exists(rarFilePath))
            {
                Console.Error.WriteLine($"File not found: {rarFilePath}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractionDir);

            // Extract encrypted entries from the RAR archive
            using (FileStream rarStream = File.OpenRead(rarFilePath))
            {
                using (RarArchive rarArchive = new RarArchive(rarStream, new RarArchiveLoadOptions() { DecryptionPassword = rarPassword }))
                {
                    rarArchive.ExtractToDirectory(extractionDir);
                }
            }

            // Ensure output directory for the 7z file exists
            Directory.CreateDirectory(Path.GetDirectoryName(sevenZipPath));

            // Create a new 7z archive and add extracted files
            using (SevenZipArchive sevenZip = new SevenZipArchive())
            {
                // Add all files from the extraction directory
                sevenZip.CreateEntries(extractionDir);
                // Save the 7z archive
                sevenZip.Save(sevenZipPath);
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
 * 1. When you need to programmatically decrypt a password‑protected RAR archive and repack its contents into a 7z file for downstream processing in a .NET application.
 * 2. When migrating legacy backup data stored in encrypted RAR files to a more efficient 7z format without manual extraction.
 * 3. When automating a workflow that extracts sensitive files from a secured RAR archive and stores them in a new 7z archive for secure archival or transmission.
 * 4. When building a C# service that consolidates files from multiple encrypted RAR archives into a single 7z package for cloud upload.
 * 5. When creating a scheduled task that converts encrypted RAR archives to 7z to reduce storage size and simplify future extraction using Aspose.Zip for .NET.
 */
