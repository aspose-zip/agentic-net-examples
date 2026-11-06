// HOW-TO: Extract Multiple ZIP Files, Merge Entries, and Create a 7z Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string[] zipPaths = { "C:\\Data\\zip1.zip", "C:\\Data\\zip2.zip" };
            string outputPath = "C:\\Data\\combined.7z";

            foreach (string zipPath in zipPaths)
            {
                if (!File.Exists(zipPath))
                {
                    Console.Error.WriteLine($"File not found: {zipPath}");
                    return;
                }
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            Dictionary<string, byte[]> combinedEntries = new Dictionary<string, byte[]>(StringComparer.OrdinalIgnoreCase);

            string GetUniqueName(string baseName)
            {
                string name = baseName;
                int counter = 1;
                while (combinedEntries.ContainsKey(name))
                {
                    name = $"{Path.GetFileNameWithoutExtension(baseName)}_dup{counter}{Path.GetExtension(baseName)}";
                    counter++;
                }
                return name;
            }

            foreach (string zipPath in zipPaths)
            {
                using (Archive zipArchive = new Archive(zipPath))
                {
                    foreach (ArchiveEntry entry in zipArchive.Entries)
                    {
                        if (entry.IsDirectory)
                        {
                            continue;
                        }

                        using (Stream entryStream = entry.Open())
                        {
                            using (MemoryStream ms = new MemoryStream())
                            {
                                entryStream.CopyTo(ms);
                                byte[] data = ms.ToArray();

                                string entryName = entry.Name;
                                if (combinedEntries.ContainsKey(entryName))
                                {
                                    entryName = GetUniqueName(entryName);
                                }

                                combinedEntries.Add(entryName, data);
                            }
                        }
                    }
                }
            }

            using (SevenZipArchive sevenZip = new SevenZipArchive())
            {
                foreach (KeyValuePair<string, byte[]> kvp in combinedEntries)
                {
                    using (MemoryStream ms = new MemoryStream(kvp.Value))
                    {
                        sevenZip.CreateEntry(kvp.Key, ms);
                    }
                }

                sevenZip.Save(outputPath);
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
 * 1. When you need to combine files from several ZIP backups into a single compressed 7z package without losing any files.
 * 2. When you must read ZIP archives into memory, resolve duplicate filenames, and produce a consolidated archive for distribution.
 * 3. When an application processes user‑uploaded ZIP bundles and needs to generate a single 7z file for download.
 * 4. When you want to programmatically extract ZIP contents, handle name collisions automatically, and store the result in a high‑ratio 7z archive.
 * 5. When you are building a deployment tool that merges resources from multiple ZIP modules into one compressed archive.
 */
