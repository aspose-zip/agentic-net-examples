// HOW-TO: Create Split ZIP Archive of Executable Files with 500KB Parts in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputDirectory = @"C:\InputBinaries";
            string outputDirectory = @"C:\OutputZip";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            Directory.CreateDirectory(outputDirectory);

            using (Archive archive = new Archive())
            {
                string[] files = Directory.GetFiles(inputDirectory);
                foreach (string filePath in files)
                {
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    string entryName = Path.GetFileName(filePath);
                    archive.CreateEntry(entryName, new FileInfo(filePath));
                }

                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions("bin", 500 * 1024);
                archive.SaveSplit(outputDirectory, saveOptions);
            }

            Console.WriteLine("Split ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute large binary installers over media that only supports files up to 500 KB, you can split them into multiple ZIP parts using this code.
 * 2. When backing up a collection of executable files to a removable drive with size limits, the split archive ensures each segment fits the drive’s capacity.
 * 3. When sending binaries via email attachments that have a maximum attachment size, the code creates smaller ZIP chunks that comply with the limit.
 * 4. When archiving binaries for cloud storage services that enforce per‑file size quotas, splitting the archive avoids exceeding those quotas.
 * 5. When preparing a set of executables for incremental download where each part must be under a specific size, this approach generates the required ZIP segments automatically.
 */
