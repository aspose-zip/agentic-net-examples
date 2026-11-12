// HOW-TO: Extract Password Protected ZIP and Recompress With Bzip2 in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string inputPath = "input.zip";
            string outputPath = "output.zip";
            string extractDir = "extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            // Ensure extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Load the password‑protected ZIP archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions()
            {
                DecryptionPassword = "password123"
            };
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Extract all entries to a temporary folder
                archive.ExtractToDirectory(extractDir);
            }

            // Re‑compress extracted contents with custom compression (Bzip2)
            using (FileStream outStream = File.Open(outputPath, FileMode.Create))
            using (Archive newArchive = new Archive(new ArchiveEntrySettings(new Bzip2CompressionSettings())))
            {
                // Add all files from the extraction folder
                DirectoryInfo dirInfo = new DirectoryInfo(extractDir);
                newArchive.CreateEntries(dirInfo);
                // Save the new archive
                newArchive.Save(outStream);
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
 * 1. When you need to programmatically open a secured ZIP file, extract its contents, and then create a new archive using a more efficient Bzip2 compression for storage or transmission.
 * 2. When an application must process confidential user uploads that arrive as password‑protected ZIPs and re‑package the data in a format that reduces bandwidth usage.
 * 3. When a backup system extracts encrypted archives on a server and recompresses the files with Bzip2 to meet retention policies that require specific compression ratios.
 * 4. When a migration tool reads legacy ZIP archives protected with passwords, extracts the files, and creates new Bzip2‑compressed archives compatible with modern deployment pipelines.
 * 5. When a data‑processing workflow needs to automatically decrypt incoming ZIP packages, manipulate the extracted files, and output a single Bzip2 archive for downstream analytics.
 */
