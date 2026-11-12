// HOW-TO: Create 7z Archive from Folder with 512 MB LZMA Dictionary in C# (Aspose.ZIP for .NET)
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
            string inputDirectory = @"C:\Data\InputFolder";
            string outputArchivePath = @"C:\Data\Output\archive.7z";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            SevenZipLZMACompressionSettings lzmaSettings = new SevenZipLZMACompressionSettings();
            lzmaSettings.DictionarySize = 512 * 1024 * 1024;

            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(lzmaSettings);

            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(inputDirectory);
                archive.Save(outputArchivePath);
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
 * 1. When you need to back up a large set of log files and want maximum compression efficiency by using a 512 MB LZMA dictionary in a 7z archive.
 * 2. When you must package a software release folder for distribution and want to ensure the archive uses Aspose.Zip’s 7z format with a custom dictionary size for faster decompression.
 * 3. When transferring multi‑gigabyte datasets over limited bandwidth and want to reduce size by creating a high‑ratio 7z archive with a large LZMA dictionary in C#.
 * 4. When automating nightly backups of a directory on a Windows server and need to generate a 7z file programmatically with specific compression settings using Aspose.Zip.
 * 5. When integrating archival functionality into a .NET application that must comply with corporate policies requiring 7z format and configurable LZMA parameters such as a 512 MB dictionary.
 */
