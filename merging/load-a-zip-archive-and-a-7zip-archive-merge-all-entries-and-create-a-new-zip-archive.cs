// HOW-TO: Merge ZIP and 7z Files into a Single ZIP Archive Using C# (Aspose.ZIP for .NET)
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
            string zipInputPath = @"C:\Data\input.zip";
            string sevenZipInputPath = @"C:\Data\input.7z";
            string outputPath = @"C:\Data\merged.zip";

            if (!File.Exists(zipInputPath))
            {
                Console.Error.WriteLine($"File not found: {zipInputPath}");
                return;
            }

            if (!File.Exists(sevenZipInputPath))
            {
                Console.Error.WriteLine($"File not found: {sevenZipInputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (Archive zipArchive = new Archive(zipInputPath))
            using (SevenZipArchive sevenArchive = new SevenZipArchive(sevenZipInputPath))
            using (Archive mergedArchive = new Archive())
            {
                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    using (Stream sourceStream = zipEntry.Open())
                    {
                        mergedArchive.CreateEntry(zipEntry.Name, sourceStream);
                    }
                }

                foreach (SevenZipArchiveEntry sevenEntry in sevenArchive.Entries)
                {
                    using (Stream sourceStream = sevenEntry.Open())
                    {
                        mergedArchive.CreateEntry(sevenEntry.Name, sourceStream);
                    }
                }

                mergedArchive.Save(outputPath);
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
 * 1. When you need to combine files from an existing .zip and a .7z archive into one .zip for easier distribution.
 * 2. When a deployment pipeline must gather resources packaged in different archive formats and produce a unified zip for downstream tools.
 * 3. When a backup solution stores data in both ZIP and 7‑Zip containers and you want to consolidate them into a single archive before uploading to cloud storage.
 * 4. When a user interface lets end‑users select multiple compressed packages (ZIP and 7z) and you need to merge their contents into one downloadable zip file.
 * 5. When automating document archiving requires merging legacy 7z archives with newer zip files while preserving original entry names.
 */
