// HOW-TO: Extract RAR to Folder and Convert to ZIP in C# (Aspose.ZIP for .NET)
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
            string extractDirectory = @"C:\Data\Extracted";
            string zipPath = @"C:\Data\converted.zip";

            // Validate input RAR file
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(extractDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            // Extract RAR archive to the specified directory
            using (FileStream rarStream = File.OpenRead(rarPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            {
                rarArchive.ExtractToDirectory(extractDirectory);
            }

            // Create a new ZIP archive containing the extracted directory
            using (Archive zipArchive = new Archive())
            {
                // Add all files and subfolders from the extracted directory
                zipArchive.CreateEntries(new DirectoryInfo(extractDirectory));

                // Save the ZIP archive to the output path
                zipArchive.Save(zipPath);
            }

            Console.WriteLine("RAR extraction and ZIP creation completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate legacy RAR backups to a universally supported ZIP format for easier distribution.
 * 2. When an automated build pipeline must unpack a received RAR package, re‑archive its contents as ZIP, and store the result on a server.
 * 3. When a desktop application allows users to upload RAR files but downstream tools only accept ZIP, requiring on‑the‑fly conversion.
 * 4. When you want to extract a RAR archive to a known folder and then create a compressed ZIP for archival or email attachment.
 * 5. When integrating with third‑party services that require ZIP uploads, you first extract the RAR contents locally before repackaging them.
 */
