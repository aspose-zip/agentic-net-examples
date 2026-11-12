// HOW-TO: Convert Multiple RAR Archives to ZIP Without Compression in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input RAR files
            string[] rarFiles = new string[]
            {
                "C:\\Data\\Archive1.rar",
                "C:\\Data\\Archive2.rar"
            };

            // Output directory for ZIP files
            string outputDirectory = "C:\\Data\\Converted";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            foreach (string rarPath in rarFiles)
            {
                // Validate input file existence
                if (!File.Exists(rarPath))
                {
                    Console.Error.WriteLine($"File not found: {rarPath}");
                    return;
                }

                // Determine output ZIP path
                string zipPath = Path.Combine(outputDirectory, Path.GetFileNameWithoutExtension(rarPath) + ".zip");

                // Ensure output directory for this file exists
                Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

                // Open RAR archive for reading
                using (FileStream rarStream = File.OpenRead(rarPath))
                using (RarArchive rarArchive = new RarArchive(rarStream))
                {
                    // Create ZIP archive with store (no compression) settings
                    using (FileStream zipStream = File.Open(zipPath, FileMode.Create))
                    using (Archive zipArchive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
                    {
                        // Iterate through each entry in the RAR archive
                        foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                        {
                            // Open entry stream from RAR
                            using (Stream entryStream = rarEntry.Open())
                            {
                                // Add entry to ZIP archive with the same name
                                zipArchive.CreateEntry(rarEntry.Name, entryStream);
                            }
                        }

                        // Save ZIP archive to file
                        zipArchive.Save(zipStream, new ArchiveSaveOptions());
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
 * 1. When a company needs to migrate legacy RAR backups to ZIP for compatibility with Windows tools while preserving original file sizes.
 * 2. When an application must batch‑process a list of RAR files and create ZIP versions for distribution without re‑compressing the data to save CPU time.
 * 3. When a developer wants to automate the conversion of user‑uploaded RAR archives to ZIP so that downstream services that only accept ZIP can handle them.
 * 4. When a backup system stores archives in RAR format and requires a quick conversion to ZIP for archival storage on cloud platforms that favor ZIP containers.
 * 5. When a data‑processing pipeline needs to extract entries from multiple RAR files and re‑package them as uncompressed ZIP archives for fast random access.
 */
