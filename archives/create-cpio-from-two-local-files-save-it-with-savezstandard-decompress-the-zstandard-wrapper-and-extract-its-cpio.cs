// HOW-TO: Create CPIO Archive From Files And Compress With Zstandard In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Cpio;
using Aspose.Zip.Zstandard;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Define paths
            string baseDir = "output";
            string inputFile1 = "input1.txt";
            string inputFile2 = "input2.txt";
            string cpioPath = Path.Combine(baseDir, "archive.cpio");
            string zstPath = Path.Combine(baseDir, "archive.cpio.zst");
            string extractedCpioPath = Path.Combine(baseDir, "extracted.cpio");
            string outputDir = Path.Combine(baseDir, "extracted_files");
            string tempDir = Path.Combine(baseDir, "temp");

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
            Directory.CreateDirectory(baseDir);
            Directory.CreateDirectory(Path.GetDirectoryName(cpioPath));
            Directory.CreateDirectory(Path.GetDirectoryName(zstPath));
            Directory.CreateDirectory(Path.GetDirectoryName(extractedCpioPath));
            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(tempDir);

            // Copy input files to a temporary folder for CPIO creation
            File.Copy(inputFile1, Path.Combine(tempDir, Path.GetFileName(inputFile1)), true);
            File.Copy(inputFile2, Path.Combine(tempDir, Path.GetFileName(inputFile2)), true);

            // Create CPIO archive from the two files
            using (CpioArchive cpioArchive = new CpioArchive())
            {
                cpioArchive.CreateEntries(tempDir);
                cpioArchive.Save(cpioPath);
            }

            // Compress the CPIO archive using Zstandard
            using (ZstandardArchive zstdArchive = new ZstandardArchive())
            {
                zstdArchive.SetSource(cpioPath);
                zstdArchive.Save(zstPath);
            }

            // Decompress the Zstandard wrapper to obtain the original CPIO file
            using (ZstandardArchive zstdRead = new ZstandardArchive(zstPath))
            {
                using (FileStream extractedStream = File.Create(extractedCpioPath))
                {
                    zstdRead.Extract(extractedStream);
                }
            }

            // Extract entries from the decompressed CPIO archive to the output directory
            using (CpioArchive extractedCpio = new CpioArchive(extractedCpioPath))
            {
                extractedCpio.ExtractToDirectory(outputDir);
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
 * 1. When you need to bundle multiple configuration files into a single CPIO package and reduce its size with Zstandard for faster network transfer in a .NET application.
 * 2. When you want to create a portable Linux‑compatible CPIO archive from Windows files, compress it, and later extract the contents on a server for automated deployment scripts.
 * 3. When implementing a backup solution that stores small text logs in a CPIO archive and uses Zstandard compression to minimize storage space while preserving the ability to restore individual files.
 * 4. When integrating with legacy systems that accept CPIO archives, you can compress the archive with Zstandard to meet bandwidth constraints and then decompress and extract it on the target machine.
 * 5. When building a CI/CD pipeline that packages build artifacts into a CPIO file, compresses it for artifact storage, and later unpacks it to a working directory for testing or deployment.
 */
