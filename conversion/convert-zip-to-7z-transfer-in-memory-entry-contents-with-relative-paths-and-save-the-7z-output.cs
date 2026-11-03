// HOW-TO: Convert a ZIP Archive to 7z In-Memory Using Aspose.Zip for C# (Aspose.ZIP for .NET)
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
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath));

            List<MemoryStream> tempStreams = new List<MemoryStream>();

            using (Archive zipArchive = new Archive(inputZipPath))
            {
                using (SevenZipArchive sevenArchive = new SevenZipArchive())
                {
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        MemoryStream entryData = new MemoryStream();
                        using (Stream zipEntryStream = zipEntry.Open())
                        {
                            zipEntryStream.CopyTo(entryData);
                        }
                        entryData.Position = 0;
                        tempStreams.Add(entryData);

                        // Add entry to the 7z archive
                        sevenArchive.CreateEntry(zipEntry.Name, entryData);
                    }

                    sevenArchive.Save(output7zPath);
                }
            }

            foreach (MemoryStream ms in tempStreams)
            {
                ms.Dispose();
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
 * 1. When you need to repackage files from an existing ZIP into a 7z archive without writing intermediate files to disk.
 * 2. When you want to stream each entry from a ZIP into memory, preserve its relative path, and add it to a new 7z archive for faster processing.
 * 3. When a cloud service receives a ZIP upload and must deliver a 7z version to downstream systems while keeping memory usage low.
 * 4. When automating migration of legacy ZIP backups to 7z format to benefit from higher compression ratios in a .NET application.
 * 5. When integrating Aspose.Zip with SevenZip to convert archives on the fly during a CI/CD pipeline without temporary files.
 */
