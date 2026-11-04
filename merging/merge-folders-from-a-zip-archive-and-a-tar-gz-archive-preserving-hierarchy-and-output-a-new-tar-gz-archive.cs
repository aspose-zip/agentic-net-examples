// HOW-TO: Merge ZIP and TAR.GZ Archives Into a Single TAR.GZ in C# (Aspose.ZIP for .NET)
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
            string zipInputPath = "input.zip";
            string tarGzInputPath = "input.tar.gz";
            string outputPath = "merged_output.tar.gz";

            // Validate input files
            if (!File.Exists(zipInputPath))
            {
                Console.Error.WriteLine($"File not found: {zipInputPath}");
                return;
            }
            if (!File.Exists(tarGzInputPath))
            {
                Console.Error.WriteLine($"File not found: {tarGzInputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Temporary folder for extracting both archives
            string tempExtractPath = Path.Combine(Path.GetTempPath(), "MergeTemp_" + Guid.NewGuid().ToString("N"));
            Directory.CreateDirectory(tempExtractPath);

            // Extract ZIP archive
            using (Archive zipArchive = new Archive(zipInputPath))
            {
                foreach (ArchiveEntry entry in zipArchive.Entries)
                {
                    entry.Extract(tempExtractPath);
                }
            }

            // Extract TAR.GZ archive using generic Archive detection
            using (Archive tarArchive = new Archive(tarGzInputPath))
            {
                tarArchive.ExtractToDirectory(tempExtractPath);
            }

            // Create new TAR.GZ archive from merged content
            using (TarArchive mergedArchive = new TarArchive())
            {
                mergedArchive.CreateEntries(new DirectoryInfo(tempExtractPath));
                mergedArchive.SaveGzipped(outputPath);
            }

            // Cleanup temporary folder
            Directory.Delete(tempExtractPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to combine files from a legacy TAR.GZ backup and a modern ZIP distribution into one compressed package for deployment.
 * 2. When you must preserve the original folder hierarchy while merging contents from two different archive formats before uploading to a cloud storage service.
 * 3. When an automated build process requires consolidating assets stored in ZIP and TAR.GZ archives into a single TAR.GZ for Linux container images.
 * 4. When you want to extract and repackage data from multiple source archives into a unified TAR.GZ to simplify distribution to end‑users.
 * 5. When a migration script has to read both ZIP and TAR.GZ inputs, merge their directories, and produce a gzipped TAR for archival compliance.
 */
