// HOW-TO: Create and Compress CPIO Archive with LZIP, Then Extract in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;
using Aspose.Zip.Lzip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Paths
            string sourceDir = "Data/InputFiles";
            string cpioLzPath = "Data/Archive/archive.cpio.lz";
            string extractDir = "Data/Extracted";

            // Validate source directory
            if (!Directory.Exists(sourceDir))
            {
                Console.Error.WriteLine($"Directory not found: {sourceDir}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(cpioLzPath));
            Directory.CreateDirectory(extractDir);

            // Create CPIO archive, add entries, and save with LZMA compression
            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntries(sourceDir);
                archive.SaveLzipped(cpioLzPath);
            }

            // Validate the created LZIP file
            if (!File.Exists(cpioLzPath))
            {
                Console.Error.WriteLine($"File not found: {cpioLzPath}");
                return;
            }

            // Decompress the LZIP-wrapped CPIO archive
            using (LzipArchive lzip = new LzipArchive(cpioLzPath))
            {
                lzip.Extract(extractDir);
            }

            Console.WriteLine("CPIO archive created, compressed, and decompressed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle a directory of files into a CPIO archive and compress it with LZMA for efficient storage or transfer in a .NET application.
 * 2. When you must generate a single .cpio.lz file from multiple source files to meet legacy Unix packaging requirements from C# code.
 * 3. When your deployment pipeline requires creating a compressed CPIO archive, then later extracting its contents on Windows or Linux using Aspose.Zip.
 * 4. When you want to automate backup of configuration files by archiving them into a CPIO container and applying LZIP compression to reduce disk usage.
 * 5. When you need to validate that a generated LZIP‑wrapped CPIO archive can be successfully decompressed and its files restored programmatically.
 */
