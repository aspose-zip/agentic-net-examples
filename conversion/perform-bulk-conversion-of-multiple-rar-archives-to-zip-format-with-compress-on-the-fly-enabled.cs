// HOW-TO: Convert Multiple RAR Files to ZIP with Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] rarFiles = new string[]
            {
                @"C:\Data\Archive1.rar",
                @"C:\Data\Archive2.rar"
            };

            string outputDirectory = @"C:\Data\Converted";

            foreach (string rarPath in rarFiles)
            {
                if (!File.Exists(rarPath))
                {
                    Console.Error.WriteLine($"File not found: {rarPath}");
                    continue;
                }

                string zipFileName = Path.GetFileNameWithoutExtension(rarPath) + ".zip";
                string zipPath = Path.Combine(outputDirectory, zipFileName);

                Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

                using (FileStream rarStream = File.OpenRead(rarPath))
                using (RarArchive rarArchive = new RarArchive(rarStream))
                using (Archive zipArchive = new Archive())
                {
                    foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                    {
                        if (rarEntry.IsDirectory)
                            continue;

                        using (Stream entryStream = rarEntry.Open())
                        {
                            zipArchive.CreateEntry(rarEntry.Name, entryStream);
                        }
                    }

                    using (FileStream zipStream = File.Open(zipPath, FileMode.Create))
                    {
                        zipArchive.Save(zipStream);
                    }
                }

                Console.WriteLine($"Converted '{rarPath}' to '{zipPath}'.");
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
 * 1. When you need to migrate legacy RAR backups to ZIP archives for compatibility with modern .NET applications.
 * 2. When you must batch‑process a list of RAR files and create compressed ZIP versions without extracting them to disk first.
 * 3. When an automated build pipeline has to archive build artifacts originally stored as RAR and deliver them as ZIP to downstream tools.
 * 4. When a cloud service receives user‑uploaded RAR archives and you need to store them as ZIP to reduce storage costs and simplify access.
 * 5. When you are developing a file‑conversion utility that reads RAR entries on the fly and writes them directly into a new ZIP archive in C#.
 */
