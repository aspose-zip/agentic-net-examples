// HOW-TO: Create 7z Archive from Directory with LZMA FastBytes 128 in C# (Aspose.ZIP for .NET)
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

            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(new SevenZipLZMACompressionSettings());

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
 * 1. When you need to compress a large folder into a 7z file using LZMA for faster compression in a .NET application.
 * 2. When you want to automate backup of configuration files by creating a 7z archive with specific FastBytes settings in C#.
 * 3. When you are building a deployment package that must be stored as a 7z archive with optimized LZMA parameters.
 * 4. When you need to generate a portable archive of user‑generated content on a server before uploading it to cloud storage.
 * 5. When you are implementing a custom archiving tool that requires creating 7z files programmatically without using external utilities.
 */
