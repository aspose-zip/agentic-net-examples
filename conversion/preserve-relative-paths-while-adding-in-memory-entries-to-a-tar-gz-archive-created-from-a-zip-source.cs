// HOW-TO: Create Tar.Gz From Zip While Preserving Paths And Adding In‑Memory Files In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Tar;

public class Program
{
    public static void Main(string[] args)
    {
        string zipInputPath = "input.zip";
        string tarGzOutputPath = "output/output.tar.gz";

        try
        {
            if (!File.Exists(zipInputPath))
            {
                Console.Error.WriteLine($"File not found: {zipInputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(tarGzOutputPath));

            List<(string Name, MemoryStream Data)> entryList = new List<(string, MemoryStream)>();

            using (Archive zipArchive = new Archive(zipInputPath))
            {
                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    if (zipEntry.Name.EndsWith("/") || zipEntry.Name.EndsWith("\\"))
                    {
                        continue;
                    }

                    using (Stream sourceStream = zipEntry.Open())
                    {
                        MemoryStream memory = new MemoryStream();
                        sourceStream.CopyTo(memory);
                        memory.Position = 0;
                        entryList.Add((zipEntry.Name, memory));
                    }
                }
            }

            string generatedEntryName = "generated/folder/info.txt";
            byte[] generatedContent = Encoding.UTF8.GetBytes("This is generated content.");
            MemoryStream generatedStream = new MemoryStream(generatedContent);
            entryList.Add((generatedEntryName, generatedStream));

            using (TarArchive tarArchive = new TarArchive())
            {
                foreach ((string Name, MemoryStream Data) entry in entryList)
                {
                    tarArchive.CreateEntry(entry.Name, entry.Data);
                }

                tarArchive.SaveGzipped(tarGzOutputPath);
            }

            foreach ((string Name, MemoryStream Data) entry in entryList)
            {
                entry.Data.Dispose();
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
 * 1. When you need to convert an existing ZIP package into a compressed TAR.GZ archive while keeping the original folder hierarchy intact.
 * 2. When you must inject dynamically generated files, such as configuration or log data, into an archive without writing them to disk first.
 * 3. When a deployment pipeline requires bundling resources from a ZIP source together with in‑memory assets into a single TAR.GZ for Linux servers.
 * 4. When you are building a backup solution that extracts files from a ZIP, adds metadata files on the fly, and stores the result as a compressed TAR archive.
 * 5. When you want to programmatically create a TAR.GZ archive in C# that combines existing ZIP entries with temporary streams for further distribution or transmission.
 */
