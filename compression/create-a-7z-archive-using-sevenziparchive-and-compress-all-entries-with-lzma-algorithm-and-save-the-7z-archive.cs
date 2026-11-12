// HOW-TO: Create a 7z Archive with LZMA Compression in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory containing files to archive
            string inputDirectory = @"C:\Data\Input";
            // Hardcoded output 7z archive path
            string outputArchivePath = @"C:\Data\Output\archive.7z";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Create a 7z archive with LZMA compression for all entries
            using (SevenZipArchive archive = new SevenZipArchive(
                new SevenZipEntrySettings(new SevenZipLZMACompressionSettings())))
            {
                // Add all files from the input directory
                archive.CreateEntries(inputDirectory);
                // Save the archive to the specified path
                archive.Save(outputArchivePath);
            }

            Console.WriteLine($"7z archive created successfully at: {outputArchivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple files into a single 7z file with high compression for backup or distribution in a .NET application.
 * 2. When you want to programmatically generate LZMA‑compressed archives from a folder to reduce storage size before uploading to cloud storage.
 * 3. When you are building a deployment tool that must create portable 7z packages of configuration files on Windows using C#.
 * 4. When you have to automate archiving of log files daily, creating a compressed 7z archive to keep the logs organized and space‑efficient.
 * 5. When you need to integrate Aspose.Zip’s SevenZipArchive into a service that prepares data archives for users to download with LZMA compression.
 */
