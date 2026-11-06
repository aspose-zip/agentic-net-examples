// HOW-TO: Merge ZIP and CPIO Archives into a Compressed TAR.GZ in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Cpio;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputZipPath = "input.zip";
            string inputCpioPath = "input.cpio";
            string outputTarGzPath = "output.tar.gz";

            // Validate input files
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }
            if (!File.Exists(inputCpioPath))
            {
                Console.Error.WriteLine($"File not found: {inputCpioPath}");
                return;
            }

            // Prepare temporary working directory
            string tempRoot = Path.Combine(Path.GetTempPath(), "MergeTemp");
            Directory.CreateDirectory(tempRoot);
            string zipExtractPath = Path.Combine(tempRoot, "zip");
            string cpioExtractPath = Path.Combine(tempRoot, "cpio");
            Directory.CreateDirectory(zipExtractPath);
            Directory.CreateDirectory(cpioExtractPath);

            // Extract ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                zipArchive.ExtractToDirectory(zipExtractPath);
            }

            // Extract CPIO archive
            using (CpioArchive cpioArchive = new CpioArchive(inputCpioPath))
            {
                cpioArchive.ExtractToDirectory(cpioExtractPath);
            }

            // Create TAR.GZ archive and add all extracted entries
            using (TarArchive tarArchive = new TarArchive())
            {
                // Add files from ZIP extraction
                string[] zipFiles = Directory.GetFiles(zipExtractPath, "*", SearchOption.AllDirectories);
                foreach (string filePath in zipFiles)
                {
                    string entryName = Path.GetRelativePath(tempRoot, filePath).Replace('\\', '/');
                    tarArchive.CreateEntry(entryName, filePath);
                }

                // Add files from CPIO extraction
                string[] cpioFiles = Directory.GetFiles(cpioExtractPath, "*", SearchOption.AllDirectories);
                foreach (string filePath in cpioFiles)
                {
                    string entryName = Path.GetRelativePath(tempRoot, filePath).Replace('\\', '/');
                    tarArchive.CreateEntry(entryName, filePath);
                }

                // Ensure output directory exists
                Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

                // Save as compressed TAR.GZ
                tarArchive.SaveGzipped(outputTarGzPath);
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
 * 1. When you need to combine files from a legacy CPIO package and a modern ZIP distribution into a single .tar.gz for Linux deployment.
 * 2. When you must extract contents from two different archive formats, merge them, and deliver a compressed archive to reduce download size.
 * 3. When a build pipeline generates separate ZIP and CPIO artifacts that need to be bundled together for archival or backup purposes.
 * 4. When you are migrating data from Windows (ZIP) and Unix (CPIO) sources into a unified TAR.GZ archive for cross‑platform compatibility.
 * 5. When you want to automate the creation of a .tar.gz that includes all files from multiple source archives as part of a CI/CD release process.
 */
