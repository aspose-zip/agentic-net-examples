// HOW-TO: Create Split 64 MiB 7z Archive from Local Files in C# (Aspose.ZIP for .NET)
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
            // Hardcoded source and output folders
            string sourceFolder = @"C:\Data\Input";
            string outputFolder = @"C:\Data\Output";

            // Input files to be added to the archive
            string file1Name = "file1.txt";
            string file2Name = "file2.txt";

            string file1Path = Path.Combine(sourceFolder, file1Name);
            if (!File.Exists(file1Path))
            {
                Console.Error.WriteLine($"File not found: {file1Path}");
                return;
            }

            string file2Path = Path.Combine(sourceFolder, file2Name);
            if (!File.Exists(file2Path))
            {
                Console.Error.WriteLine($"File not found: {file2Path}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputFolder);

            // Configure split options for 64 MiB volumes
            SplitSevenZipArchiveSaveOptions splitOptions = new SplitSevenZipArchiveSaveOptions(outputFolder, 64 * 1024 * 1024);

            // Create a new 7z archive and add entries
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                archive.CreateEntry(file1Name, new FileInfo(file1Path));
                archive.CreateEntry(file2Name, new FileInfo(file2Path));

                // Save the archive as split volumes
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
 * 1. When you need to package several large log files into a 7z archive that can be transferred over a network with a 64 MiB size limit.
 * 2. When you want to back up critical documents on a server and store them as split 7z volumes for easier storage on removable media.
 * 3. When an application must create a multi‑part archive for distribution, ensuring each part fits on a standard DVD or cloud chunk size.
 * 4. When you are implementing a custom backup routine that adds files using FileInfo objects and splits the archive to avoid exceeding file‑system file‑size restrictions.
 * 5. When you need to generate a segmented 7z archive for incremental upload to a web service that only accepts files up to 64 MiB each.
 */
