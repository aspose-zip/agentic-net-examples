// HOW-TO: Create 7z Archive From Folder With LZMA, LZMA2, BZip2 In C# (Aspose.ZIP for .NET)
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

            string outputLzma2 = @"C:\Data\Archive\output_lzma2.7z";
            string outputLzma = @"C:\Data\Archive\output_lzma.7z";
            string outputBzip2 = @"C:\Data\Archive\output_bzip2.7z";
            string outputPpmd = @"C:\Data\Archive\output_ppmd.7z";
            string outputStore = @"C:\Data\Archive\output_store.7z";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputLzma2));
            Directory.CreateDirectory(Path.GetDirectoryName(outputLzma));
            Directory.CreateDirectory(Path.GetDirectoryName(outputBzip2));
            Directory.CreateDirectory(Path.GetDirectoryName(outputPpmd));
            Directory.CreateDirectory(Path.GetDirectoryName(outputStore));

            using (SevenZipArchive archive = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings())))
            {
                archive.CreateEntries(inputDirectory);
                archive.Save(outputLzma2);
            }

            using (SevenZipArchive archive = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipLZMACompressionSettings())))
            {
                archive.CreateEntries(inputDirectory);
                archive.Save(outputLzma);
            }

            using (SevenZipArchive archive = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipBZip2CompressionSettings())))
            {
                archive.CreateEntries(inputDirectory);
                archive.Save(outputBzip2);
            }

            using (SevenZipArchive archive = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipPPMdCompressionSettings())))
            {
                archive.CreateEntries(inputDirectory);
                archive.Save(outputPpmd);
            }

            using (SevenZipArchive archive = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipStoreCompressionSettings())))
            {
                archive.CreateEntries(inputDirectory);
                archive.Save(outputStore);
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
 * 1. When you need to package a project's output files into a single 7z file for easy distribution or backup using C#.
 * 2. When you want to generate separate 7z archives with different compression algorithms (LZMA, LZMA2, BZip2, PPMd, Store) to compare size and speed for large data sets.
 * 3. When an automated build pipeline must create compressed archives of log files or reports on a Windows server using Aspose.Zip for .NET.
 * 4. When a desktop application needs to let users select a folder and produce a 7z archive with custom compression settings without relying on external tools.
 * 5. When you are implementing a data archiving service that stores incoming files in a structured directory and saves them as 7z archives for long‑term retention.
 */
