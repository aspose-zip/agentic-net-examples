// HOW-TO: Compress Binary Files into a BZIP2 CPIO Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Bzip2;
using Aspose.Zip.Cpio;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing binary files
            string inputDir = "InputData";
            // Hardcoded output file path
            string outputPath = "Output/binaries.cpio.bz2";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create a CPIO archive and add files from the input directory
            using (CpioArchive cpio = new CpioArchive())
            {
                foreach (string filePath in Directory.GetFiles(inputDir))
                {
                    // Validate each file before adding
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    cpio.CreateEntry(entryName, filePath);
                }

                // Compress the CPIO archive using BZIP2
                using (Bzip2Archive bz2 = new Bzip2Archive())
                {
                    bz2.SetSource(cpio);
                    bz2.Save(outputPath);
                }
            }

            Console.WriteLine($"Compressed archive saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle multiple executable binaries into a single CPIO file and reduce its size with BZIP2 for faster network transfer.
 * 2. When deploying firmware updates that must be delivered as a compressed CPIO archive to embedded Linux devices.
 * 3. When creating backup archives of binary assets for archival storage while maintaining compatibility with legacy CPIO tools.
 * 4. When preparing a distribution package for a Unix-based installer that expects a .cpio.bz2 file.
 * 5. When automating a build pipeline that packages compiled binaries into a compressed CPIO archive for later extraction on target systems.
 */
