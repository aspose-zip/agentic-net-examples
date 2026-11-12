// HOW-TO: Convert ZIP to 7z with LZMA2 Compression for Selected Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

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

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Create a new 7z archive with LZMA2 compression (applied to added entries)
                using (SevenZipArchive sevenZip = new SevenZipArchive(
                    new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings())))
                {
                    // Iterate over each entry in the ZIP archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Skip directories
                        if (zipEntry.IsDirectory)
                            continue;

                        // Example selection: apply LZMA only to .txt files
                        if (!zipEntry.Name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                            continue;

                        // Read entry data into a memory buffer
                        using (MemoryStream entryData = new MemoryStream())
                        {
                            using (Stream entryStream = zipEntry.Open())
                            {
                                entryStream.CopyTo(entryData);
                            }
                            entryData.Position = 0; // Reset stream position for reading

                            // Add the buffered data as a new entry in the 7z archive
                            sevenZip.CreateEntry(zipEntry.Name, entryData);
                        }
                    }

                    // Save the 7z archive to the specified output path
                    sevenZip.Save(output7zPath);
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
 * 1. When you need to migrate a collection of text files from a ZIP archive to a 7z archive using LZMA2 compression to reduce size in a .NET application.
 * 2. When you want to programmatically extract specific entries from a ZIP file, compress them with high‑ratio LZMA2, and store the result as a 7z archive for efficient distribution.
 * 3. When an automated build process must convert generated ZIP packages into 7z format while applying compression only to .txt resources to meet storage quotas.
 * 4. When a cloud service needs to re‑package uploaded ZIP files into 7z archives, buffering entry data in memory to avoid temporary files and applying LZMA2 to selected file types.
 * 5. When a desktop utility must read a ZIP archive, filter out non‑text files, and create a compressed 7z archive using Aspose.Zip’s SevenZipArchive for faster download speeds.
 */
