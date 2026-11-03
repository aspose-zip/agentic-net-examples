// HOW-TO: Convert ZIP Archive to 7z With PPMd Compression for Text Files in C# (Aspose.ZIP for .NET)
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
            string inputZipPath = "input.zip";
            string output7zPath = "output.7z";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(output7zPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            using (Archive zipArchive = new Archive(inputZipPath))
            {
                using (SevenZipArchive sevenZip = new SevenZipArchive())
                {
                    foreach (ArchiveEntry zipEntry in zipArchive.Entries)
                    {
                        using (MemoryStream entryData = new MemoryStream())
                        {
                            using (Stream entryStream = zipEntry.Open())
                            {
                                entryStream.CopyTo(entryData);
                            }
                            entryData.Position = 0;

                            SevenZipEntrySettings entrySettings;
                            if (zipEntry.Name.EndsWith(".txt", StringComparison.OrdinalIgnoreCase))
                            {
                                entrySettings = new SevenZipEntrySettings(new SevenZipPPMdCompressionSettings());
                            }
                            else
                            {
                                entrySettings = new SevenZipEntrySettings(new SevenZipLZMA2CompressionSettings());
                            }

                            sevenZip.CreateEntry(zipEntry.Name, entryData, entrySettings);
                        }
                    }

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
 * 1. When you need to migrate a collection of ZIP files to the more efficient 7z format while applying PPMd compression specifically to text documents.
 * 2. When you want to programmatically re‑compress existing ZIP entries into a single 7z archive, using LZMA2 for binary files and PPMd for .txt files to achieve optimal size.
 * 3. When an application must read each entry from a ZIP, buffer its data in memory, and then create a 7z archive without extracting files to disk.
 * 4. When you need to ensure the output 7z file is saved to a custom directory, creating the folder automatically if it does not exist.
 * 5. When you require error handling that checks for the source ZIP file’s existence before performing the conversion to avoid runtime failures.
 */
