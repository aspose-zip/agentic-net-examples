// HOW-TO: Create ZIP Archives With Bzip2, LZMA, PPMd And Enhanced Deflate In C# (Aspose.ZIP for .NET)
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
            // Prepare sample input file
            string inputPath = "sample.txt";
            if (!File.Exists(inputPath))
            {
                File.WriteAllText(inputPath, "This is a sample file for compression settings demonstration.");
            }

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Bzip2 compression
            string bzip2Output = "bzip2_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(bzip2Output) ?? ".");
            using (Archive archive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
            {
                archive.CreateEntry("sample.txt", inputPath);
                archive.Save(bzip2Output);
            }

            // LZMA compression
            string lzmaOutput = "lzma_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(lzmaOutput) ?? ".");
            using (Archive archive = new Archive(new ArchiveEntrySettings(new LzmaCompressionSettings())))
            {
                archive.CreateEntry("sample.txt", inputPath);
                archive.Save(lzmaOutput);
            }

            // PPMd compression
            string ppmdOutput = "ppmd_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(ppmdOutput) ?? ".");
            using (Archive archive = new Archive(new ArchiveEntrySettings(new PPMdCompressionSettings())))
            {
                archive.CreateEntry("sample.txt", inputPath);
                archive.Save(ppmdOutput);
            }

            // Enhanced Deflate compression
            string enhancedDeflateOutput = "enhanced_deflate_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(enhancedDeflateOutput) ?? ".");
            using (Archive archive = new Archive(new ArchiveEntrySettings(new EnhancedDeflateCompressionSettings())))
            {
                archive.CreateEntry("sample.txt", inputPath);
                archive.Save(enhancedDeflateOutput);
            }

            // Store (no compression)
            string storeOutput = "store_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(storeOutput) ?? ".");
            using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
            {
                archive.CreateEntry("sample.txt", inputPath);
                archive.Save(storeOutput);
            }

            // XZ compression
            string xzOutput = "xz_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(xzOutput) ?? ".");
            using (Archive archive = new Archive(new ArchiveEntrySettings(new XzCompressionSettings())))
            {
                archive.CreateEntry("sample.txt", inputPath);
                archive.Save(xzOutput);
            }

            // Zstandard compression
            string zstdOutput = "zstandard_archive.zip";
            Directory.CreateDirectory(Path.GetDirectoryName(zstdOutput) ?? ".");
            using (Archive archive = new Archive(new ArchiveEntrySettings(new ZstandardCompressionSettings())))
            {
                archive.CreateEntry("sample.txt", inputPath);
                archive.Save(zstdOutput);
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
 * 1. When you need to generate a ZIP file that uses Bzip2 compression to achieve higher compression ratios for large log files in a C# application.
 * 2. When your .NET service must create LZMA‑compressed archives to reduce storage size for backup of configuration files.
 * 3. When you want to produce a ZIP archive with PPMd compression to optimize compression of repetitive text data before sending it over a network.
 * 4. When you require an enhanced Deflate‑based ZIP archive to balance compression speed and size for downloadable resources in a C# web API.
 * 5. When you need to programmatically create multiple ZIP archives with different compression algorithms in a single C# workflow to compare their performance and choose the best one for your deployment pipeline.
 */
