// HOW-TO: Extract RAR to Temporary Folder and Convert to 7z in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string rarPath = @"C:\Temp\sample.rar";
            string tempExtractDir = Path.Combine(Path.GetTempPath(), "RarExtracted");
            string sevenZipPath = @"C:\Temp\converted.7z";

            // Validate input RAR file
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            // Ensure extraction directory exists
            Directory.CreateDirectory(tempExtractDir);

            // Extract RAR archive to temporary folder
            using (FileStream rarStream = File.OpenRead(rarPath))
            {
                using (RarArchive rarArchive = new RarArchive(rarStream))
                {
                    rarArchive.ExtractToDirectory(tempExtractDir);
                }
            }

            // Ensure output directory for the 7z file exists
            Directory.CreateDirectory(Path.GetDirectoryName(sevenZipPath));

            // Create a 7z archive from the extracted folder
            using (SevenZipArchive sevenZip = new SevenZipArchive())
            {
                // Add all files from the temporary folder
                sevenZip.CreateEntries(tempExtractDir);
                // Save the 7z archive
                sevenZip.Save(sevenZipPath);
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
 * 1. When you need to unpack a downloaded RAR package, re‑compress its contents into a 7z archive for smaller size before storing it on a server.
 * 2. When a legacy system supplies data only in RAR format but your workflow requires 7z archives for downstream processing.
 * 3. When automating a backup script that extracts RAR logs to a temporary directory, then bundles them into a 7z file for long‑term archival.
 * 4. When migrating user‑generated RAR uploads to a cloud storage solution that only accepts 7z files.
 * 5. When integrating a file‑conversion service that must read a RAR archive, extract its files, and deliver a single 7z package to the client.
 */
