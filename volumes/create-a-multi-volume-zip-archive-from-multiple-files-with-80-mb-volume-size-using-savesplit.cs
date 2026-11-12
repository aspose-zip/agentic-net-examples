// HOW-TO: Create Multi-Volume Zip Archive With 80 MB Parts In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input files and output directory
            string dataDir = @"C:\Data\";
            string[] inputFiles = new string[]
            {
                dataDir + "file1.txt",
                dataDir + "file2.txt",
                dataDir + "file3.txt"
            };
            string outputDir = @"C:\Output\MultiVolumeZip";
            string outputPath = Path.Combine(outputDir, "archive.zip");

            // Verify each input file exists
            foreach (string inputPath in inputFiles)
            {
                if (!File.Exists(inputPath))
                {
                    Console.Error.WriteLine($"File not found: {inputPath}");
                    return;
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Create the archive and add entries
            using (Archive archive = new Archive())
            {
                foreach (string inputPath in inputFiles)
                {
                    string entryName = Path.GetFileName(inputPath);
                    archive.CreateEntry(entryName, new FileInfo(inputPath));
                }

                // Configure split options with 80 MB volume size
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(80 * 1024 * 1024);
                saveOptions.Encoding = Encoding.UTF8;

                // Save the archive as multi-volume ZIP
                archive.SaveSplit(outputDir, saveOptions);
            }

            Console.WriteLine("Multi-volume ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to back up several large log files but must keep each ZIP part under 80 MB to fit on removable media.
 * 2. When you want to distribute a software package via email or file‑sharing services that impose a maximum attachment size.
 * 3. When you are archiving data for archival storage systems that require fixed‑size volumes for tape or disk.
 * 4. When you need to create split archives so that users can download or copy each segment separately without exceeding bandwidth limits.
 * 5. When you are implementing a custom backup solution that splits the archive into manageable chunks for incremental restore.
 */
