// HOW-TO: Append Files from Folder to Existing 7z Archive with Timestamps in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input archive and source directory paths
            string archivePath = @"C:\Data\existing.7z";
            string sourceDirectory = @"C:\Data\AddFiles";

            // Verify that the existing archive file exists
            if (!File.Exists(archivePath))
            {
                Console.Error.WriteLine($"File not found: {archivePath}");
                return;
            }

            // Verify that the source directory exists
            if (!Directory.Exists(sourceDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDirectory}");
                return;
            }

            // Ensure the output directory exists (same as archive's directory)
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            // Open the existing 7z archive
            using (SevenZipArchive archive = new SevenZipArchive(archivePath))
            {
                // Add each file from the source directory, preserving timestamps via FileInfo
                foreach (string filePath in Directory.GetFiles(sourceDirectory))
                {
                    FileInfo fileInfo = new FileInfo(filePath);
                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, fileInfo);
                }

                // Save the updated archive
                archive.Save(archivePath);
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
 * 1. When you need to add new log files to a previously created 7z backup while keeping their original creation dates.
 * 2. When a deployment script must update an existing compressed package with the latest configuration files without recreating the whole archive.
 * 3. When an application archives daily reports into a single 7z file and must preserve each report’s timestamp for audit purposes.
 * 4. When a data‑migration tool needs to merge additional documents into an existing 7z archive while maintaining file metadata.
 * 5. When a backup utility wants to incrementally add files from a directory to an existing 7z archive without losing original timestamps.
 */
