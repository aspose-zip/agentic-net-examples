// HOW-TO: Create 7z Archive With 60 MiB Split Volumes In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string sourceFolder = @"C:\Data\Source";
            string outputFolder = @"C:\Data\Output";

            // Verify source directory exists
            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFolder) ?? outputFolder);

            // Configure split options for 60 MiB volumes
            SplitSevenZipArchiveSaveOptions splitOptions = new SplitSevenZipArchiveSaveOptions("myArchive.7z", 60 * 1024 * 1024);

            using (SevenZipArchive archive = new SevenZipArchive())
            {
                // Add all files from the source folder to the archive
                string[] files = Directory.GetFiles(sourceFolder);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                // Save the archive as multivolume 7z files
                archive.SaveSplit(outputFolder, splitOptions);
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
 * 1. When you need to back up a large folder but must keep each 7z part under 60 MiB for email attachment limits.
 * 2. When distributing software updates on media that only supports files smaller than 64 MiB, you can split the archive into 60 MiB volumes.
 * 3. When archiving logs for regulatory compliance and the storage system requires fixed‑size chunks, this code creates multivolume 7z files.
 * 4. When uploading a big dataset to a cloud service that imposes a maximum file size, the split archive ensures each part fits the quota.
 * 5. When creating a portable backup that can be copied to USB drives with a 64 MiB file‑system limit, the code generates 7z volumes of 60 MiB each.
 */
