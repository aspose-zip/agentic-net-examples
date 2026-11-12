// HOW-TO: Create 7z Archive from Folder Using LZMA Compression in C# (Aspose.ZIP for .NET)
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
            string inputDirectory = @"C:\Data\SourceFolder";
            string outputArchivePath = @"C:\Data\Archive\output.7z";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            SevenZipLZMACompressionSettings lzmaSettings = new SevenZipLZMACompressionSettings();

            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(lzmaSettings);

            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(inputDirectory);

                using (FileStream outStream = File.Open(outputArchivePath, FileMode.Create))
                {
                    archive.Save(outStream);
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
 * 1. When you need to back up a project's source files into a highly compressed 7z file for storage or transfer.
 * 2. When you want to package log files from a server directory into a single archive before uploading to cloud storage.
 * 3. When you are preparing a software release bundle that must meet size constraints by using LZMA compression in C#.
 * 4. When you automate the creation of archives for nightly data snapshots in a Windows service using Aspose.Zip.
 * 5. When you integrate archive generation into a CI/CD pipeline to compress build artifacts for faster artifact distribution.
 */
