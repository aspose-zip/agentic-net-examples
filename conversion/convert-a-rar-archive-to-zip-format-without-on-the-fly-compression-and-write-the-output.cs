// HOW-TO: Convert RAR Archive to ZIP Without Recompression Using Aspose.Zip in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Rar;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputPath = @"C:\Data\sample.rar";
            string outputPath = @"C:\Data\output.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream rarFileStream = File.OpenRead(inputPath))
            using (RarArchive rarArchive = new RarArchive(rarFileStream))
            using (Archive zipArchive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
            {
                List<Stream> entryStreams = new List<Stream>();

                foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                {
                    if (rarEntry.IsDirectory)
                    {
                        continue;
                    }

                    Stream entryStream = rarEntry.Open();
                    entryStreams.Add(entryStream);
                    zipArchive.CreateEntry(rarEntry.Name, entryStream);
                }

                using (FileStream zipFileStream = File.Open(outputPath, FileMode.Create))
                {
                    zipArchive.Save(zipFileStream);
                }

                foreach (Stream s in entryStreams)
                {
                    s.Dispose();
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
 * 1. When you need to migrate legacy RAR backups to ZIP for compatibility with systems that only support ZIP files.
 * 2. When you want to create a ZIP package from a RAR archive without changing the original file sizes, preserving the original compression.
 * 3. When an application must programmatically extract files from a RAR archive and re‑store them as a ZIP for downstream processing pipelines.
 * 4. When you are building a .NET service that receives RAR uploads and must deliver them as ZIP archives to clients without recompressing the data.
 * 5. When you need to convert user‑provided RAR archives to ZIP on a server while ensuring fast conversion by using store compression.
 */
