// HOW-TO: Create Solid 7z Archive with Header Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Saving;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceFolder = @"C:\Data\SourceFolder";
            string archivePath = Path.Combine(@"C:\Data", "output.7z");

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
 * 1. When you need to back up a large folder into a single 7z file with solid compression to minimize size and improve compression efficiency in a C# application.
 * 2. When deploying a set of configuration files and resources, you can package them into a solid 7z archive to reduce overhead and speed up transfer over the network.
 * 3. When archiving log files for long‑term storage, using solid mode and header compression ensures the archive occupies the least possible disk space.
 * 4. When creating a downloadable data bundle for end users, a solid 7z archive generated with Aspose.Zip provides fast extraction and smaller download size.
 * 5. When implementing a custom backup utility, you can use this code to compress directory contents into a solid 7z archive while preserving directory structure and minimizing archive metadata size.
 */
