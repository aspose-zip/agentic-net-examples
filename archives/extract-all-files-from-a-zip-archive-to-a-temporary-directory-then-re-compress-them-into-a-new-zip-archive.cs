// HOW-TO: Extract ZIP to Temporary Folder and Re‑Compress to New ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputZipPath = "C:\\Temp\\input.zip";
            string tempExtractDir = "C:\\Temp\\ExtractedFiles";
            string outputZipPath = "C:\\Temp\\output.zip";

            // Validate input file
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure temporary extraction directory exists
            Directory.CreateDirectory(tempExtractDir);

            // Extract all entries to the temporary directory
            using (FileStream zipReadStream = File.Open(inputZipPath, FileMode.Open))
            {
                using (Archive archive = new Archive(zipReadStream))
                {
                    archive.ExtractToDirectory(tempExtractDir);
                }
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Re-compress extracted files into a new ZIP archive
            using (Archive newArchive = new Archive())
            {
                newArchive.CreateEntries(new DirectoryInfo(tempExtractDir));
                using (FileStream zipWriteStream = File.Open(outputZipPath, FileMode.Create))
                {
                    newArchive.Save(zipWriteStream);
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
 * 1. When you need to unpack a received ZIP, modify its contents, and then create a fresh archive for distribution.
 * 2. When a build pipeline must validate or reorganize files from an incoming ZIP before packaging them into a deployment bundle.
 * 3. When you want to extract log files from an archive, process them, and re‑zip the cleaned logs for archival storage.
 * 4. When a migration tool has to read a legacy ZIP, restructure the directory layout, and generate a new ZIP compatible with the target system.
 * 5. When an application must temporarily stage files from a ZIP on disk, apply security scanning, and then re‑compress the safe files into a new archive.
 */
