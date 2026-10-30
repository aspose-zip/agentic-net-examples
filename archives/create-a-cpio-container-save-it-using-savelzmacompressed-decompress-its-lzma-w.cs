// HOW-TO: Create and Extract LZMA Compressed CPIO Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;
using Aspose.Zip.LZMA;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string dataDir = "data";
            string sourceFile = Path.Combine(dataDir, "sample.txt");
            string archivePath = Path.Combine(dataDir, "archive.cpio.lzma");
            string extractedFile = Path.Combine(dataDir, "extracted.txt");

            // Ensure data directory exists
            Directory.CreateDirectory(dataDir);

            // Create a sample file to be archived
            if (!File.Exists(sourceFile))
            {
                using (StreamWriter writer = new StreamWriter(sourceFile))
                {
                    writer.WriteLine("This is a sample text file for CPIO LZMA compression.");
                }
            }

            // Verify source file exists before creating entry
            if (!File.Exists(sourceFile))
            {
                Console.Error.WriteLine($"File not found: {sourceFile}");
                return;
            }

            // Create CPIO archive and add entry
            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntry("sample.txt", sourceFile);
                // Ensure output directory exists before saving
                Directory.CreateDirectory(Path.GetDirectoryName(archivePath));
                archive.SaveLZMACompressed(archivePath);
            }

            // Verify compressed archive exists before decompression
            if (!File.Exists(archivePath))
            {
                Console.Error.WriteLine($"File not found: {archivePath}");
                return;
            }

            // Decompress LZMA archive and extract the entry
            using (LzmaArchive lzmaArchive = new LzmaArchive(archivePath))
            {
                // Ensure output directory exists before extracting
                Directory.CreateDirectory(Path.GetDirectoryName(extractedFile));
                using (FileStream extractedStream = File.Create(extractedFile))
                {
                    lzmaArchive.Extract(extractedStream);
                }
            }

            Console.WriteLine($"Extraction completed: {extractedFile}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to package a text file into a CPIO archive and reduce its size with LZMA compression for efficient storage or transfer in a C# application.
 * 2. When you want to ensure a compressed CPIO archive can be reliably decompressed and its contents extracted on a Windows server using Aspose.Zip.
 * 3. When building a backup utility that archives configuration files into a single .cpio.lzma file before uploading to cloud storage.
 * 4. When integrating legacy Unix CPIO archives into a .NET workflow that requires modern LZMA compression for faster network transmission.
 * 5. When creating automated deployment scripts that compress application resources into a CPIO LZMA package and later extract them on target machines.
 */
