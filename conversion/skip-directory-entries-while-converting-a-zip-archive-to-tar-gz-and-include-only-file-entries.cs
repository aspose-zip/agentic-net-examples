// HOW-TO: Convert ZIP Archive to Tar Gz Excluding Directories in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        string inputZipPath = "input.zip";
        string outputTarGzPath = "output.tar.gz";

        if (!File.Exists(inputZipPath))
        {
            Console.Error.WriteLine($"File not found: {inputZipPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

        try
        {
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                using (TarArchive tarArchive = new TarArchive())
                {
                    List<Stream> openStreams = new List<Stream>();

                    foreach (ArchiveEntry entry in zipArchive.Entries)
                    {
                        if (entry.IsDirectory)
                        {
                            continue;
                        }

                        Stream entryStream = entry.Open();
                        openStreams.Add(entryStream);
                        tarArchive.CreateEntry(entry.Name, entryStream);
                    }

                    tarArchive.SaveGzipped(outputTarGzPath);

                    foreach (Stream s in openStreams)
                    {
                        s.Dispose();
                    }
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
 * 1. When you need to package only the files from a user‑uploaded ZIP into a compressed tar.gz for Linux deployment pipelines.
 * 2. When migrating backup data from Windows ZIP archives to Unix‑style tar.gz archives while omitting empty folder entries.
 * 3. When creating a lightweight distribution bundle that excludes directory metadata to reduce tar.gz size for cloud storage.
 * 4. When processing ZIP logs and converting them to tar.gz for archival in a system that only accepts tar.gz streams.
 * 5. When automating a CI/CD step that transforms build artifacts stored in ZIP format into a tar.gz without preserving folder hierarchy.
 */
