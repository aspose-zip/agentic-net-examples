// HOW-TO: Create 7z Archive from Folder Preserving File Timestamps in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory and output archive paths
            string inputDirectory = @"C:\Data\InputFolder";
            string outputArchivePath = @"C:\Data\Output\archive.7z";

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Get all files from the input directory (including subdirectories)
            string[] filePaths = Directory.GetFiles(inputDirectory, "*", SearchOption.AllDirectories);

            using (FileStream outputStream = File.Open(outputArchivePath, FileMode.Create))
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                foreach (string filePath in filePaths)
                {
                    // Verify each file exists before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Use FileInfo to preserve timestamps
                    FileInfo fileInfo = new FileInfo(filePath);

                    // Preserve directory structure inside the archive
                    string entryName = Path.GetRelativePath(inputDirectory, filePath);

                    // Add the entry with its FileInfo
                    archive.CreateEntry(entryName, fileInfo);
                }

                // Save the 7z archive
                archive.Save(outputStream);
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
 * 1. When you need to back up a project directory into a 7z file while keeping original creation and modification dates for later restoration.
 * 2. When deploying software updates and you must package files with their timestamps intact so deployment tools can detect newer versions.
 * 3. When archiving log files for compliance and you want the timestamps preserved to satisfy audit requirements.
 * 4. When creating a portable data bundle for a client and you need the directory structure and file dates to remain unchanged after extraction.
 * 5. When automating nightly backups in a .NET application and you require a 7z archive that retains file timestamps for accurate incremental restores.
 */
