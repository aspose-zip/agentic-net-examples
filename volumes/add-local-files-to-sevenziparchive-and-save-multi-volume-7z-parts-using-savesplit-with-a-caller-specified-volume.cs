// HOW-TO: Create Multi-Volume 7z Archive from Local Files with Specified Size in C# (Aspose.ZIP for .NET)
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
            // Hardcoded source folder containing files to archive
            string sourceFolder = "input";
            // Hardcoded output folder for multivolume 7z parts
            string outputFolder = "output";

            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // List of files to add to the archive
            string[] filesToAdd = new string[]
            {
                Path.Combine(sourceFolder, "file1.txt"),
                Path.Combine(sourceFolder, "file2.txt")
            };

            using (SevenZipArchive archive = new SevenZipArchive())
            {
                foreach (string filePath in filesToAdd)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    // Add file to the archive; entry name is the file name only
                    archive.CreateEntry(Path.GetFileName(filePath), new FileInfo(filePath));
                }

                // Create split options: base archive name and volume size (10 MB)
                SplitSevenZipArchiveSaveOptions splitOptions = new SplitSevenZipArchiveSaveOptions("MultiVolumeArchive.7z", 10 * 1024 * 1024);

                // Save the archive as multivolume parts in the output folder
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
 * 1. When you need to package several log files into a split 7z archive so each part fits on a 10 MB USB drive.
 * 2. When distributing large software updates over email or cloud services that limit attachment size, you can create multi‑volume 7z parts using Aspose.Zip in C#.
 * 3. When backing up daily reports to a network share that enforces a maximum file size, you can split the archive into manageable chunks with SaveSplit.
 * 4. When automating archival of documents for compliance and the storage system requires fixed‑size archive segments, the code creates a SevenZipArchive and saves it as multi‑volume files.
 * 5. When integrating a C# application with Aspose.Zip to generate split 7z archives for incremental data transfer to remote servers.
 */
