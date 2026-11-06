// HOW-TO: Merge Multiple Zip Archives In‑Memory While Preserving Folder Structure In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceArchivePath1 = @"C:\Data\Archive1.zip";
            string sourceArchivePath2 = @"C:\Data\Archive2.zip";

            if (!File.Exists(sourceArchivePath1))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath1}");
                return;
            }
            if (!File.Exists(sourceArchivePath2))
            {
                Console.Error.WriteLine($"File not found: {sourceArchivePath2}");
                return;
            }

            string outputArchivePath = @"C:\Data\MergedArchive.zip";

            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            using (Archive mergedArchive = new Archive())
            {
                string[] sourceArchives = new string[] { sourceArchivePath1, sourceArchivePath2 };

                foreach (string srcPath in sourceArchives)
                {
                    using (Archive srcArchive = new Archive(srcPath))
                    {
                        foreach (ArchiveEntry srcEntry in srcArchive.Entries)
                        {
                            using (Stream srcStream = srcEntry.Open())
                            {
                                MemoryStream entryData = new MemoryStream();
                                srcStream.CopyTo(entryData);
                                entryData.Position = 0;
                                mergedArchive.CreateEntry(srcEntry.Name, entryData);
                            }
                        }
                    }
                }

                mergedArchive.Save(outputArchivePath);
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
 * 1. When you need to combine several ZIP files into a single archive without writing intermediate files to disk, such as consolidating user‑uploaded packages on a web server.
 * 2. When you want to preserve the original directory layout from multiple source archives while creating a merged ZIP for backup or distribution.
 * 3. When you are building a deployment tool that gathers resources from different modules packaged as ZIPs and produces one installable archive in C#.
 * 4. When you must merge confidential archives in memory to avoid exposing temporary files on the file system for security compliance.
 * 5. When you are automating a data‑pipeline that extracts, merges, and re‑compresses log archives before uploading them to cloud storage.
 */
