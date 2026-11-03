// HOW-TO: Convert ZIP Archive With Nested Folders To 7z Skipping Empty Directories In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = @"C:\Data\input.zip";
            string output7zPath = @"C:\Data\output.7z";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath));

            using (Archive zipArchive = new Archive(inputZipPath))
            {
                using (SevenZipArchive sevenZipArchive = new SevenZipArchive())
                {
                    List<Stream> openedStreams = new List<Stream>();

                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        Stream entryStream = zipEntry.Open();
                        openedStreams.Add(entryStream);
                        sevenZipArchive.CreateEntry(zipEntry.Name, entryStream);
                    }

                    sevenZipArchive.Save(output7zPath);

                    foreach (Stream s in openedStreams)
                    {
                        s.Dispose();
                    }
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
 * 1. When you need to repackage a downloaded ZIP containing many subfolders into a smaller 7z file for faster distribution while ignoring empty folders.
 * 2. When an application must migrate legacy ZIP backups to 7z format to reduce storage costs without preserving empty directory structures.
 * 3. When a build pipeline compresses output artifacts stored in a ZIP into a 7z archive before uploading to cloud storage, skipping unnecessary empty directories.
 * 4. When a user interface allows end‑users to select a ZIP file and automatically creates a 7z version that excludes empty folders to keep the archive tidy.
 * 5. When a data‑archiving script processes ZIP logs that contain nested directories and converts them to 7z for long‑term retention, omitting empty folders to save space.
 */
