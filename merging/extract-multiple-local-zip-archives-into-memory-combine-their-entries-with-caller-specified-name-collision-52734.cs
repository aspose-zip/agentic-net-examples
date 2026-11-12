// HOW-TO: Combine Multiple ZIP Files Into a Single TAR.GZ With Collision Handling In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Tar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file paths
            string[] zipPaths = new string[]
            {
                @"C:\Input\archive1.zip",
                @"C:\Input\archive2.zip"
            };

            // Hardcoded output TAR.GZ path
            string outputPath = @"C:\Output\combined.tar.gz";

            // Validate input files
            foreach (string zipPath in zipPaths)
            {
                if (!File.Exists(zipPath))
                {
                    Console.Error.WriteLine($"File not found: {zipPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Collision handling mode: Overwrite, Skip, or Rename
            const string handling = "Rename";

            // Store entry data in memory
            Dictionary<string, MemoryStream> entryData = new Dictionary<string, MemoryStream>(StringComparer.OrdinalIgnoreCase);
            int renameCounter = 0;

            foreach (string zipPath in zipPaths)
            {
                using (Archive zipArchive = new Archive(zipPath))
                {
                    foreach (ArchiveEntry entry in zipArchive.Entries)
                    {
                        if (entry.IsDirectory)
                            continue;

                        string entryName = entry.Name;

                        if (entryData.ContainsKey(entryName))
                        {
                            if (handling == "Overwrite")
                            {
                                entryData[entryName].Dispose();
                                entryData.Remove(entryName);
                            }
                            else if (handling == "Skip")
                            {
                                continue;
                            }
                            else if (handling == "Rename")
                            {
                                string baseName = Path.GetFileNameWithoutExtension(entryName);
                                string ext = Path.GetExtension(entryName);
                                string dir = Path.GetDirectoryName(entryName);
                                string newName;
                                do
                                {
                                    renameCounter++;
                                    newName = Path.Combine(dir ?? string.Empty, $"{baseName}_{renameCounter}{ext}");
                                } while (entryData.ContainsKey(newName));
                                entryName = newName;
                            }
                        }

                        MemoryStream ms = new MemoryStream();
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.CopyTo(ms);
                        }
                        ms.Position = 0;
                        entryData[entryName] = ms;
                    }
                }
            }

            // Create TAR archive and add entries
            using (TarArchive tar = new TarArchive())
            {
                foreach (KeyValuePair<string, MemoryStream> kvp in entryData)
                {
                    tar.CreateEntry(kvp.Key, kvp.Value);
                }

                // Save as gzipped TAR
                tar.SaveGzipped(outputPath);
            }

            // Dispose memory streams
            foreach (MemoryStream ms in entryData.Values)
            {
                ms.Dispose();
            }

            Console.WriteLine("Combined TAR.GZ archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to merge several ZIP archives from different sources into one compressed TAR.GZ for distribution while controlling how duplicate file names are resolved.
 * 2. When you want to extract the contents of multiple ZIP files into memory to process or modify them before creating a unified archive without writing intermediate files to disk.
 * 3. When your application must combine backup archives and ensure that files with the same path are either overwritten, skipped, or renamed according to a policy you define.
 * 4. When you are building a deployment package that gathers assets from several ZIP bundles and packages them into a gzip‑compressed TAR for Linux‑based servers.
 * 5. When you need to programmatically create a single .tar.gz archive from many ZIP inputs while handling name collisions in a .NET environment using Aspose.Zip.
 */
