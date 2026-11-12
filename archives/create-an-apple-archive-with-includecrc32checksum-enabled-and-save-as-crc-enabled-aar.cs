// HOW-TO: Create Apple Archive with CRC32 Checksum Enabled Using C# (Aspose.ZIP for .NET)
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
            string inputFilePath = "data/input.txt";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Bzip2 compression
            string bzip2Output = "output/bzip2.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(bzip2Output));
            using (Archive bzip2Archive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
            {
                bzip2Archive.CreateEntry("input.txt", inputFilePath);
                using (FileStream bzip2Stream = File.Open(bzip2Output, FileMode.Create))
                {
                    bzip2Archive.Save(bzip2Stream);
                }
            }

            // LZMA compression
            string lzmaOutput = "output/lzma.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(lzmaOutput));
            using (Archive lzmaArchive = new Archive(new ArchiveEntrySettings(new LzmaCompressionSettings())))
            {
                lzmaArchive.CreateEntry("input.txt", inputFilePath);
                using (FileStream lzmaStream = File.Open(lzmaOutput, FileMode.Create))
                {
                    lzmaArchive.Save(lzmaStream);
                }
            }

            // PPMd compression
            string ppmdOutput = "output/ppmd.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(ppmdOutput));
            using (Archive ppmdArchive = new Archive(new ArchiveEntrySettings(new PPMdCompressionSettings())))
            {
                ppmdArchive.CreateEntry("input.txt", inputFilePath);
                using (FileStream ppmdStream = File.Open(ppmdOutput, FileMode.Create))
                {
                    ppmdArchive.Save(ppmdStream);
                }
            }

            // Enhanced Deflate compression
            string enhancedDeflateOutput = "output/enhanced_deflate.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(enhancedDeflateOutput));
            using (Archive enhancedDeflateArchive = new Archive(new ArchiveEntrySettings(new EnhancedDeflateCompressionSettings())))
            {
                enhancedDeflateArchive.CreateEntry("input.txt", inputFilePath);
                using (FileStream enhancedDeflateStream = File.Open(enhancedDeflateOutput, FileMode.Create))
                {
                    enhancedDeflateArchive.Save(enhancedDeflateStream);
                }
            }

            // Store (no compression)
            string storeOutput = "output/store.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(storeOutput));
            using (Archive storeArchive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
            {
                storeArchive.CreateEntry("input.txt", inputFilePath);
                using (FileStream storeStream = File.Open(storeOutput, FileMode.Create))
                {
                    storeArchive.Save(storeStream);
                }
            }

            // XZ compression
            string xzOutput = "output/xz.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(xzOutput));
            using (Archive xzArchive = new Archive(new ArchiveEntrySettings(new XzCompressionSettings())))
            {
                xzArchive.CreateEntry("input.txt", inputFilePath);
                using (FileStream xzStream = File.Open(xzOutput, FileMode.Create))
                {
                    xzArchive.Save(xzStream);
                }
            }

            // Zstandard compression
            string zstandardOutput = "output/zstandard.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(zstandardOutput));
            using (Archive zstandardArchive = new Archive(new ArchiveEntrySettings(new ZstandardCompressionSettings())))
            {
                zstandardArchive.CreateEntry("input.txt", inputFilePath);
                using (FileStream zstandardStream = File.Open(zstandardOutput, FileMode.Create))
                {
                    zstandardArchive.Save(zstandardStream);
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
 * 1. When you need to generate an Apple Archive (.aar) with CRC32 checksums enabled to verify file integrity after distribution.
 * 2. When you want to compress a text file using Bzip2 inside a ZIP archive to minimize upload bandwidth in a C# service.
 * 3. When you require LZMA compression for a backup archive to achieve maximum size reduction while preserving data for later extraction.
 * 4. When you are evaluating PPMd compression for highly repetitive log files to determine the best trade‑off between speed and compression ratio.
 * 5. When you automate the creation of multiple archives with different algorithms in a build script, ensuring each output directory is created and the archives are saved correctly.
 */
