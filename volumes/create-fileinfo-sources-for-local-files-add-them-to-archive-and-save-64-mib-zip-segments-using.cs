// HOW-TO: Create Multi-Volume ZIP of Local Files with 64 MiB Segments in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string dataDir = @"C:\Data\";
            string inputFile1 = Path.Combine(dataDir, "file1.txt");
            string inputFile2 = Path.Combine(dataDir, "file2.txt");
            string outputDir = @"C:\Output\MultiVolumeZip";

            // Validate input files
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(outputDir);
            Directory.CreateDirectory(Path.GetDirectoryName(outputDir));

            // Create archive and add entries from FileInfo sources
            using (Archive archive = new Archive())
            {
                FileInfo fi1 = new FileInfo(inputFile1);
                FileInfo fi2 = new FileInfo(inputFile2);

                archive.CreateEntry("file1.txt", fi1);
                archive.CreateEntry("file2.txt", fi2);

                // Configure split options: 64 MiB per segment
                SplitArchiveSaveOptions saveOptions = new SplitArchiveSaveOptions(64 * 1024 * 1024);

                // Save the archive as multivolume ZIP
                archive.SaveSplit(outputDir, saveOptions);
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
 * 1. When you need to back up several large text files and store them on a medium that only accepts files up to 64 MiB, you can split the ZIP into multiple volumes using this code.
 * 2. When an email system limits attachment size to 64 MiB, you can create a multi‑part ZIP archive so each part can be sent separately and reassembled by the recipient.
 * 3. When deploying software updates that must be delivered on USB drives with a 64 MiB file‑size restriction, this approach creates split ZIP files that fit the drive’s constraints.
 * 4. When archiving log files for long‑term retention and you want each archive segment to be a manageable size for cloud storage APIs that cap individual object size, the code generates the required split archives.
 * 5. When implementing a custom backup solution that writes archives directly from FileInfo objects and needs to limit each archive chunk to a specific size for incremental processing, this snippet provides the necessary split‑save functionality.
 */
