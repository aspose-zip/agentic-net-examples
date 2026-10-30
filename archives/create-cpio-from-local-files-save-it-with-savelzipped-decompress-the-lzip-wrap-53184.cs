// HOW-TO: Create and Extract LZ‑Compressed CPIO Archive from Files in C# (Aspose.ZIP for .NET)
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
            // Define directories and paths
            string dataDir = "Data";
            string outputDir = "Output";
            string cpioLzPath = Path.Combine(outputDir, "archive.cpio.lz");

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(cpioLzPath));

            // Input files to be added to the CPIO archive
            string[] inputFiles = new string[]
            {
                Path.Combine(dataDir, "file1.txt"),
                Path.Combine(dataDir, "file2.txt")
            };

            // Verify each input file exists
            foreach (string inputFile in inputFiles)
            {
                if (!File.Exists(inputFile))
                {
                    Console.Error.WriteLine($"File not found: {inputFile}");
                    return;
                }
            }

            // Create CPIO archive and add entries
            using (CpioArchive archive = new CpioArchive())
            {
                archive.CreateEntry("file1.txt", inputFiles[0]);
                archive.CreateEntry("file2.txt", inputFiles[1]);

                // Save the archive with LZ compression
                archive.SaveLzipped(cpioLzPath);
            }

            // Decompress the LZIP-wrapped archive
            string decompressDir = Path.Combine(outputDir, "Decompressed");
            Directory.CreateDirectory(decompressDir);

            using (LzipArchive lzip = new LzipArchive(cpioLzPath))
            {
                lzip.Extract(decompressDir);
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
 * 1. When you need to bundle multiple configuration files into a single CPIO archive and compress it with LZ for efficient storage or transfer in a .NET application.
 * 2. When you want to generate a legacy CPIO package that can be read by Unix tools, then compress it with LZIP to meet size constraints before sending it over a network.
 * 3. When an automated build process must archive log files, apply LZ compression, and later extract them on a Windows server using Aspose.Zip.
 * 4. When you are implementing a backup routine that creates a compressed CPIO snapshot of selected files and later restores the contents to a specific directory.
 * 5. When a cross‑platform deployment script requires creating an LZIP‑wrapped CPIO archive in C# and then decompressing it on the target machine for installation.
 */
