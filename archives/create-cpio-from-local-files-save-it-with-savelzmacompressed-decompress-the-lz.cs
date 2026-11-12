// HOW-TO: Create LZMA Compressed CPIO Archive and Extract It in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Cpio;
using Aspose.Zip.LZMA;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define data directory and file names
            string dataDir = "C:\\Data\\";
            string inputFile1 = dataDir + "file1.txt";
            string inputFile2 = dataDir + "file2.txt";

            // Verify input files exist
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Create CPIO archive and add files
            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntry("file1.txt", inputFile1);
                archive.CreateEntry("file2.txt", inputFile2);

                // Save archive with LZMA compression
                string outputLzmaPath = dataDir + "archive.cpio.lzma";
                Directory.CreateDirectory(Path.GetDirectoryName(outputLzmaPath));
                archive.SaveLZMACompressed(outputLzmaPath);
            }

            // Decompress the LZMA-compressed CPIO archive
            string extractDir = dataDir + "extracted\\";
            Directory.CreateDirectory(extractDir);

            using (LzmaArchive lzmaArchive = new LzmaArchive(dataDir + "archive.cpio.lzma"))
            {
                lzmaArchive.ExtractToDirectory(extractDir);
            }

            Console.WriteLine("Extraction completed.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple log files into a single CPIO archive and compress it with LZMA to reduce storage space before transferring to a remote server.
 * 2. When a backup script must create a portable CPIO package of configuration files and later decompress it on a Linux system that only supports LZMA‑compressed archives.
 * 3. When an application needs to archive user‑generated documents, apply high‑ratio LZMA compression, and later extract them for processing or display.
 * 4. When you want to automate the creation of a compressed CPIO payload for embedding into firmware updates and verify extraction during the update process.
 * 5. When a DevOps pipeline requires packaging build artifacts into a CPIO archive, compressing it with LZMA for artifact storage, and then unpacking it in a subsequent stage.
 */
