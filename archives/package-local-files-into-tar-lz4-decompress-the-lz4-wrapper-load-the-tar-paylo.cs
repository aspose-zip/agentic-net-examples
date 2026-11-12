// HOW-TO: Create and Extract TAR LZ4 Archive from Local Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Base directory containing input files and where output will be placed
            string dataDir = "C:\\Data\\";
            
            // Input files to be archived
            string inputFile1 = Path.Combine(dataDir, "file1.txt");
            string inputFile2 = Path.Combine(dataDir, "file2.txt");
            
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
            
            // Path for the compressed TAR.LZ4 archive
            string compressedPath = Path.Combine(dataDir, "archive.tar.lz4");
            Directory.CreateDirectory(Path.GetDirectoryName(compressedPath));
            
            // Create TAR archive, add entries, and save as LZ4 compressed file
            using (TarArchive tarArchive = new TarArchive())
            {
                tarArchive.CreateEntry("file1.txt", inputFile1);
                tarArchive.CreateEntry("file2.txt", inputFile2);
                tarArchive.SaveLZ4Compressed(compressedPath);
            }
            
            // Path for the extracted TAR file after decompressing LZ4
            string decompressedTarPath = Path.Combine(dataDir, "extracted.tar");
            Directory.CreateDirectory(Path.GetDirectoryName(decompressedTarPath));
            
            // Decompress the LZ4 wrapper to obtain the TAR payload
            using (Lz4Archive lz4Archive = new Lz4Archive(compressedPath))
            using (FileStream extractedStream = File.Create(decompressedTarPath))
            {
                lz4Archive.Extract(extractedStream);
            }
            
            Console.WriteLine("Decompression completed.");
            
            // Load the TAR archive and list its entries
            using (TarArchive tar = new TarArchive(decompressedTarPath))
            {
                foreach (TarEntry entry in tar.Entries)
                {
                    Console.WriteLine($"Entry: {entry.Name}");
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
 * 1. When you need to bundle several log files into a single compressed TAR.LZ4 package for efficient storage or transfer in a .NET application.
 * 2. When you must decompress an LZ4‑wrapped TAR archive to retrieve the original files for processing or analysis in C#.
 * 3. When implementing a backup routine that creates a lightweight, high‑speed compressed archive of configuration files using Aspose.Zip’s TAR and LZ4 support.
 * 4. When integrating with a system that expects TAR archives but requires LZ4 compression to reduce network bandwidth in a Windows environment.
 * 5. When automating the extraction of a TAR payload from an LZ4 archive to feed the contents into downstream services or pipelines.
 */
