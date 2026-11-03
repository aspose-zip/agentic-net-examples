// HOW-TO: Convert ZIP Archive to 7z While Preserving Paths in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            // Validate input ZIP file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath) ?? ".");

            // Dictionary to hold entry data in memory
            Dictionary<string, byte[]> entryData = new Dictionary<string, byte[]>();

            // Open the ZIP archive and read all entries into memory
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    using (Stream entryStream = zipEntry.Open())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            entryStream.CopyTo(ms);
                            entryData[zipEntry.Name] = ms.ToArray();
                        }
                    }
                }
            }

            // List to keep MemoryStreams alive until the 7z archive is saved
            List<MemoryStream> openStreams = new List<MemoryStream>();

            // Create a new 7z archive and add entries from memory
            using (SevenZipArchive sevenZip = new SevenZipArchive())
            {
                foreach (KeyValuePair<string, byte[]> kvp in entryData)
                {
                    MemoryStream ms = new MemoryStream(kvp.Value);
                    openStreams.Add(ms);
                    sevenZip.CreateEntry(kvp.Key, ms);
                }

                // Save the 7z archive to the output file
                using (FileStream outStream = new FileStream(output7zPath, FileMode.Create, FileAccess.Write))
                {
                    sevenZip.Save(outStream);
                }
            }

            // Dispose all opened MemoryStreams
            foreach (MemoryStream ms in openStreams)
            {
                ms.Dispose();
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
 * 1. When you need to programmatically repackage a ZIP file as a 7z archive without writing intermediate files to disk.
 * 2. When you want to migrate legacy ZIP backups to a more efficient 7z format while keeping the original folder structure.
 * 3. When an application must read ZIP contents into memory for validation before creating a compressed 7z package.
 * 4. When you are building a cloud service that receives ZIP uploads and returns a 7z file without persisting temporary files.
 * 5. When you need to combine multiple in‑memory streams from a ZIP into a single 7z archive for secure distribution.
 */
