// HOW-TO: Convert RAR Archive To ZIP File In C# With Aspose.Zip (Aspose.ZIP for .NET)
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

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

            // Open RAR archive and extract its contents
            using (FileStream rarStream = File.OpenRead(rarPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            {
                rarArchive.ExtractToDirectory(extractDirectory);
            }

            // Ensure output directory for ZIP exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            // Create ZIP archive from extracted files
            DirectoryInfo sourceDir = new DirectoryInfo(extractDirectory);
            using (Archive zipArchive = new Archive())
            {
                zipArchive.CreateEntries(sourceDir);
                zipArchive.Save(zipPath);
            }

            Console.WriteLine("RAR extracted and converted to ZIP successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate legacy RAR backups to a more widely supported ZIP format for cross‑platform distribution.
 * 2. When an automated job must extract files from a RAR archive and re‑compress them into a ZIP to upload to a cloud storage service.
 * 3. When a desktop application has to unpack user‑provided RAR files and repack the contents as ZIP for further processing by other tools.
 * 4. When you want to convert archived project resources from RAR to ZIP to integrate with CI/CD pipelines that only accept ZIP packages.
 * 5. When a data‑archiving script must normalize mixed archive types by extracting RAR files and saving them as ZIP for consistent archival policies.
 */
