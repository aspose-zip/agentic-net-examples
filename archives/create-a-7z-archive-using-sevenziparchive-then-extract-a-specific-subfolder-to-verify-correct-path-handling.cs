// HOW-TO: Create 7z Archive and Extract Specific Subfolder with Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string sourceFolder = @"C:\Temp\SourceFolder";
            string archivePath = @"C:\Temp\output.7z";
            string extractDestinationRoot = @"C:\Temp\ExtractedSubfolder";
            string subfolderInArchive = "SubFolder/"; // Path inside the archive to extract

            // Validate source folder
            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            // Ensure output directory for the archive exists
            string archiveDir = Path.GetDirectoryName(archivePath);
            if (!string.IsNullOrEmpty(archiveDir))
            {
                Directory.CreateDirectory(archiveDir);
            }

            // Create a 7z archive from the source folder
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                archive.CreateEntries(sourceFolder);
                archive.Save(archivePath);
            }

            // Open the created 7z archive for extraction
            using (SevenZipArchive archive = new SevenZipArchive(archivePath))
            {
                foreach (SevenZipArchiveEntry entry in archive.Entries)
                {
                    // Check if the entry belongs to the desired subfolder
                    if (entry.Name.StartsWith(subfolderInArchive, StringComparison.OrdinalIgnoreCase))
                    {
                        // Determine the relative path inside the subfolder
                        string relativePath = entry.Name.Substring(subfolderInArchive.Length);
                        string destinationPath = Path.Combine(extractDestinationRoot, relativePath);

                        // Ensure the destination directory exists
                        string destDir = Path.GetDirectoryName(destinationPath);
                        if (!string.IsNullOrEmpty(destDir))
                        {
                            Directory.CreateDirectory(destDir);
                        }

                        // Extract the entry to the destination file
                        using (FileStream outputStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                        {
                            entry.Extract(outputStream);
                        }
                    }
                }
            }

            Console.WriteLine("Archive created and subfolder extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package an entire directory into a 7z file and later retrieve only a particular subfolder without extracting the whole archive.
 * 2. When automating backup processes that require creating compressed 7z archives and selectively restoring specific project components.
 * 3. When building a deployment tool that bundles application files into a 7z archive and extracts only the configuration subdirectory on target machines.
 * 4. When implementing a file‑transfer workflow that sends a 7z archive and the receiver must extract just the needed assets from a nested folder.
 * 5. When testing path handling in archives by creating a 7z file and verifying that extraction of a designated subfolder preserves the correct directory structure.
 */
