// HOW-TO: Extract 7z Archive and Convert to Zip in C# (Aspose.ZIP for .NET)
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
            string sevenZipPath = @"C:\Temp\source.7z";
            string extractDirectory = @"C:\Temp\Extracted";
            string zipOutputPath = @"C:\Temp\Converted.zip";

            // Validate input 7z archive
            if (!File.Exists(sevenZipPath))
            {
                Console.Error.WriteLine($"File not found: {sevenZipPath}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDirectory);

            // Extract all entries from the 7z archive
            using (SevenZipArchive sevenArchive = new SevenZipArchive(sevenZipPath))
            {
                sevenArchive.ExtractToDirectory(extractDirectory);
            }

            // Ensure output directory for ZIP exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipOutputPath));

            // Create ZIP archive from the extracted folder
            using (Archive zipArchive = new Archive())
            {
                DirectoryInfo sourceFolder = new DirectoryInfo(extractDirectory);
                zipArchive.CreateEntries(sourceFolder);
                using (FileStream zipStream = File.Open(zipOutputPath, FileMode.Create))
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
 * 1. When you need to unpack a 7z package received from a client and then re‑package its contents as a standard ZIP file for compatibility with Windows tools.
 * 2. When migrating legacy backup archives stored as 7z into ZIP format to integrate with a cloud storage service that only accepts ZIP uploads.
 * 3. When automating a build pipeline that extracts third‑party resources from a 7z bundle and creates a ZIP artifact for distribution to downstream developers.
 * 4. When providing end users a downloadable ZIP version of documentation that is originally delivered in a 7z archive to simplify extraction on non‑technical machines.
 * 5. When consolidating multiple extracted folders into a single compressed ZIP archive as part of a data‑archiving routine that starts with a 7z source file.
 */
