// HOW-TO: Convert ZIP Archive To 7z With LZMA2 Compression In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file and output 7z file paths
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            // Verify input ZIP file exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(output7zPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Open the source ZIP archive
            using (Archive zipArchive = new Archive(inputZipPath))
            {
                // Create a new 7z archive with LZMA2 compression for all entries
                using (SevenZipArchive sevenArchive = new SevenZipArchive(
                    new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings())))
                {
                    // Iterate through each entry in the ZIP archive
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        // Read entry content into a memory stream
                        using (MemoryStream entryData = new MemoryStream())
                        {
                            using (Stream entryStream = zipEntry.Open())
                            {
                                entryStream.CopyTo(entryData);
                            }
                            entryData.Position = 0;

                            // Add the entry to the 7z archive using the same entry name
                            sevenArchive.CreateEntry(zipEntry.Name, entryData);
                        }
                    }

                    // Save the 7z archive to the specified output path
                    sevenArchive.Save(output7zPath);
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
 * 1. When you need to migrate legacy ZIP files to a more efficient 7z format for reduced storage size.
 * 2. When you want to programmatically re‑compress archived data using LZMA2 without writing intermediate files to disk.
 * 3. When an application must bundle extracted ZIP contents into a single 7z package for secure distribution.
 * 4. When you need to read entries from a ZIP, process them in memory, and create a high‑ratio 7z archive for backup purposes.
 * 5. When automating a workflow that converts user‑uploaded ZIP uploads into 7z archives to standardize archive handling.
 */
