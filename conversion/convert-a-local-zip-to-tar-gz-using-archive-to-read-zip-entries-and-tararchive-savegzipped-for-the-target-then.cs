// HOW-TO: Convert a ZIP File to a Gzipped TAR Archive in C# (Aspose.ZIP for .NET)
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

            string outputDir = Path.GetDirectoryName(outputTarGzPath);
            Directory.CreateDirectory(outputDir);

            List<Stream> openEntryStreams = new List<Stream>();

            using (Archive zipArchive = new Archive(inputZipPath))
            {
                using (TarArchive tarArchive = new TarArchive())
                {
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        if (zipEntry.IsDirectory)
                        {
                            continue;
                        }

                        Stream entryStream = zipEntry.Open();
                        openEntryStreams.Add(entryStream);
                        tarArchive.CreateEntry(zipEntry.Name, entryStream);
                    }

                    tarArchive.SaveGzipped(outputTarGzPath);
                }
            }

            foreach (Stream s in openEntryStreams)
            {
                s.Dispose();
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
 * 1. When you need to package files from an existing ZIP into a TAR.GZ for Linux‑based deployment pipelines.
 * 2. When you want to migrate legacy ZIP backups to a more space‑efficient Gzipped TAR format using C#.
 * 3. When a .NET service must stream ZIP entries directly into a TAR.GZ without extracting them to disk.
 * 4. When you are creating cross‑platform archives for distribution, converting Windows ZIP archives to TAR.GZ for macOS or Unix users.
 * 5. When automating archival of log files stored in ZIPs into a compressed TAR archive for long‑term storage.
 */
