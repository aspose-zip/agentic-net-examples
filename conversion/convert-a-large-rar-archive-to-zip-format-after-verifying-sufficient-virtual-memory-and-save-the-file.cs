// HOW-TO: Convert Large RAR Archive to ZIP File Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\largeArchive.rar";
            string outputPath = @"C:\Data\convertedArchive.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            using (FileStream rarStream = File.OpenRead(inputPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            using (Archive zipArchive = new Archive())
            {
                foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                {
                    if (rarEntry.IsDirectory)
                    {
                        continue;
                    }

                    using (MemoryStream entryStream = new MemoryStream())
                    {
                        rarEntry.Extract(entryStream);
                        entryStream.Position = 0;
                        zipArchive.CreateEntry(rarEntry.Name, entryStream);
                    }
                }

                zipArchive.Save(outputPath);
            }

            Console.WriteLine("Conversion completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to migrate legacy RAR backups to a ZIP format for compatibility with modern Windows tools.
 * 2. When an application must programmatically extract files from a large RAR archive and re‑package them as a ZIP to reduce storage costs.
 * 3. When a cloud service processes user‑uploaded RAR files and needs to store them as ZIP archives for faster download and virus scanning.
 * 4. When a build pipeline converts third‑party RAR resources into ZIP bundles before embedding them into a .NET deployment package.
 * 5. When a data‑archiving script validates the existence of a RAR file, extracts its contents, and creates a ZIP archive to meet corporate compression standards.
 */
