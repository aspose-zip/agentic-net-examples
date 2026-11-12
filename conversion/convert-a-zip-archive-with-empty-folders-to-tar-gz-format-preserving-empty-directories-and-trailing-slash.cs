// HOW-TO: Convert ZIP Archive with Empty Folders to TAR.GZ in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.zip";
            string outputPath = "output.tar.gz";

            // Verify input ZIP exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Create a temporary directory for extraction
            string tempDir = Path.Combine(Path.GetTempPath(), "ZipToTarTemp_" + Guid.NewGuid().ToString());
            Directory.CreateDirectory(tempDir);

            // Extract ZIP archive (including empty folders) to temporary directory
            using (Archive zipArchive = new Archive(inputPath))
            {
                zipArchive.ExtractToDirectory(tempDir);
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create TAR archive from the extracted folder and compress to GZIP
            using (TarArchive tarArchive = new TarArchive())
            {
                // Add all files and empty directories from the temporary folder
                tarArchive.CreateEntries(tempDir);
                tarArchive.SaveGzipped(outputPath);
            }

            // Clean up temporary directory
            try
            {
                Directory.Delete(tempDir, true);
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
 * 1. When you need to migrate a legacy ZIP backup that contains empty directories to a compressed TAR.GZ package for Linux deployment.
 * 2. When a CI/CD pipeline must preserve folder structure, including empty folders, while converting Windows‑generated ZIP files to TAR.GZ for cross‑platform distribution.
 * 3. When you are building a .NET utility that extracts a ZIP archive, keeps its empty directories, and re‑packs it as a gzipped TAR for archival compliance.
 * 4. When an application requires converting user‑uploaded ZIP uploads into TAR.GZ format without losing placeholder directories used for configuration.
 * 5. When automating data migration between cloud storage services that accept only TAR.GZ files but the source archives contain empty folders that must remain intact.
 */
