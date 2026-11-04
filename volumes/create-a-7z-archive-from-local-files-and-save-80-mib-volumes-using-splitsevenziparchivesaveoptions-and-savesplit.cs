// HOW-TO: Create Multi‑Volume 7z Archive With 80 MiB Splits In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded paths
        string sourceFolder = @"C:\Data\Source";
        string outputFolder = @"C:\Data\Output";
        string outputArchiveName = "multivolume.7z";
        string outputArchivePath = Path.Combine(outputFolder, outputArchiveName);

        try
        {
            // Verify source folder exists
            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Configure split options: 80 MiB per volume
            SplitSevenZipArchiveSaveOptions splitOptions = new SplitSevenZipArchiveSaveOptions(outputArchiveName, 80 * 1024 * 1024);

            using (SevenZipArchive archive = new SevenZipArchive())
            {
                // Add each file from the source folder to the archive
                foreach (string filePath in Directory.GetFiles(sourceFolder))
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                // Save the archive as split volumes in the output folder
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
 * 1. When you need to package a large set of files for distribution over limited‑size media or network channels, you can create a split 7z archive with 80 MiB volumes in C#.
 * 2. When backing up a folder to cloud storage that imposes a maximum file size, generating multi‑volume 7z files ensures each part complies with the limit.
 * 3. When sending large logs or data dumps via email attachments that have size caps, splitting the 7z archive into 80 MiB chunks allows each email to stay under the threshold.
 * 4. When preparing data for archival on removable drives that support only 100 MiB files, creating split 7z volumes simplifies storage and later reconstruction.
 * 5. When automating a build pipeline that needs to compress build artifacts into manageable pieces for parallel upload, using SplitSevenZipArchiveSaveOptions in C# creates the required split archives.
 */
