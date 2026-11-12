// HOW-TO: Extract LZIP Archive to File Stream and Move to Backup in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputArchivePath = @"C:\Data\sample.lz";
            string extractedFilePath = @"C:\Data\extracted.txt";
            string backupFilePath = @"C:\Backup\extracted_backup.txt";

            // Validate input archive
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(extractedFilePath));
            Directory.CreateDirectory(Path.GetDirectoryName(backupFilePath));

            // Extract the LZIP archive to a file stream
            using (LzipArchive archive = new LzipArchive(inputArchivePath))
            using (FileStream extractedStream = File.Create(extractedFilePath))
            {
                archive.Extract(extractedStream);
            }

            // Move the extracted file to backup location
            if (File.Exists(backupFilePath))
            {
                File.Delete(backupFilePath);
            }
            File.Move(extractedFilePath, backupFilePath);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to decompress a .lz file received from a Linux system and store the content temporarily before archiving it elsewhere.
 * 2. When an application processes log files compressed with LZIP and must extract them to a stream for further analysis, then move the result to a secure backup folder.
 * 3. When a scheduled job extracts configuration data from an LZIP archive and relocates the extracted file to a backup directory to preserve previous versions.
 * 4. When a data migration tool reads an LZIP‑compressed dataset, writes it to a local file stream, and then moves the file to a backup location to avoid data loss.
 * 5. When a Windows service extracts a single file from an LZIP package and needs to place the extracted file in a backup repository after confirming the original archive exists.
 */
