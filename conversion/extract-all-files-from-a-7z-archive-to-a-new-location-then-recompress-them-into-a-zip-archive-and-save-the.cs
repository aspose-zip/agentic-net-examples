// HOW-TO: Extract 7z Archive and Convert to ZIP File in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string sevenZipPath = "C:\\Data\\sample.7z";
            string extractDir = "C:\\Data\\Extracted";
            string zipOutputPath = "C:\\Data\\converted.zip";

            // Verify the 7z archive exists
            if (!File.Exists(sevenZipPath))
            {
                Console.Error.WriteLine($"File not found: {sevenZipPath}");
                return;
            }

            // Ensure the extraction directory exists
            Directory.CreateDirectory(extractDir);

            // Extract all entries from the 7z archive
            using (SevenZipArchive sevenArchive = new SevenZipArchive(sevenZipPath))
            {
                sevenArchive.ExtractToDirectory(extractDir);
            }

            // Ensure the output directory for the ZIP file exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipOutputPath));

            // Create a new ZIP archive from the extracted files
            using (Archive zipArchive = new Archive())
            {
                // Add all files from the extraction folder
                zipArchive.CreateEntries(extractDir);

                // Save the ZIP archive to the specified path
                using (FileStream zipFileStream = File.Open(zipOutputPath, FileMode.Create))
                {
                    zipArchive.Save(zipFileStream, new ArchiveSaveOptions());
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
 * 1. When you need to unpack a 7z package received from a client and re‑archive its contents as a standard ZIP for compatibility with Windows tools.
 * 2. When migrating legacy backup files stored in 7z format to a ZIP format that can be opened directly in .NET applications without additional plugins.
 * 3. When automating a workflow that extracts reports from a 7z archive, processes them, and then bundles the results into a ZIP for distribution.
 * 4. When integrating Aspose.Zip into a C# service that converts user‑uploaded 7z archives into ZIP files before storing them in a cloud repository.
 * 5. When creating a batch job that normalizes mixed archive types by extracting all files from a 7z archive and recompressing them into a single ZIP for archiving policies.
 */
