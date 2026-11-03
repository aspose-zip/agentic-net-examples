// HOW-TO: Convert RAR Archive to ZIP with Bzip2 Compression in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Rar;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string rarPath = @"C:\Data\input.rar";
            string zipPath = @"C:\Data\output.zip";

            // Verify input RAR file exists
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            // Open the RAR archive for reading
            using (FileStream rarStream = File.OpenRead(rarPath))
            using (RarArchive rarArchive = new RarArchive(rarStream))
            // Create a new ZIP archive with custom compression (Bzip2 in this example)
            using (Archive zipArchive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
            {
                // Iterate through each entry in the RAR archive
                foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                {
                    // Open the entry stream from the RAR archive
                    using (Stream entryStream = rarEntry.Open())
                    {
                        // Add the entry to the ZIP archive with the same name
                        zipArchive.CreateEntry(rarEntry.Name, entryStream);
                    }
                }

                // Save the ZIP archive to the specified output file
                using (FileStream zipStream = File.Open(zipPath, FileMode.Create))
                {
                    zipArchive.Save(zipStream);
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
 * 1. When you need to migrate legacy RAR backups to a ZIP format that supports Bzip2 compression for better compatibility with modern tools.
 * 2. When an application must programmatically repackage files from a RAR archive into a ZIP archive to send them over a network that only accepts ZIP files.
 * 3. When you want to extract the contents of a RAR file and immediately compress them into a smaller ZIP using Bzip2 to reduce storage costs.
 * 4. When automating a data pipeline that receives RAR uploads and must store them as ZIP archives with custom compression settings for downstream processing.
 * 5. When integrating third‑party RAR archives into a C# project that standardizes on ZIP archives, preserving original filenames while applying a specific compression algorithm.
 */
