// HOW-TO: Split Large 7z Archive into 30 MB Parts Using Aspose.Zip for .NET (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = @"C:\Archives\large.7z";
            string outputFolder = @"C:\Archives\SplitOutput";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFolder) ?? outputFolder);

            // Open the existing 7z archive
            using (SevenZipArchive archive = new SevenZipArchive(inputPath))
            {
                // Configure split options: base name for parts and 30 MB volume size
                SplitSevenZipArchiveSaveOptions splitOptions = new SplitSevenZipArchiveSaveOptions("large_split", 30 * 1024 * 1024);

                // Split the archive into volumes
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
 * 1. When you need to upload a huge 7z file to a service that limits each file to 30 MB, you can split the archive into smaller volumes before transfer.
 * 2. When distributing a large software package via email or removable media that only accepts files under a certain size, splitting the 7z archive ensures each part meets the size restriction.
 * 3. When storing backups on a cloud storage provider with per‑file size caps, you can break the 7z backup into 30 MB chunks to comply with the limits.
 * 4. When creating multi‑volume archives for incremental extraction on low‑memory devices, splitting the 7z file into manageable parts simplifies processing.
 * 5. When archiving large logs for compliance and need to retain a consistent naming scheme for each segment, the code generates sequentially named 30 MB 7z parts automatically.
 */
