// HOW-TO: Create TAR LZ4 Archive and Extract Specific File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip.Tar;
using Aspose.Zip.Lz4;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string dataDir = @"C:\Data\";
            string inputFile1 = Path.Combine(dataDir, "file1.txt");
            string inputFile2 = Path.Combine(dataDir, "file2.txt");
            string tarLz4Path = Path.Combine(dataDir, "archive.tar.lz4");
            string tarPath = Path.Combine(dataDir, "archive.tar");
            string extractedFilePath = Path.Combine(dataDir, "extracted.txt");

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

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(tarLz4Path));
            Directory.CreateDirectory(Path.GetDirectoryName(tarPath));
            Directory.CreateDirectory(Path.GetDirectoryName(extractedFilePath));

            // Create TAR archive and add entries
            using (TarArchive tarArchive = new TarArchive())
            {
                tarArchive.CreateEntry("file1.txt", inputFile1);
                tarArchive.CreateEntry("file2.txt", inputFile2);
                // Save TAR archive compressed with LZ4
                tarArchive.SaveLZ4Compressed(tarLz4Path);
            }

            // Decompress LZ4 wrapper to obtain TAR payload
            using (Lz4Archive lz4Archive = new Lz4Archive(tarLz4Path))
            using (FileStream tarFileStream = File.Create(tarPath))
            {
                lz4Archive.Extract(tarFileStream);
            }

            // Load TAR archive and extract a selected entry
            using (FileStream tarFileStream = File.OpenRead(tarPath))
            using (TarArchive tarArchive = new TarArchive(tarFileStream))
            {
                // Select entry by name (e.g., "file1.txt")
                TarEntry entry = tarArchive.Entries.FirstOrDefault(e => e.Name.Equals("file1.txt", StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine("Selected entry not found in TAR archive.");
                    return;
                }

                // Extract the selected entry to the desired location
                entry.Extract(extractedFilePath);
                Console.WriteLine($"Extracted '{entry.Name}' to '{extractedFilePath}'.");
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
 * 1. When you need to bundle multiple local files into a single TAR.LZ4 archive for compact storage or transfer in a .NET application.
 * 2. When you must decompress an LZ4‑wrapped TAR file to obtain the original TAR payload before further processing in C#.
 * 3. When you want to load a TAR archive from a stream and extract only a chosen entry to a local path without unpacking the entire archive.
 * 4. When implementing a backup routine that compresses files with LZ4 to save space and later restores a particular file on demand.
 * 5. When integrating with external systems that require TAR.LZ4 format for data exchange and you need to programmatically create, decompress, and extract files using Aspose.Zip for .NET.
 */
