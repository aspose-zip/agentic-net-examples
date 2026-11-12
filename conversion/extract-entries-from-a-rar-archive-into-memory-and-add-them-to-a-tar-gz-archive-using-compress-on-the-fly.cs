// HOW-TO: Extract RAR Archive Entries to Memory and Build Gzipped TAR in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Rar;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        string inputRarPath = "input.rar";
        string outputTarGzPath = "output.tar.gz";

        if (!File.Exists(inputRarPath))
        {
            Console.Error.WriteLine($"File not found: {inputRarPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputTarGzPath));

        try
        {
            using (FileStream rarFs = File.OpenRead(inputRarPath))
            using (RarArchive rarArchive = new RarArchive(rarFs))
            using (TarArchive tarArchive = new TarArchive())
            {
                foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                {
                    if (rarEntry.IsDirectory)
                    {
                        continue;
                    }

                    using (Stream entryStream = rarEntry.Open())
                    using (MemoryStream ms = new MemoryStream())
                    {
                        entryStream.CopyTo(ms);
                        ms.Position = 0;
                        tarArchive.CreateEntry(rarEntry.Name, ms);
                    }
                }

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
 * 1. When you need to convert a RAR archive into a compressed TAR.GZ without writing intermediate files to disk.
 * 2. When you want to stream RAR entries directly into memory for further processing before archiving them into a TAR.GZ.
 * 3. When you are building a backup solution that extracts files from legacy RAR backups and stores them in a modern gzip‑compressed TAR format.
 * 4. When you need to integrate RAR extraction and TAR.GZ creation in a single C# workflow for cloud‑based file pipelines.
 * 5. When you must preserve the original file names from a RAR archive while repackaging them into a gzipped TAR for cross‑platform distribution.
 */
