// HOW-TO: Extract LZIP Archive to File Stream and Backup in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\sample.lz";
            string extractedFilePath = @"C:\Data\extracted.txt";
            string backupDirectory = @"C:\Backup";
            string backupFilePath = Path.Combine(backupDirectory, "extracted.txt");

            // Validate input file
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(extractedFilePath));
            Directory.CreateDirectory(Path.GetDirectoryName(backupFilePath));

            // Decompress LZIP archive to a file stream
            using (LzipArchive archive = new LzipArchive(inputPath))
            {
                using (FileStream extracted = File.Create(extractedFilePath))
                {
                    archive.Extract(extracted);
                }
            }

            // Copy the extracted file to backup directory
            File.Copy(extractedFilePath, backupFilePath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to decompress a .lz file on a Windows server and store the result in a specific location before archiving it for disaster recovery.
 * 2. When an application processes log files delivered as LZIP archives and must extract them to a temporary file before moving them to a backup folder.
 * 3. When a scheduled job extracts configuration data from an LZIP package and copies the extracted file to a secure backup directory to preserve previous versions.
 * 4. When a data pipeline receives compressed sensor data in LZIP format, extracts the payload to a stream, and then backs it up to ensure no data loss.
 * 5. When you want to automate the extraction of a single file from an LZIP archive and immediately duplicate it to a backup location as part of a CI/CD deployment step.
 */
