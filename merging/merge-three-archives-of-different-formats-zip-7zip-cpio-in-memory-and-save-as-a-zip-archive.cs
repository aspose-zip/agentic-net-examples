// HOW-TO: Merge ZIP, 7z, and CPIO Archives into a Single ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string zipInputPath = "input.zip";
            string sevenInputPath = "input.7z";
            string cpioInputPath = "input.cpio";
            string outputPath = "merged.zip";

            // Validate input files exist
            if (!File.Exists(zipInputPath))
            {
                Console.Error.WriteLine($"File not found: {zipInputPath}");
                return;
            }
            if (!File.Exists(sevenInputPath))
            {
                Console.Error.WriteLine($"File not found: {sevenInputPath}");
                return;
            }
            if (!File.Exists(cpioInputPath))
            {
                Console.Error.WriteLine($"File not found: {cpioInputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open source archives and create the destination ZIP archive
            using (Archive zipArchive = new Archive(zipInputPath))
            using (SevenZipArchive sevenArchive = new SevenZipArchive(sevenInputPath))
            using (CpioArchive cpioArchive = new CpioArchive(cpioInputPath))
            using (Archive outputArchive = new Archive())
            {
                // Copy entries from ZIP archive
                foreach (ArchiveEntry entry in zipArchive.Entries)
                {
                    using (Stream sourceStream = entry.Open())
                    using (MemoryStream tempStream = new MemoryStream())
                    {
                        sourceStream.CopyTo(tempStream);
                        tempStream.Position = 0;
                        outputArchive.CreateEntry(entry.Name, tempStream);
                    }
                }

                // Copy entries from 7z archive
                foreach (SevenZipArchiveEntry entry in sevenArchive.Entries)
                {
                    using (Stream sourceStream = entry.Open())
                    using (MemoryStream tempStream = new MemoryStream())
                    {
                        sourceStream.CopyTo(tempStream);
                        tempStream.Position = 0;
                        outputArchive.CreateEntry(entry.Name, tempStream);
                    }
                }

                // Copy entries from CPIO archive
                foreach (CpioEntry entry in cpioArchive.Entries)
                {
                    using (Stream sourceStream = entry.Open())
                    using (MemoryStream tempStream = new MemoryStream())
                    {
                        sourceStream.CopyTo(tempStream);
                        tempStream.Position = 0;
                        outputArchive.CreateEntry(entry.Name, tempStream);
                    }
                }

                // Save the merged ZIP archive
                outputArchive.Save(outputPath);
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
 * 1. When a deployment pipeline needs to combine resources packaged as ZIP, 7z, and CPIO files into one distributable ZIP for easier delivery.
 * 2. When a backup utility must consolidate archives created by different operating systems into a single ZIP archive for long‑term storage.
 * 3. When a data migration script has to merge legacy CPIO archives with newer ZIP and 7‑Zip bundles before uploading to cloud storage.
 * 4. When an application needs to programmatically read multiple archive formats in memory and produce a unified ZIP for client download without creating temporary files on disk.
 * 5. When a forensic tool must combine evidence files stored in various archive types into a single ZIP to preserve chain‑of‑custody and simplify analysis.
 */
