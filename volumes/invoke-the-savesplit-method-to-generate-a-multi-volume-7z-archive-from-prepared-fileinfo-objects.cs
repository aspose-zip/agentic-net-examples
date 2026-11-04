// HOW-TO: Create Multi-Volume 7z Archive from Files Using SaveSplit in C# (Aspose.ZIP for .NET)
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
            string sourceFolder = @"C:\Temp\Data";
            string outputFolder = @"C:\Temp\Output";

            Directory.CreateDirectory(Path.GetDirectoryName(outputFolder));
            Directory.CreateDirectory(outputFolder);

            SplitSevenZipArchiveSaveOptions splitOptions = new SplitSevenZipArchiveSaveOptions("archive.7z", 1048576);

            using (SevenZipArchive archive = new SevenZipArchive())
            {
                string[] files = { "file1.txt", "file2.txt" };

                foreach (string fileName in files)
                {
                    string filePath = Path.Combine(sourceFolder, fileName);
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        return;
                    }

                    archive.CreateEntry(fileName, new FileInfo(filePath));
                }

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
 * 1. When you need to back up a large set of files into a split 7z archive that fits on removable media or limited-size storage devices.
 * 2. When distributing a software package that exceeds the maximum file size of an email attachment, you can create multi-volume 7z parts for easier transfer.
 * 3. When archiving log files that grow beyond a single archive limit, the SaveSplit method lets you generate sequential 7z volumes for incremental storage.
 * 4. When implementing a custom backup solution in C# that must create compressed archives compatible with standard 7‑Zip tools, you can use Aspose.Zip to produce split archives.
 * 5. When preparing data for cloud upload where each chunk must stay under a specific size threshold, the code creates size-limited 7z volumes automatically.
 */
