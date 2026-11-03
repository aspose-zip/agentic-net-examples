// HOW-TO: Extract RAR Archive And Convert To ZIP In C# (Aspose.ZIP for .NET)
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
            string extractDirectory = @"C:\Data\Extracted";
            string outputZipPath = @"C:\Data\converted.zip";

            // Validate input RAR file
            if (!File.Exists(inputRarPath))
            {
                Console.Error.WriteLine($"File not found: {inputRarPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));
            Directory.CreateDirectory(extractDirectory);

            // Extract RAR archive to the specified directory
            using (FileStream rarStream = File.OpenRead(inputRarPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            {
                rarArchive.ExtractToDirectory(extractDirectory);
            }

            // Create a new ZIP archive from the extracted files
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            using (Archive zipArchive = new Archive())
            {
                // Add all files and subfolders from the extraction directory
                zipArchive.CreateEntries(new DirectoryInfo(extractDirectory));
                zipArchive.Save(zipStream);
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
 * 1. When you need to unpack a downloaded RAR package and re‑archive its contents as a ZIP file for compatibility with Windows Explorer.
 * 2. When a migration script must convert legacy RAR backups into ZIP archives before uploading them to a cloud storage service.
 * 3. When an automated build process extracts third‑party RAR libraries and bundles them into a single ZIP for distribution with your application.
 * 4. When a data‑processing pipeline receives RAR‑compressed logs and you must extract and recompress them as ZIP for downstream analytics tools.
 * 5. When you want to provide users a ZIP version of a RAR‑based document collection without requiring them to install RAR extraction software.
 */
