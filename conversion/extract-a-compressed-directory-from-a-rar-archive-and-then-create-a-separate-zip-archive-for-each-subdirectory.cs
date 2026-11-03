// HOW-TO: Extract RAR Archive and Create Separate ZIP Files for Subfolders in C# (Aspose.ZIP for .NET)
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
            string extractDirectory = @"C:\Data\Extracted";
            string zipOutputRoot = @"C:\Data\Zips";

            // Validate input RAR file
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

            // Extract RAR archive
            using (FileStream rarStream = File.OpenRead(rarPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            {
                rarArchive.ExtractToDirectory(extractDirectory);
            }

            // Process each subdirectory and create a ZIP archive
            string[] subdirectories = Directory.GetDirectories(extractDirectory);
            foreach (string subdirPath in subdirectories)
            {
                string subdirName = Path.GetFileName(subdirPath);
                string zipPath = Path.Combine(zipOutputRoot, subdirName + ".zip");

                // Ensure output directory for ZIP exists
                Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

                // Create ZIP archive from the subdirectory
                using (Archive zipArchive = new Archive())
                {
                    DirectoryInfo dirInfo = new DirectoryInfo(subdirPath);
                    zipArchive.CreateEntries(dirInfo);

                    using (FileStream zipStream = File.Open(zipPath, FileMode.Create))
                    {
                        zipArchive.Save(zipStream);
                    }
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
 * 1. When you need to unpack a downloaded RAR package and distribute each top‑level folder as its own ZIP for downstream processing.
 * 2. When an automated pipeline must convert legacy RAR backups into modern ZIP archives, preserving each project directory separately.
 * 3. When a web service receives a RAR upload and must generate individual ZIP files for each subdirectory to send to different clients.
 * 4. When you want to extract a multi‑folder RAR archive on a server and archive each folder individually to reduce storage size and improve compatibility.
 * 5. When a build script has to split a large RAR containing multiple modules into separate ZIP bundles for version control or deployment.
 */
