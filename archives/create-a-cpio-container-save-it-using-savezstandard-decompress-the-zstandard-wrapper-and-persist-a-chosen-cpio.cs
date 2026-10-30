// HOW-TO: Extract a Zstandard Compressed CPIO Archive to a File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Zstandard;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string dataDir = "Data";
            string zstdFilePath = Path.Combine(dataDir, "archive.zst");
            string extractedFilePath = Path.Combine(dataDir, "extracted_sample.txt");

            if (!File.Exists(zstdFilePath))
            {
                Console.Error.WriteLine($"File not found: {zstdFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(extractedFilePath));

            using (ZstandardArchive archive = new ZstandardArchive(zstdFilePath))
            {
                using (FileStream output = File.Create(extractedFilePath))
                {
                    archive.Extract(output);
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
 * 1. When you need to decompress a .zst file that contains a CPIO archive and save its contents to a local file in a .NET application.
 * 2. When you are building a deployment tool that extracts configuration files packaged in a Zstandard‑compressed CPIO container on Windows.
 * 3. When you want to read data from a compressed backup archive without loading the entire archive into memory, using streaming extraction in C#.
 * 4. When you need to automate the processing of log files that are distributed as Zstandard‑wrapped CPIO archives and write each log to a separate file.
 * 5. When you are integrating third‑party software that delivers updates as .zst CPIO packages and must extract a specific entry for installation.
 */
