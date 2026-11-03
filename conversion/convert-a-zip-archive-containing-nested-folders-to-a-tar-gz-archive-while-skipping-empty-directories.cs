// HOW-TO: Convert Nested ZIP Archive to Tar Gz Skipping Empty Directories in C# (Aspose.ZIP for .NET)
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
            string outputTarGzPath = "output/output.tar.gz";
            string tempExtractDir = "tempExtract";

            // Validate input ZIP file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

            // Ensure temporary extraction directory exists
            Directory.CreateDirectory(tempExtractDir);

            // Open the ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Iterate over entries and extract only files (skip directories)
                foreach (ArchiveEntry entry in zipArchive.Entries)
                {
                    // Skip directory entries
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Determine full path for extraction
                    string destinationPath = Path.Combine(tempExtractDir, entry.Name);

                    // Ensure the destination directory exists
                    string destinationDir = Path.GetDirectoryName(destinationPath);
                    Directory.CreateDirectory(destinationDir);

                    // Extract the file entry to the destination path
                    entry.Extract(destinationPath);
                }
            }

            // Create a TAR archive and add extracted files, preserving relative paths
            using (TarArchive tarArchive = new TarArchive())
            {
                // Get all files from the temporary extraction directory
                string[] files = Directory.GetFiles(tempExtractDir, "*", SearchOption.AllDirectories);
                foreach (string filePath in files)
                {
                    // Compute relative path inside the TAR archive
                    string relativePath = Path.GetRelativePath(tempExtractDir, filePath).Replace(Path.DirectorySeparatorChar, '/');

                    // Add the file to the TAR archive
                    tarArchive.CreateEntry(relativePath, filePath);
                }

                // Save the TAR archive as a gzipped file
                tarArchive.SaveGzipped(outputTarGzPath);
            }

            // Cleanup temporary extraction directory
            Directory.Delete(tempExtractDir, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to migrate a packaged set of files from a ZIP distribution to a tar.gz format for deployment on Linux systems while preserving folder hierarchy.
 * 2. When you want to extract only the actual files from a ZIP backup, ignoring empty folders, before creating a compressed tarball for archival storage.
 * 3. When an automated build pipeline must repackage third‑party resources delivered as ZIP into a tar.gz bundle to meet a target environment’s compression standards.
 * 4. When you are consolidating multiple nested ZIP archives into a single tar.gz archive for easier transfer over bandwidth‑limited networks.
 * 5. When you need to programmatically convert user‑uploaded ZIP files into tar.gz archives while ensuring no empty directories are included in the final package.
 */
