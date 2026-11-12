// HOW-TO: Create 7z Archive With BZip2 Compression Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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
            string dataDir = @"C:\Data\Files";

            if (!Directory.Exists(dataDir))
            {
                Console.Error.WriteLine($"Directory not found: {dataDir}");
                return;
            }

            // LZMA2 compression
            string outputLzma2 = @"C:\Output\archive_lzma2.7z";
            Directory.CreateDirectory(Path.GetDirectoryName(outputLzma2));
            using (SevenZipArchive archiveLzma2 = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings())))
            {
                archiveLzma2.CreateEntries(dataDir);
                archiveLzma2.Save(outputLzma2);
            }

            // LZMA compression
            string outputLzma = @"C:\Output\archive_lzma.7z";
            Directory.CreateDirectory(Path.GetDirectoryName(outputLzma));
            using (SevenZipArchive archiveLzma = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipLZMACompressionSettings())))
            {
                archiveLzma.CreateEntries(dataDir);
                archiveLzma.Save(outputLzma);
            }

            // BZip2 compression
            string outputBzip2 = @"C:\Output\archive_bzip2.7z";
            Directory.CreateDirectory(Path.GetDirectoryName(outputBzip2));
            using (SevenZipArchive archiveBzip2 = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipBZip2CompressionSettings())))
            {
                archiveBzip2.CreateEntries(dataDir);
                archiveBzip2.Save(outputBzip2);
            }

            // PPMd compression
            string outputPpmd = @"C:\Output\archive_ppmd.7z";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPpmd));
            using (SevenZipArchive archivePpmd = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipPPMdCompressionSettings())))
            {
                archivePpmd.CreateEntries(dataDir);
                archivePpmd.Save(outputPpmd);
            }

            // Store (no compression)
            string outputStore = @"C:\Output\archive_store.7z";
            Directory.CreateDirectory(Path.GetDirectoryName(outputStore));
            using (SevenZipArchive archiveStore = new SevenZipArchive(new SevenZipEntrySettings(new SevenZipStoreCompressionSettings())))
            {
                archiveStore.CreateEntries(dataDir);
                archiveStore.Save(outputStore);
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
 * 1. When you need to package a folder of log files into a single 7z file with BZip2 compression for efficient storage or transfer in a C# application.
 * 2. When you want to generate a BZip2‑compressed 7z backup of configuration files before uploading them to a cloud backup service using Aspose.Zip.
 * 3. When a deployment script must create a lightweight 7z archive of source code directories with BZip2 to reduce bandwidth usage during CI/CD pipelines.
 * 4. When an enterprise application requires creating 7z archives and you choose BZip2 for a balance of speed and compression ratio with Aspose.Zip for .NET.
 * 5. When you are building a file‑archiving utility that lets users select a directory and saves it locally as a BZip2‑compressed 7z archive using C#.
 */
