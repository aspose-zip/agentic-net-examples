// HOW-TO: Extract RAR and Split Top-Level Folders into Separate ZIP Files in C# (Aspose.ZIP for .NET)
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
            string rarPath = @"C:\Data\archive.rar";
            string extractDir = @"C:\Data\Extracted";
            string zipOutputDir = @"C:\Data\ConvertedZips";

            // Validate input RAR file
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(extractDir);
            Directory.CreateDirectory(zipOutputDir);

            // Extract RAR archive to temporary folder
            using (FileStream rarStream = File.OpenRead(rarPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            {
                rarArchive.ExtractToDirectory(extractDir);
            }

            // Process each top‑level folder and create a separate ZIP archive
            DirectoryInfo extractedInfo = new DirectoryInfo(extractDir);
            DirectoryInfo[] topLevelFolders = extractedInfo.GetDirectories();

            foreach (DirectoryInfo folder in topLevelFolders)
            {
                string zipPath = Path.Combine(zipOutputDir, folder.Name + ".zip");

                // Ensure the directory for the ZIP file exists (already created above)
                Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

                using (FileStream zipStream = File.Open(zipPath, FileMode.Create))
                using (Archive zipArchive = new Archive())
                {
                    // Add all entries from the current top‑level folder
                    zipArchive.CreateEntries(folder);
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
 * 1. When you receive a large RAR archive containing multiple project directories and need each project packaged as its own ZIP for distribution.
 * 2. When an automated pipeline must convert legacy RAR backups into ZIP format while preserving the original folder hierarchy for downstream processing.
 * 3. When a cloud storage service requires individual ZIP files per top‑level folder to enforce storage quotas or access controls.
 * 4. When you want to extract a RAR file on a Windows server and immediately create separate ZIP archives for each department’s files for easier sharing.
 * 5. When a backup restoration script needs to unpack a RAR archive and re‑compress each top‑level folder into independent ZIP files for archival compliance.
 */
