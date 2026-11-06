// HOW-TO: Create Uncompressed ZIP then Add Parallel Compressed Entries in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory and files
            string inputDir = @"C:\Data\Input\";
            string file1Path = Path.Combine(inputDir, "file1.txt");
            string file2Path = Path.Combine(inputDir, "file2.txt");
            string file3Path = Path.Combine(inputDir, "file3.txt");
            string file4Path = Path.Combine(inputDir, "file4.txt");

            // Verify input files exist
            if (!File.Exists(file1Path))
            {
                Console.Error.WriteLine($"File not found: {file1Path}");
                return;
            }
            if (!File.Exists(file2Path))
            {
                Console.Error.WriteLine($"File not found: {file2Path}");
                return;
            }
            if (!File.Exists(file3Path))
            {
                Console.Error.WriteLine($"File not found: {file3Path}");
                return;
            }
            if (!File.Exists(file4Path))
            {
                Console.Error.WriteLine($"File not found: {file4Path}");
                return;
            }

            // Output paths
            string initialZipPath = @"C:\Data\Output\archive.zip";
            string updatedZipPath = @"C:\Data\Output\archive_updated.zip";

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(initialZipPath));
            Directory.CreateDirectory(Path.GetDirectoryName(updatedZipPath));

            // -------------------------------------------------
            // Step 1: Create a ZIP archive storing files without compression
            // -------------------------------------------------
            using (FileStream zipStream = File.Open(initialZipPath, FileMode.Create))
            {
                using (Archive archive = new Archive(new ArchiveEntrySettings(new StoreCompressionSettings())))
                {
                    archive.CreateEntry("file1.txt", new FileInfo(file1Path));
                    archive.CreateEntry("file2.txt", new FileInfo(file2Path));

                    ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                    saveOptions.Encoding = Encoding.ASCII;
                    archive.Save(zipStream, saveOptions);
                }
            }

            // -------------------------------------------------
            // Step 2: Open the existing archive and add additional entries
            // -------------------------------------------------
            using (Archive archive = new Archive(initialZipPath))
            {
                archive.CreateEntry("file3.txt", new FileInfo(file3Path));
                archive.CreateEntry("file4.txt", new FileInfo(file4Path));

                ArchiveSaveOptions saveOptions = new ArchiveSaveOptions();
                saveOptions.Encoding = Encoding.ASCII;

                using (FileStream outStream = File.Open(updatedZipPath, FileMode.Create))
                {
                    archive.Save(outStream, saveOptions);
                }
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
 * 1. When you need to generate a ZIP file that initially stores large log files without compression for fast write speed, then later add smaller configuration files compressed in parallel to reduce the final archive size.
 * 2. When an application must create an uncompressed archive for regulatory compliance and subsequently update it with compressed backup files using multi‑threaded processing to improve performance.
 * 3. When a data pipeline writes raw sensor data into a ZIP without compression to preserve integrity, and later appends processed results compressed in parallel to keep the archive compact.
 * 4. When a build system creates a staging ZIP with source files stored as‑is for quick access, then updates the same archive with compressed documentation files using parallel threads to speed up the update.
 * 5. When a cloud service needs to initially upload uncompressed user uploads to a ZIP and then efficiently add compressed metadata entries in parallel before final storage.
 */
