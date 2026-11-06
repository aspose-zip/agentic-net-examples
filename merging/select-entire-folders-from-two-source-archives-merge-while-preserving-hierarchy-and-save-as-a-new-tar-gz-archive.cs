// HOW-TO: Merge Specific Folders from Two ZIP Files into a TAR.GZ in C# (Aspose.ZIP for .NET)
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
            string inputArchivePath1 = "input1.zip";
            string inputArchivePath2 = "input2.zip";
            string outputTarGzPath = "output.tar.gz";

            // Validate input files
            if (!File.Exists(inputArchivePath1))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath1}");
                return;
            }
            if (!File.Exists(inputArchivePath2))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

            // Open source archives and create target TAR archive
            using (Archive archive1 = new Archive(inputArchivePath1))
            using (Archive archive2 = new Archive(inputArchivePath2))
            using (TarArchive tarArchive = new TarArchive())
            {
                // Merge folder "FolderA" from first archive
                foreach (ArchiveEntry entry in archive1.Entries)
                {
                    if (entry.Name.StartsWith("FolderA/", StringComparison.OrdinalIgnoreCase))
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            tarArchive.CreateEntry(entry.Name, entryStream);
                        }
                    }
                }

                // Merge folder "FolderB" from second archive
                foreach (ArchiveEntry entry in archive2.Entries)
                {
                    if (entry.Name.StartsWith("FolderB/", StringComparison.OrdinalIgnoreCase))
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            tarArchive.CreateEntry(entry.Name, entryStream);
                        }
                    }
                }

                // Save the merged archive as TAR.GZ
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
 * 1. When you need to combine selected directories from multiple ZIP packages into a single compressed TAR.GZ for deployment to Linux servers.
 * 2. When you want to extract only certain project subfolders from separate vendor ZIP archives and repack them while keeping the original folder structure.
 * 3. When you are creating a backup that consolidates specific data sets from different ZIP backups into one tar.gz archive for efficient storage.
 * 4. When you must prepare a distribution bundle that includes only the required modules from two ZIP releases and deliver it as a TAR.GZ to end‑users.
 * 5. When you automate a CI/CD pipeline that pulls particular folders from multiple ZIP artifacts and merges them into a tar.gz archive for container image creation.
 */
