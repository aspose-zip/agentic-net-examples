// HOW-TO: Create 7z Archive From Directory With LZMA LiteralContextBits In C# (Aspose.ZIP for .NET)
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
            string outputArchivePath = @"C:\Data\output.7z";

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
 * 1. When you need to compress an entire folder into a 7z file using Aspose.Zip for .NET with custom LZMA settings for optimal compression.
 * 2. When you want to programmatically generate a backup of application data on Windows while controlling LZMA parameters such as LiteralContextBits.
 * 3. When an automated build pipeline must package output files into a 7z archive before uploading them to a remote storage server using C#.
 * 4. When a desktop utility requires creating a portable archive of user‑selected files with consistent LZMA compression behavior.
 * 5. When integrating file compression into a .NET service and you need explicit control over LZMA options for compliance or performance testing.
 */
