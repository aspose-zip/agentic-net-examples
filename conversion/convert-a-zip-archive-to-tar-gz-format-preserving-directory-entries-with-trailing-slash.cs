// HOW-TO: Convert ZIP Archive to Gzipped TAR While Preserving Directory Structure in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP and output TAR.GZ paths
            string inputZipPath = "input.zip";
            string outputTarGzPath = "output.tar.gz";

            // Verify input ZIP exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

            // Temporary directory for extracting ZIP contents
            string tempExtractDir = Path.Combine(Path.GetTempPath(), "ZipToTarTemp");
            Directory.CreateDirectory(tempExtractDir);

            // Extract ZIP archive to temporary directory
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                zipArchive.ExtractToDirectory(tempExtractDir);
            }

            // Create TAR archive and add extracted files/directories
            using (TarArchive tarArchive = new TarArchive())
            {
                // Add all entries from the temporary directory, preserving directory structure
                tarArchive.CreateEntries(tempExtractDir);

                // Save the TAR archive with GZIP compression
                tarArchive.SaveGzipped(outputTarGzPath);
            }

            // Cleanup temporary extraction directory
            try
            {
                Directory.Delete(tempExtractDir, true);
            }
            catch
            {
                // Ignore cleanup errors
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate a ZIP backup to a TAR.GZ package for Linux deployment while keeping empty folder entries intact.
 * 2. When a CI/CD pipeline must transform third‑party ZIP distributions into gzipped TAR archives for compatibility with Unix‑based tools.
 * 3. When you want to archive project files on Windows and then compress them into a TAR.GZ format for storage in a cloud service that expects TAR archives.
 * 4. When an application must extract a ZIP bundle, re‑package its contents as a TAR.GZ, and preserve the original directory hierarchy for later extraction on a different platform.
 * 5. When you need to automate the conversion of user‑uploaded ZIP files into TAR.GZ archives to maintain consistent compression standards across a multi‑OS environment.
 */
