// HOW-TO: Create and Extract a 7z Archive with LZMA2 Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputFolder = @"C:\Scripts";
            string archivePath = @"C:\Output\scripts.7z";
            string extractFolder = @"C:\ExtractedScripts";

            // Validate input folder
            if (!Directory.Exists(inputFolder))
            {
                Console.Error.WriteLine($"Directory not found: {inputFolder}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            // Create a 7z archive with LZMA2 compression
            using (SevenZipArchive archive = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings())))
            {
                archive.CreateEntries(inputFolder);
                archive.Save(archivePath);
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractFolder);

            // Extract the archive to the target directory
            using (SevenZipArchive archive = new SevenZipArchive(archivePath))
            {
                archive.ExtractToDirectory(extractFolder);
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
 * 1. When you need to bundle a collection of script files into a single 7z archive for easier distribution or backup.
 * 2. When you want to compress a folder using high‑ratio LZMA2 compression before sending it over a network.
 * 3. When you must automate the extraction of a previously created 7z package to a specific deployment directory.
 * 4. When you are building a build‑pipeline step that archives generated scripts and then restores them on another machine.
 * 5. When you need to validate that a folder exists, create the archive, and safely extract its contents in a .NET application.
 */
