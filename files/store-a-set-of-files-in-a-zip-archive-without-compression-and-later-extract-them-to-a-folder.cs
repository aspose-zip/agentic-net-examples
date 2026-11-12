// HOW-TO: Create Uncompressed ZIP Archive and Extract Files Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input file paths
            string inputPath1 = @"C:\Data\input1.txt";
            string inputPath2 = @"C:\Data\input2.txt";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Hardcoded output ZIP path
            string zipPath = @"C:\Data\output.zip";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            // Create ZIP archive without compression
            using (FileStream zipFile = File.Open(zipPath, FileMode.Create))
            using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
            {
                FileInfo fi1 = new FileInfo(inputPath1);
                FileInfo fi2 = new FileInfo(inputPath2);

                archive.CreateEntry("input1.txt", fi1);
                archive.CreateEntry("input2.txt", fi2);

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions()
                {
                    Encoding = Encoding.ASCII
                };
                archive.Save(zipFile, saveOptions);
            }

            // Hardcoded extraction folder
            string extractFolder = @"C:\Data\Extracted";

            // Ensure extraction directory exists
            Directory.CreateDirectory(extractFolder);

            // Extract the ZIP archive to the folder
            using (FileStream zipRead = File.Open(zipPath, FileMode.Open))
            using (Archive archive = new Archive(zipRead))
            {
                archive.ExtractToDirectory(extractFolder);
            }

            Console.WriteLine("Files stored without compression and extracted successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle log files for quick transfer without increasing size, you can store them in an uncompressed ZIP and later extract them to a processing folder.
 * 2. When deploying configuration files to multiple servers, you can create a plain ZIP archive that preserves original file sizes and then extract it on each target machine using C#.
 * 3. When archiving large binary assets that are already compressed, such as images or videos, you can use Store compression to avoid double‑compression and extract them when needed.
 * 4. When implementing a backup routine that must keep files in their original form for regulatory compliance, you can create an uncompressed ZIP and restore the files to a specified directory.
 * 5. When building a .NET utility that packages temporary reports for a user and then unpacks them for further analysis, you can use Aspose.Zip to create and extract the archive without altering file content.
 */
