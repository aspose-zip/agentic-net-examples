// HOW-TO: Extract Files from RAR and Add to 7Z Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        string rarPath = @"C:\Data\sample.rar";
        string output7zPath = @"C:\Data\combined.7z";

        try
        {
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath));

            using (FileStream rarStream = File.OpenRead(rarPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            using (SevenZipArchive sevenZip = new SevenZipArchive())
            {
                foreach (RarArchiveEntry entry in rarArchive.Entries)
                {
                    if (entry.IsDirectory)
                        continue;

                    using (MemoryStream entryData = new MemoryStream())
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.CopyTo(entryData);
                        }
                        entryData.Position = 0;
                        sevenZip.CreateEntry(entry.Name, entryData);
                    }
                }

                sevenZip.Save(output7zPath);
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
 * 1. When you need to convert a collection of files stored in a RAR archive into a compressed 7Z archive without writing intermediate files to disk.
 * 2. When an application must merge extracted RAR entries into a new 7Z package on the fly for faster backup or distribution.
 * 3. When you want to read RAR contents directly into memory, re‑compress them, and create a 7Z archive in a cloud‑based C# service.
 * 4. When automating a migration from legacy RAR archives to modern 7Z archives while preserving folder structure and reducing storage size.
 * 5. When building a C# utility that extracts specific files from a RAR file and immediately adds them to a password‑protected 7Z archive for secure archiving.
 */
