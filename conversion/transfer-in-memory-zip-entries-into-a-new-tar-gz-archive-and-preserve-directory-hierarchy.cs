// HOW-TO: Convert ZIP Archive to Tar Gz While Preserving Folder Structure in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = "input.zip";
            string outputTarGzPath = "output.tar.gz";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

            List<MemoryStream> tempStreams = new List<MemoryStream>();

            using (Archive zipArchive = new Archive(inputZipPath))
            {
                using (TarArchive tarArchive = new TarArchive())
                {
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        using (Stream zipEntryStream = zipEntry.Open())
                        {
                            MemoryStream entryData = new MemoryStream();
                            zipEntryStream.CopyTo(entryData);
                            entryData.Position = 0;

                            tarArchive.CreateEntry(zipEntry.Name, entryData);
                            tempStreams.Add(entryData);
                        }
                    }

                    tarArchive.SaveGzipped(outputTarGzPath);
                }
            }

            foreach (MemoryStream ms in tempStreams)
            {
                ms.Dispose();
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
 * 1. When you need to repackage files from a ZIP backup into a tar.gz archive for Linux deployment while keeping the original folder layout, this code handles the conversion in C#.
 * 2. When a CI/CD pipeline extracts artifacts from a ZIP file and must create a compressed tarball to upload to a container registry, the in‑memory transfer avoids writing temporary files.
 * 3. When migrating legacy data stored in ZIP archives to a tar.gz format for compatibility with Unix tools, the code preserves the directory hierarchy during the conversion.
 * 4. When generating downloadable tar.gz bundles from user‑uploaded ZIP files in a web application, the approach streams each entry directly into the new archive without disk overhead.
 * 5. When automating backup rotation that consolidates multiple ZIP snapshots into a single compressed tar archive, this solution maintains the original folder structure for easy restoration.
 */
