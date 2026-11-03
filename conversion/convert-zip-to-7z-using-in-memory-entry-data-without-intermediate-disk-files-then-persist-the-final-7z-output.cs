// HOW-TO: Convert ZIP to 7z In Memory Without Temporary Files in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP and output 7z paths
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            // Validate input file existence
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath));

            // List to hold entry names and their in‑memory data
            List<Tuple<string, MemoryStream>> entryData = new List<Tuple<string, MemoryStream>>();

            // Open the source ZIP archive and read each entry into memory
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                {
                    // Open the entry stream for reading
                    using (Stream entryStream = zipEntry.Open())
                    {
                        MemoryStream memory = new MemoryStream();
                        entryStream.CopyTo(memory);
                        memory.Position = 0; // Reset position for later reading
                        entryData.Add(new Tuple<string, MemoryStream>(zipEntry.Name, memory));
                    }
                }
            }

            // Create a new 7z archive and add the in‑memory entries
            using (SevenZipArchive sevenZip = new SevenZipArchive())
            {
                foreach (Tuple<string, MemoryStream> item in entryData)
                {
                    // Add entry with its original name and data stream
                    sevenZip.CreateEntry(item.Item1, item.Item2);
                }

                // Save the 7z archive to the specified output path
                using (FileStream outStream = new FileStream(output7zPath, FileMode.Create, FileAccess.Write))
                {
                    sevenZip.Save(outStream);
                }
            }

            // Dispose all memory streams after the archive has been saved
            foreach (Tuple<string, MemoryStream> item in entryData)
            {
                item.Item2.Dispose();
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
 * 1. When you need to repackage a ZIP archive as a 7z file on a server but cannot write the intermediate files to disk due to security or performance constraints.
 * 2. When an application processes uploaded ZIP files and must deliver them as 7z archives to reduce download size while keeping everything in memory.
 * 3. When a cloud function or containerized microservice must transform archive formats without persisting temporary data to the file system.
 * 4. When you want to programmatically convert user‑provided ZIP content to 7z for archival storage while preserving the original entry names.
 * 5. When performing batch conversion of multiple ZIP archives to 7z in a high‑throughput pipeline that relies on streams to avoid I/O bottlenecks.
 */
