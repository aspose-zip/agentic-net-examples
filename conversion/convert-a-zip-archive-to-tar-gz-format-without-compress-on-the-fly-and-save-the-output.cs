// HOW-TO: Convert ZIP Archive to TAR.GZ File in C# Using Aspose.Zip (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "input.zip";
            string outputPath = "output.tar.gz";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary directory for extracting ZIP contents
            string tempExtractDir = Path.Combine(Path.GetTempPath(), "ZipToTarTemp");
            Directory.CreateDirectory(tempExtractDir);

            // Extract ZIP archive to temporary directory
            using (Archive zipArchive = new Archive(inputPath))
            {
                zipArchive.ExtractToDirectory(tempExtractDir);
            }

            // Create TAR.GZ archive from extracted files
            using (TarArchive tarArchive = new TarArchive())
            {
                // Add each extracted file to the TAR archive
                foreach (string filePath in Directory.GetFiles(tempExtractDir, "*", SearchOption.AllDirectories))
                {
                    // Compute entry name relative to the temporary directory, using forward slashes
                    string entryName = Path.GetRelativePath(tempExtractDir, filePath).Replace('\\', '/');
                    tarArchive.CreateEntry(entryName, filePath);
                }

                // Save the TAR archive as a gzipped file
                tarArchive.SaveGzipped(outputPath);
            }

            // Clean up temporary extraction directory
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
 * 1. When you need to migrate legacy ZIP backups to a TAR.GZ format for compatibility with Unix‑based deployment pipelines.
 * 2. When a .NET service must unpack a user‑uploaded ZIP file and repackage its contents as a compressed TAR archive for downstream processing.
 * 3. When automating data archiving on Windows servers and the target storage system only accepts gzipped TAR files.
 * 4. When integrating with third‑party tools that read TAR.GZ archives, requiring conversion of existing ZIP resources in a C# application.
 * 5. When creating portable software bundles that need both extraction and compression steps separated, using Aspose.Zip to avoid on‑the‑fly compression.
 */
