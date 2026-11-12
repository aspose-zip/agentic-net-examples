// HOW-TO: Transfer ZIP Entries to 7z Archive and Add In-Memory File in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
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
            string zipInputPath = "input/input.zip";
            string sevenZipOutputPath = "output/output.7z";

            // Verify input ZIP file exists
            if (!File.Exists(zipInputPath))
            {
                Console.Error.WriteLine($"File not found: {zipInputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(sevenZipOutputPath));

            // List to hold in‑memory streams for ZIP entries
            List<Tuple<string, MemoryStream>> entryStreams = new List<Tuple<string, MemoryStream>>();

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(zipInputPath))
            {
                // Extract each entry into a memory stream
                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    using (Stream zipEntryStream = zipEntry.Open())
                    {
                        MemoryStream memory = new MemoryStream();
                        zipEntryStream.CopyTo(memory);
                        memory.Position = 0;
                        entryStreams.Add(Tuple.Create(zipEntry.Name, memory));
                    }
                }
            }

            // Create the destination 7z archive
            using (SevenZipArchive sevenZipArchive = new SevenZipArchive())
            {
                // Add the extracted entries to the 7z archive
                foreach (Tuple<string, MemoryStream> pair in entryStreams)
                {
                    sevenZipArchive.CreateEntry(pair.Item1, pair.Item2);
                }

                // Add an in‑memory file to the 7z archive
                string inMemoryFileName = "InMemory.txt";
                byte[] contentBytes = Encoding.UTF8.GetBytes("This is an in‑memory file.");
                using (MemoryStream inMemoryStream = new MemoryStream(contentBytes))
                {
                    sevenZipArchive.CreateEntry(inMemoryFileName, inMemoryStream);
                }

                // Save the 7z archive to disk
                using (FileStream outStream = File.Open(sevenZipOutputPath, FileMode.Create))
                {
                    sevenZipArchive.Save(outStream);
                }
            }

            // Dispose the temporary memory streams after saving
            foreach (Tuple<string, MemoryStream> pair in entryStreams)
            {
                pair.Item2.Dispose();
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
 * 1. When you need to migrate data from an existing ZIP package to a more efficient 7z archive while preserving the original file structure in a C# application.
 * 2. When you want to combine files extracted from a ZIP with additional generated content stored in memory into a single 7z archive for distribution.
 * 3. When a build pipeline must unpack a ZIP, re‑compress its contents into a 7z format, and embed configuration files without writing temporary files to disk.
 * 4. When an enterprise solution requires converting legacy ZIP backups into 7z archives to reduce storage costs and add supplemental logs created at runtime.
 * 5. When a cloud service processes uploaded ZIP files, extracts them in memory, and returns a compressed 7z package that includes both the original entries and a dynamically created report.
 */
