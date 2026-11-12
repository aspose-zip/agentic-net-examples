// HOW-TO: Extract Multi‑Volume 7z Archive Using All Parts In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string mainArchivePath = @"C:\Archives\myarchive.7z";
            string outputDirectory = @"C:\Extracted";

            // Validate main archive file
            if (!File.Exists(mainArchivePath))
            {
                Console.Error.WriteLine($"File not found: {mainArchivePath}");
                return;
            }

            // Validate archive directory
            string archiveDirectory = Path.GetDirectoryName(mainArchivePath);
            if (!Directory.Exists(archiveDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {archiveDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Collect all volume files (including the main .7z file)
            string baseName = Path.GetFileNameWithoutExtension(mainArchivePath);
            string[] allParts = Directory.GetFiles(archiveDirectory, baseName + ".7z*")
                                         .OrderBy(f => f)
                                         .ToArray();

            // Open the multi‑volume 7z archive
            using (SevenZipArchive archive = new SevenZipArchive(allParts))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you receive a large backup split into .7z, .7z.001, .7z.002 files and need to programmatically reassemble and extract it in a .NET application.
 * 2. When an automated deployment pipeline must unpack a multi‑volume 7z package containing installation files on a Windows server.
 * 3. When a file‑sharing service stores large archives as split 7z volumes and your C# service must combine and extract them for user download.
 * 4. When you need to verify that every segment of a segmented 7z archive is present before extracting its contents in a desktop utility.
 * 5. When a data migration tool processes archived datasets compressed into multi‑part 7z files and must extract them to a target directory.
 */
