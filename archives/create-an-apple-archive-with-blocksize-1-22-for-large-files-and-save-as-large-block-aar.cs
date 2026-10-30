// HOW-TO: Create Bzip2, LZMA, and PPMd Zip Archives in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputFile = "sample.txt";
            if (!File.Exists(inputFile))
            {
                Console.Error.WriteLine($"File not found: {inputFile}");
                return;
            }

            // Bzip2 compression archive
            string bzip2Output = "bzip2_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(bzip2Output) ?? string.Empty);
            using (FileStream bzip2Stream = File.Open(bzip2Output, FileMode.Create))
            {
                using (Archive bzip2Archive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
                {
                    bzip2Archive.CreateEntry("sample.txt", inputFile);
                    bzip2Archive.Save(bzip2Stream);
                }
            }

            // LZMA compression archive
            string lzmaOutput = "lzma_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(lzmaOutput) ?? string.Empty);
            using (FileStream lzmaStream = File.Open(lzmaOutput, FileMode.Create))
            {
                using (Archive lzmaArchive = new Archive(new ArchiveEntrySettings(new LzmaCompressionSettings())))
                {
                    lzmaArchive.CreateEntry("sample.txt", inputFile);
                    lzmaArchive.Save(lzmaStream);
                }
            }

            // PPMd compression archive
            string ppmdOutput = "ppmd_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(ppmdOutput) ?? string.Empty);
            using (FileStream ppmdStream = File.Open(ppmdOutput, FileMode.Create))
            {
                using (Archive ppmdArchive = new Archive(new ArchiveEntrySettings(new PPMdCompressionSettings())))
                {
                    ppmdArchive.CreateEntry("sample.txt", inputFile);
                    ppmdArchive.Save(ppmdStream);
                }
            }

            // Enhanced Deflate compression archive
            string enhancedDeflateOutput = "enhanced_deflate_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(enhancedDeflateOutput) ?? string.Empty);
            using (FileStream edStream = File.Open(enhancedDeflateOutput, FileMode.Create))
            {
                using (Archive edArchive = new Archive(new ArchiveEntrySettings(new EnhancedDeflateCompressionSettings())))
                {
                    edArchive.CreateEntry("sample.txt", inputFile);
                    edArchive.Save(edStream);
                }
            }

            // Store (no compression) archive
            string storeOutput = "store_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(storeOutput) ?? string.Empty);
            using (FileStream storeStream = File.Open(storeOutput, FileMode.Create))
            {
                using (Archive storeArchive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
                {
                    storeArchive.CreateEntry("sample.txt", inputFile);
                    storeArchive.Save(storeStream);
                }
            }

            // XZ compression archive
            string xzOutput = "xz_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(xzOutput) ?? string.Empty);
            using (FileStream xzStream = File.Open(xzOutput, FileMode.Create))
            {
                using (Archive xzArchive = new Archive(new ArchiveEntrySettings(new XzCompressionSettings())))
                {
                    xzArchive.CreateEntry("sample.txt", inputFile);
                    xzArchive.Save(xzStream);
                }
            }

            // Zstandard compression archive
            string zstdOutput = "zstandard_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(zstdOutput) ?? string.Empty);
            using (FileStream zstdStream = File.Open(zstdOutput, FileMode.Create))
            {
                using (Archive zstdArchive = new Archive(new ArchiveEntrySettings(new ZstandardCompressionSettings())))
                {
                    zstdArchive.CreateEntry("sample.txt", inputFile);
                    zstdArchive.Save(zstdStream);
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
 * 1. When you need to package a text file into a ZIP archive using high‑compression Bzip2 for better storage efficiency in a .NET application.
 * 2. When you want to generate a ZIP file with LZMA compression to achieve maximum reduction for large data sets before uploading to cloud storage.
 * 3. When your software must support legacy extraction tools that rely on PPMd‑compressed ZIP archives for compatibility with certain enterprise systems.
 * 4. When you are building a backup utility in C# that creates separate ZIP archives with different algorithms to compare compression ratios and choose the best one.
 * 5. When you need to programmatically create compressed archives on the fly in a Windows service, ensuring each archive uses a specific compression method for regulatory or performance requirements.
 */
