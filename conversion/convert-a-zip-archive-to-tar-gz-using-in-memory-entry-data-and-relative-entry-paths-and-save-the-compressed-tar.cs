// HOW-TO: Convert Zip Archive To Tar.Gz In Memory Using C# Aspose (Aspose.ZIP for .NET)
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

            // Verify input file exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            string outputDirectory = Path.GetDirectoryName(outputTarGzPath);
            Directory.CreateDirectory(outputDirectory);

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Create a new TAR archive in memory
                using (TarArchive tarArchive = new TarArchive())
                {
                    // Iterate through each entry in the ZIP archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Skip directories; TAR will create them implicitly if needed
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Read entry data into a memory stream
                        using (MemoryStream entryData = new MemoryStream())
                        {
                            using (Stream zipStream = zipEntry.Open())
                            {
                                zipStream.CopyTo(entryData);
                            }

                            // Reset stream position before adding to TAR
                            entryData.Position = 0;

                            // Add entry to TAR with the same relative path as in ZIP
                            tarArchive.CreateEntry(zipEntry.Name, entryData);
                        }
                    }

                    // Save the TAR archive compressed as GZIP
                    tarArchive.SaveGzipped(outputTarGzPath);
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
 * 1. When you need to migrate a package of files from a ZIP distribution to a TAR.GZ format for deployment on Linux systems without writing temporary files to disk.
 * 2. When a CI/CD pipeline must repackage build artifacts stored in a ZIP file into a compressed TAR archive for compatibility with tools that only accept .tar.gz inputs.
 * 3. When an application receives uploaded ZIP files and must forward them to a downstream service that expects TAR.GZ streams, preserving the original folder structure.
 * 4. When you want to compress large data sets in memory to reduce I/O overhead before storing the resulting TAR.GZ file on a network share.
 * 5. When you are building a backup utility that converts existing ZIP backups into TAR.GZ archives to save space and standardize the archive format across platforms.
 */
