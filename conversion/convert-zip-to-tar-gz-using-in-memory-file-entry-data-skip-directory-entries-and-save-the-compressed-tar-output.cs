// HOW-TO: Convert ZIP Archive To Gzipped TAR In C# Using Memory Streams (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input ZIP and output TAR.GZ paths
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

        try
        {
            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputPath))
            {
                // Create a new TAR archive (in memory)
                using (TarArchive tarArchive = new TarArchive())
                {
                    // Iterate over ZIP entries
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Skip directory entries
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        // Read entry data into a memory stream
                        using (MemoryStream entryData = new MemoryStream())
                        {
                            using (Stream entryStream = zipEntry.Open())
                            {
                                entryStream.CopyTo(entryData);
                            }
                            entryData.Position = 0;

                            // Add the entry to the TAR archive using the same entry name
                            tarArchive.CreateEntry(zipEntry.Name, entryData);
                        }
                    }

                    // Save the TAR archive compressed with GZIP
                    tarArchive.SaveGzipped(outputPath);
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
 * 1. When you need to repackage files from a downloaded ZIP into a gzipped TAR for deployment on Linux servers using C#.
 * 2. When you want to convert user‑uploaded ZIP files to a TAR.GZ format without creating temporary files on disk.
 * 3. When you must extract only file entries from a ZIP archive, skip directories, and create a compressed TAR for backup purposes.
 * 4. When an automated build pipeline requires converting ZIP artifacts to TAR.GZ to meet packaging standards in a .NET application.
 * 5. When you need to read ZIP entry data into memory, transform it, and save a gzipped TAR archive in a single C# process.
 */
