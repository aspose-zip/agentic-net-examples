// HOW-TO: Extract RAR Files to Memory Streams and Create ZIP Preserving Folder Structure in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string dataDir = "C:\\Data\\";
            string rarPath = dataDir + "sample.rar";
            string zipPath = dataDir + "output.zip";

            // Validate input RAR file
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            // Create a new ZIP archive in memory
            using (Archive zipArchive = new Archive())
            {
                // Open the RAR archive for reading
                using (FileStream rarStream = File.OpenRead(rarPath))
                {
                    using (RarArchive rarArchive = new RarArchive(rarStream))
                    {
                        // Iterate over each entry in the RAR archive
                        foreach (RarArchiveEntry rarEntry in rarArchive.Entries)
                        {
                            // Skip directories; file entries will create necessary folders in ZIP
                            if (rarEntry.IsDirectory)
                            {
                                continue;
                            }

                            // Extract the RAR entry into a memory stream
                            using (MemoryStream entryStream = new MemoryStream())
                            {
                                rarEntry.Extract(entryStream);
                                entryStream.Position = 0; // Reset stream position before adding to ZIP

                                // Add the entry to the ZIP archive preserving its full path
                                zipArchive.CreateEntry(rarEntry.Name, entryStream);
                            }
                        }
                    }
                }

                // Save the resulting ZIP archive to disk
                zipArchive.Save(zipPath);
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
 * 1. When you need to convert a downloaded RAR archive into a ZIP file without writing intermediate files to disk.
 * 2. When you want to programmatically read files from a RAR archive, keep them in memory for further processing, and then package them into a ZIP.
 * 3. When you must preserve the original directory hierarchy of a RAR archive while creating a ZIP for compatibility with ZIP‑only systems.
 * 4. When you are building a web service that receives RAR uploads, extracts their contents in memory, and returns a single ZIP response.
 * 5. When you need to migrate legacy RAR backups to ZIP format in an automated C# workflow while minimizing I/O overhead.
 */
