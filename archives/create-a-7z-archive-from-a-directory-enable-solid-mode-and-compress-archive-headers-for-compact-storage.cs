// HOW-TO: Create Solid 7z Archive With Header Compression In C# (Aspose.ZIP for .NET)
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
            string sourceFolder = @"C:\Data\SourceFolder";
            string archivePath = Path.Combine(@"C:\Data", "archive.7z");

            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();

            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings, null)
            {
                Solid = true
            };

            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(sourceFolder);
                archive.Save(archivePath);
            }

            Console.WriteLine($"Solid 7z archive created at: {archivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a large collection of log files into a single 7z file that uses solid compression to achieve maximum size reduction.
 * 2. When you want to distribute software updates as a compact 7z archive while minimizing overhead by compressing the archive headers.
 * 3. When you are backing up configuration directories and require a single archive that can be quickly created in C# with Aspose.Zip and supports solid mode for better compression ratios.
 * 4. When you need to generate a 7z archive on the fly in a web service and want to reduce network payload by compressing both file data and archive metadata.
 * 5. When you are archiving source code repositories and want the archive to be small enough for email attachment, using Aspose.Zip’s solid mode and header compression in a .NET application.
 */
