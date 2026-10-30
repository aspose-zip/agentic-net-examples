// HOW-TO: Create XZ Archive With CRC64 Compression For Large Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = "largefile.bin";
            string outputPath = "largefile.xz";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            XzCompressionSettings xzSettings = new XzCompressionSettings();

            using (FileStream outStream = File.Open(outputPath, FileMode.Create))
            using (Archive archive = new Archive(new ArchiveEntrySettings(xzSettings)))
            {
                archive.CreateEntry("largefile.bin", inputPath);
                archive.Save(outStream);
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
 * 1. When you need to back up a multi‑gigabyte binary log file and want a compact XZ archive with CRC64 verification to ensure data integrity during storage.
 * 2. When deploying a game asset bundle, you can compress the raw asset file into an XZ archive using C# so that the download size is minimized while the CRC64 checksum detects any corruption.
 * 3. When archiving scientific data sets, developers can create XZ archives with built‑in CRC64 checksums to guarantee reliable long‑term preservation and easy extraction later.
 * 4. When sending large configuration files over unreliable networks, you can compress them into an XZ file in .NET and rely on the CRC64 hash to confirm the file arrived unchanged.
 * 5. When implementing a custom backup utility for enterprise applications, you can use Aspose.Zip to generate XZ archives with CRC64 checksums, providing both high compression ratios and robust error detection.
 */
