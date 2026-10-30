// HOW-TO: Create and Verify 7z Backup Archive from Folder in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDirectory = @"C:\BackupFiles";
            string archivePath = @"C:\Archives\backup.7z";
            string extractDirectory = @"C:\ExtractedBackup";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory for the archive exists
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            // Create a 7z archive from all files in the input directory
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings();
            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(inputDirectory);
                archive.Save(archivePath);
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

            // Extract the archive to the extraction directory
            using (SevenZipArchive archive = new SevenZipArchive(archivePath))
            {
                archive.ExtractToDirectory(extractDirectory);
            }

            // Verify that all files were restored correctly
            string[] originalFiles = Directory.GetFiles(inputDirectory, "*", SearchOption.AllDirectories);
            string[] extractedFiles = Directory.GetFiles(extractDirectory, "*", SearchOption.AllDirectories);

            if (originalFiles.Length != extractedFiles.Length)
            {
                Console.WriteLine("Verification failed: file count mismatch.");
                return;
            }

            bool allMatch = true;
            foreach (string originalFilePath in originalFiles)
            {
                string relativePath = Path.GetRelativePath(inputDirectory, originalFilePath);
                string extractedFilePath = Path.Combine(extractDirectory, relativePath);

                if (!File.Exists(extractedFilePath))
                {
                    Console.WriteLine($"Verification failed: missing file {relativePath}");
                    allMatch = false;
                    break;
                }

                FileInfo originalInfo = new FileInfo(originalFilePath);
                FileInfo extractedInfo = new FileInfo(extractedFilePath);

                if (originalInfo.Length != extractedInfo.Length)
                {
                    Console.WriteLine($"Verification failed: size mismatch for file {relativePath}");
                    allMatch = false;
                    break;
                }
            }

            Console.WriteLine(allMatch ? "Extraction verified successfully." : "Extraction verification failed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to compress a set of daily backup files into a single 7z archive for efficient storage and later restoration.
 * 2. When you want to programmatically create a 7z archive of a directory and ensure the archive can be extracted without data loss.
 * 3. When you must automate backup archiving in a C# application and validate that the extracted files match the original count.
 * 4. When you are building a deployment script that packages configuration files into a 7z file and checks integrity after extraction.
 * 5. When you require a simple way to archive logs, verify their completeness, and restore them to a different location using Aspose.Zip for .NET.
 */
