// HOW-TO: Extract Specific Folder From RAR And Create ZIP In C# (Aspose.ZIP for .NET)
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
            string rarPath = @"C:\Data\sample.rar";
            string extractFolder = @"C:\Data\ExtractedFolder";
            string zipPath = @"C:\Data\converted.zip";

            // Validate input RAR file
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));
            Directory.CreateDirectory(extractFolder);

            // Folder inside the RAR to extract (use forward slashes)
            string folderInRar = "TargetFolder/";

            using (FileStream rarStream = File.OpenRead(rarPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            {
                foreach (RarArchiveEntry entry in rarArchive.Entries)
                {
                    if (entry.Name.StartsWith(folderInRar, StringComparison.OrdinalIgnoreCase))
                    {
                        string relativePath = entry.Name.Substring(folderInRar.Length);
                        string destinationPath = Path.Combine(extractFolder, relativePath);
                        string destinationDir = Path.GetDirectoryName(destinationPath);
                        if (!string.IsNullOrEmpty(destinationDir))
                        {
                            Directory.CreateDirectory(destinationDir);
                        }

                        using (FileStream outStream = File.OpenWrite(destinationPath))
                        {
                            entry.Extract(outStream);
                        }
                    }
                }
            }

            // Create ZIP archive containing the extracted folder
            using (Archive zipArchive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(extractFolder);
                zipArchive.CreateEntries(dirInfo);

                using (FileStream zipStream = File.Open(zipPath, FileMode.Create))
                {
                    zipArchive.Save(zipStream);
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
 * 1. When you need to pull only a particular directory out of a large RAR file and package it as a standalone ZIP for distribution.
 * 2. When automating a build pipeline that extracts configuration files from a RAR backup and stores them in a compressed ZIP for deployment.
 * 3. When migrating legacy RAR archives to modern ZIP format while preserving only the required subfolders.
 * 4. When creating a downloadable ZIP bundle that contains only the assets from a specific folder inside a RAR archive in a C# application.
 * 5. When implementing a file‑processing service that extracts a target folder from user‑uploaded RAR files and re‑compresses it into a ZIP for further processing.
 */
