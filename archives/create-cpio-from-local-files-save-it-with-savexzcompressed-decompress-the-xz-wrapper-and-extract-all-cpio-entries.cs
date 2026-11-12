// HOW-TO: Create CPIO Archive, Compress With XZ, Decompress And Extract In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;
using Aspose.Zip.Xz;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputDir = "input";
            string cpioXzPath = "output/archive.cpio.xz";
            string extractedCpioPath = "output/archive.cpio";
            string extractDir = "output/extracted";

            // Validate input directory
            if (!Directory.Exists(inputDir))
            {
                Console.Error.WriteLine($"Directory not found: {inputDir}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(cpioXzPath));
            Directory.CreateDirectory(Path.GetDirectoryName(extractedCpioPath));
            Directory.CreateDirectory(extractDir);

            // Create CPIO archive and add files
            using (CpioArchive archive = new CpioArchive())
            {
                foreach (string filePath in Directory.GetFiles(inputDir))
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    // Add file to archive (entry name is the file name)
                    archive.CreateEntry(Path.GetFileName(filePath), filePath);
                }

                // Save the CPIO archive compressed with XZ
                archive.SaveXzCompressed(cpioXzPath);
            }

            // Decompress the XZ wrapper to obtain the raw CPIO archive
            using (XzArchive xzArchive = new XzArchive(cpioXzPath))
            using (FileStream extractedStream = File.Create(extractedCpioPath))
            {
                xzArchive.Extract(extractedStream);
            }

            // Extract all entries from the CPIO archive to the output directory
            using (CpioArchive cpio = new CpioArchive(extractedCpioPath))
            {
                foreach (CpioEntry entry in cpio.Entries)
                {
                    string destinationPath = Path.Combine(extractDir, entry.Name);
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                    using (FileStream outStream = File.Create(destinationPath))
                    {
                        entry.Extract(outStream);
                    }
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
 * 1. When you need to package a set of configuration files into a single CPIO archive and reduce its size with XZ compression before distribution.
 * 2. When you receive an XZ‑compressed CPIO backup from a Linux system and must programmatically decompress it to retrieve the original archive.
 * 3. When you want to automate the extraction of all files from a CPIO archive into a specific folder as part of a deployment pipeline.
 * 4. When you are building a cross‑platform installer that stores resources in a CPIO container and uses XZ to minimize download size.
 * 5. When you need to verify the integrity of files by recreating a CPIO archive, compressing it, and then extracting it to compare against the source directory.
 */
