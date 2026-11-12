// HOW-TO: Convert Password Protected ZIP to 7z Archive in C# (Aspose.ZIP for .NET)
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
            string zipPath = @"C:\Data\protected.zip";
            string zipPassword = "password123";
            string extractFolder = @"C:\Data\Extracted";
            string sevenZipPath = @"C:\Data\converted.7z";

            // Verify input ZIP exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure extraction folder exists
            Directory.CreateDirectory(extractFolder);

            // Load password‑protected ZIP archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = zipPassword;

            using (Archive zipArchive = new Archive(zipPath, loadOptions))
            {
                // Extract all entries to the folder
                zipArchive.ExtractToDirectory(extractFolder);
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(sevenZipPath));

            // Create a new 7z archive from the extracted files
            using (SevenZipArchive sevenArchive = new SevenZipArchive())
            {
                sevenArchive.CreateEntries(extractFolder);
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
 * 1. When you need to extract files from a secured ZIP and re‑package them as a 7z archive for smaller size or compatibility with 7‑Zip tools.
 * 2. When migrating legacy backup data that is stored in password‑protected ZIP files to a modern 7z format using C# automation.
 * 3. When building a deployment pipeline that unpacks encrypted archives and creates a single 7z bundle to distribute to downstream services.
 * 4. When implementing a data‑archiving solution that reads protected ZIP uploads, extracts their contents, and stores them as 7z files on a server.
 * 5. When creating a scheduled job that converts multiple encrypted ZIP archives into 7z archives to consolidate storage and improve compression ratios.
 */
