// HOW-TO: Create ZIP From Multiple Files And Extract It Instantly In C# (Aspose.ZIP for .NET)
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
            // Define input files
            string dataDir = "Data";
            string inputFile1 = Path.Combine(dataDir, "file1.txt");
            string inputFile2 = Path.Combine(dataDir, "file2.txt");
            string inputFile3 = Path.Combine(dataDir, "file3.txt");

            // Verify input files exist
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
            if (!File.Exists(inputFile3))
            {
                Console.Error.WriteLine($"File not found: {inputFile3}");
                return;
            }

            // Define output ZIP path and ensure directory exists
            string zipPath = Path.Combine("Output", "archive.zip");
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            // Create ZIP archive with multiple files
            using (FileStream zipFile = File.Open(zipPath, FileMode.Create))
            using (FileStream source1 = File.Open(inputFile1, FileMode.Open, FileAccess.Read))
            using (FileStream source2 = File.Open(inputFile2, FileMode.Open, FileAccess.Read))
            using (FileStream source3 = File.Open(inputFile3, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive())
            {
                archive.CreateEntry("file1.txt", source1);
                archive.CreateEntry("file2.txt", source2);
                archive.CreateEntry("file3.txt", source3);

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions()
                {
                    Encoding = Encoding.ASCII,
                    ArchiveComment = "Sample archive created with Aspose.Zip"
                };

                archive.Save(zipFile, saveOptions);
            }

            // Define extraction directory and ensure it exists
            string extractDir = Path.Combine("Output", "Extracted");
            Directory.CreateDirectory(extractDir);

            // Decompress the created ZIP archive
            using (FileStream zipRead = File.Open(zipPath, FileMode.Open))
            using (Archive archive = new Archive(zipRead))
            {
                // Extract all entries to the extraction directory
                archive.ExtractToDirectory(extractDir);
            }

            Console.WriteLine("Compression and extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to bundle several log files into a ZIP archive before sending them over a network and then verify the archive by extracting it immediately.
 * 2. When an application must generate a compressed backup of user‑generated documents and confirm the backup integrity by decompressing it in the same process.
 * 3. When a build pipeline creates a ZIP of compiled assets and then unpacks it to a staging folder for further testing.
 * 4. When a service archives temporary data files, then reads them back right away to process their contents without storing the archive long‑term.
 * 5. When a desktop tool packages selected reports into a ZIP file and then displays the extracted files to the user for preview.
 */
