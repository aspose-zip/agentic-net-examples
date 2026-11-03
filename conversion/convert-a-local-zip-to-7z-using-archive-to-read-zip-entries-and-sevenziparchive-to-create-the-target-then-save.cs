// HOW-TO: Convert A ZIP File To 7z Archive Using Aspose.Zip In C# (Aspose.ZIP for .NET)
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

            // Verify input ZIP exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(output7zPath));

            // List to hold temporary memory streams for entry data
            List<MemoryStream> entryDataStreams = new List<MemoryStream>();

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Create a new 7z archive instance
                using (SevenZipArchive sevenArchive = new SevenZipArchive())
                {
                    // Iterate over each entry in the ZIP archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Open the ZIP entry as a stream
                        using (Stream zipEntryStream = zipEntry.Open())
                        {
                            // Copy entry data into a memory stream (kept alive until Save)
                            MemoryStream ms = new MemoryStream();
                            zipEntryStream.CopyTo(ms);
                            ms.Position = 0;

                            // Add the memory stream to the list for later disposal
                            entryDataStreams.Add(ms);

                            // Create a corresponding entry in the 7z archive
                            sevenArchive.CreateEntry(zipEntry.Name, ms);
                        }
                    }

                    // Save the 7z archive to the specified output path
                    sevenArchive.Save(output7zPath);
                }
            }

            // Dispose all temporary memory streams
            foreach (MemoryStream ms in entryDataStreams)
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
 * 1. When you need to migrate existing ZIP backups to the higher‑compression 7z format for reduced storage size.
 * 2. When an application must deliver files to users in 7z because the target environment only supports that archive type.
 * 3. When you are consolidating multiple ZIP archives into a single 7z package for easier distribution.
 * 4. When you want to programmatically re‑compress archived data to meet corporate compression standards using C#.
 * 5. When automating a build pipeline that converts generated ZIP artifacts into 7z for faster upload to cloud storage.
 */
