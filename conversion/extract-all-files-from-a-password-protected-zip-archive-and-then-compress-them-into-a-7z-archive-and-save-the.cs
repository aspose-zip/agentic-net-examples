// HOW-TO: Extract Password Protected ZIP and Convert to 7z in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string zipPath = "input.zip";
            string zipPassword = "password123";
            string extractDirectory = "extracted";
            string sevenZipPath = "output.7z";

            // Verify input ZIP exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

            // Load the password‑protected ZIP archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = zipPassword;
            using (Archive zipArchive = new Archive(zipPath, loadOptions))
            {
                // Extract all entries to the extraction directory
                zipArchive.ExtractToDirectory(extractDirectory);
            }

            // Ensure the output directory for the 7z file exists (if any)
            string sevenZipDir = Path.GetDirectoryName(sevenZipPath);
            if (!string.IsNullOrEmpty(sevenZipDir))
            {
                Directory.CreateDirectory(sevenZipDir);
            }

            // Create a new 7z archive and add all extracted files
            using (SevenZipArchive sevenArchive = new SevenZipArchive())
            {
                // Add all files from the extraction directory
                sevenArchive.CreateEntries(new DirectoryInfo(extractDirectory));

                // Save the 7z archive to the specified path
                sevenArchive.Save(sevenZipPath);
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
 * 1. When you need to read a secured ZIP file, extract its contents, and re‑archive them as a 7z file for better compression in a .NET application.
 * 2. When migrating legacy backup archives that are password‑protected ZIPs to a newer 7‑zip format without manual extraction.
 * 3. When automating a data pipeline that receives encrypted ZIP uploads and must store the data in a 7z archive for downstream processing.
 * 4. When building a desktop utility that unpacks protected ZIP packages and repackages them as 7z to reduce storage space.
 * 5. When integrating with a third‑party system that only accepts 7z files, requiring you to convert incoming password‑protected ZIPs on the fly.
 */
