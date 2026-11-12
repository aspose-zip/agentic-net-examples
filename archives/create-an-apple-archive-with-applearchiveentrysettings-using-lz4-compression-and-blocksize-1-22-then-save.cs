// HOW-TO: Create ZIP Archives With BZIP2, LZMA, and PPMd Compression In C# (Aspose.ZIP for .NET)
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
            string inputFilePath = "C:\\Data\\input.txt";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // BZIP2 compression
            string outputBzip2 = "C:\\Output\\archive_bzip2.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputBzip2));
            using (FileStream outputStreamBzip2 = File.Open(outputBzip2, FileMode.Create))
            {
                using (Archive archiveBzip2 = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
                {
                    archiveBzip2.CreateEntry("input.txt", inputFilePath);
                    archiveBzip2.Save(outputStreamBzip2);
                }
            }

            // LZMA compression
            string outputLzma = "C:\\Output\\archive_lzma.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputLzma));
            using (FileStream outputStreamLzma = File.Open(outputLzma, FileMode.Create))
            {
                using (Archive archiveLzma = new Archive(new ArchiveEntrySettings(new LzmaCompressionSettings())))
                {
                    archiveLzma.CreateEntry("input.txt", inputFilePath);
                    archiveLzma.Save(outputStreamLzma);
                }
            }

            // PPMd compression
            string outputPpmd = "C:\\Output\\archive_ppmd.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputPpmd));
            using (FileStream outputStreamPpmd = File.Open(outputPpmd, FileMode.Create))
            {
                using (Archive archivePpmd = new Archive(new ArchiveEntrySettings(new PPMdCompressionSettings())))
                {
                    archivePpmd.CreateEntry("input.txt", inputFilePath);
                    archivePpmd.Save(outputStreamPpmd);
                }
            }

            // Enhanced Deflate compression
            string outputEnhanced = "C:\\Output\\archive_enhanced_deflate.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputEnhanced));
            using (FileStream outputStreamEnhanced = File.Open(outputEnhanced, FileMode.Create))
            {
                using (Archive archiveEnhanced = new Archive(new ArchiveEntrySettings(new EnhancedDeflateCompressionSettings())))
                {
                    archiveEnhanced.CreateEntry("input.txt", inputFilePath);
                    archiveEnhanced.Save(outputStreamEnhanced);
                }
            }

            // Store (no compression)
            string outputStore = "C:\\Output\\archive_store.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputStore));
            using (FileStream outputStreamStore = File.Open(outputStore, FileMode.Create))
            {
                using (Archive archiveStore = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
                {
                    archiveStore.CreateEntry("input.txt", inputFilePath);
                    archiveStore.Save(outputStreamStore);
                }
            }

            // XZ compression
            string outputXz = "C:\\Output\\archive_xz.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputXz));
            using (FileStream outputStreamXz = File.Open(outputXz, FileMode.Create))
            {
                using (Archive archiveXz = new Archive(new ArchiveEntrySettings(new XzCompressionSettings())))
                {
                    archiveXz.CreateEntry("input.txt", inputFilePath);
                    archiveXz.Save(outputStreamXz);
                }
            }

            // Zstandard compression
            string outputZstandard = "C:\\Output\\archive_zstandard.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(outputZstandard));
            using (FileStream outputStreamZstandard = File.Open(outputZstandard, FileMode.Create))
            {
                using (Archive archiveZstandard = new Archive(new ArchiveEntrySettings(new ZstandardCompressionSettings())))
                {
                    archiveZstandard.CreateEntry("input.txt", inputFilePath);
                    archiveZstandard.Save(outputStreamZstandard);
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
 * 1. When you need to package log files into a single ZIP archive using BZIP2 compression to minimize storage space in a .NET application.
 * 2. When distributing large binary assets and want to use LZMA compression for a higher compression ratio while still allowing fast extraction with Aspose.Zip.
 * 3. When your software must generate archives compatible with legacy systems that support PPMd compression for efficient text data compression.
 * 4. When automating backup routines in C# and require creating separate ZIP files with different algorithms to compare performance and archive size.
 * 5. When integrating Aspose.Zip into a .NET service that creates on‑the‑fly compressed reports, letting you select the most suitable compression method for each file type.
 */
