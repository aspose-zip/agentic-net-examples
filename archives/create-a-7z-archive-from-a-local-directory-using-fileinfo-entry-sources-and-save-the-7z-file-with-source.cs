// HOW-TO: Create 7z Archive from Folder with FileInfo Preserving Timestamps in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory and output 7z file paths
            string inputDirectory = @"C:\Data\InputFolder";
            string outputArchivePath = @"C:\Data\Output\archive.7z";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Get all files from the input directory
            string[] filePaths = Directory.GetFiles(inputDirectory);

            // Create a new 7z archive
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                foreach (string filePath in filePaths)
                {
                    // Verify the file exists before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Create FileInfo for the source file
                    FileInfo fileInfo = new FileInfo(filePath);

                    // Use the file name as the entry name inside the archive
                    string entryName = Path.GetFileName(filePath);

                    // Add the file to the archive using FileInfo (preserves modification time)
                    archive.CreateEntry(entryName, fileInfo);
                }

                // Save the archive to the output path
                using (FileStream outputStream = File.Open(outputArchivePath, FileMode.Create))
                {
                    archive.Save(outputStream);
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
 * 1. When you need to back up a set of files into a 7z archive while keeping the original modification dates for version tracking.
 * 2. When you want to programmatically compress a directory into a 7z file for distribution to users who require high‑ratio compression.
 * 3. When an automated build process must package generated reports into a 7z archive and retain timestamps for audit logs.
 * 4. When a desktop application needs to archive user‑selected files into a single 7z file without losing file metadata.
 * 5. When a server‑side service creates periodic 7z snapshots of log files and must preserve the original timestamps for forensic analysis.
 */
