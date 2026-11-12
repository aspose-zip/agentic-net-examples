// HOW-TO: Extract Specific Folder From RAR and Convert To ZIP In C# (Aspose.ZIP for .NET)
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
            string inputRarPath = @"C:\Data\sample.rar";
            string extractDir = @"C:\Data\ExtractedFolder";
            string targetFolderInRar = "FolderToExtract/"; // Folder inside the RAR to extract
            string outputZipPath = @"C:\Data\Converted.zip";

            // Validate input RAR file
            if (!File.Exists(inputRarPath))
            {
                Console.Error.WriteLine($"File not found: {inputRarPath}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract the specified folder from the RAR archive
            using (FileStream rarStream = File.OpenRead(inputRarPath))
            {
                using (RarArchive rarArchive = new RarArchive(rarStream))
                {
                    foreach (RarArchiveEntry entry in rarArchive.Entries)
                    {
                        if (entry.Name.StartsWith(targetFolderInRar, StringComparison.OrdinalIgnoreCase))
                        {
                            string relativePath = entry.Name.Substring(targetFolderInRar.Length);
                            string destinationPath = Path.Combine(extractDir, relativePath);

                            if (entry.IsDirectory)
                            {
                                Directory.CreateDirectory(destinationPath);
                            }
                            else
                            {
                                Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                                using (FileStream outStream = File.OpenWrite(destinationPath))
                                {
                                    entry.Extract(outStream);
                                }
                            }
                        }
                    }
                }
            }

            // Ensure output directory for ZIP exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Compress the extracted folder into a ZIP archive
            using (Archive zipArchive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(extractDir);
                zipArchive.CreateEntries(dirInfo);
                using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
                {
                    zipArchive.Save(zipStream);
                }
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to pull a particular subdirectory out of a downloaded RAR package and re‑package it as a ZIP for compatibility with systems that only accept ZIP files.
 * 2. When an automated build pipeline must extract configuration files stored in a RAR archive and deliver them as a ZIP to downstream deployment tools.
 * 3. When a desktop application allows users to select a folder inside a RAR backup and save it as a ZIP archive for easy sharing or cloud upload.
 * 4. When migrating legacy archives that were distributed as RAR files to a modern archive format without extracting the entire archive, focusing only on the required folder.
 * 5. When a data‑processing service needs to isolate a specific dataset inside a RAR archive, extract it, and then compress it into a ZIP for further analysis or storage.
 */
