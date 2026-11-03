// HOW-TO: Extract Encrypted RAR Files and Convert to ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string rarPath = "C:\\Data\\encrypted.rar";
            string rarPassword = "password123";
            string extractDir = "C:\\Data\\Extracted";
            string zipPath = "C:\\Data\\converted.zip";

            // Verify input RAR file exists
            if (!File.Exists(rarPath))
            {
                Console.Error.WriteLine($"File not found: {rarPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));
            Directory.CreateDirectory(extractDir);

            // Open RAR archive with decryption password and extract all entries
            using (FileStream rarStream = File.OpenRead(rarPath))
            {
                using (RarArchive rarArchive = new RarArchive(rarStream, new RarArchiveLoadOptions() { DecryptionPassword = rarPassword }))
                {
                    rarArchive.ExtractToDirectory(extractDir);
                }
            }

            // Create a new ZIP archive and add the extracted files
            using (Archive zipArchive = new Archive())
            {
                // Add entire folder tree to the ZIP
                zipArchive.CreateEntries(new DirectoryInfo(extractDir));

                // Save the ZIP archive to the specified path
                zipArchive.Save(zipPath);
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
 * 1. When you receive password‑protected RAR reports from a client and need to unpack them and deliver the contents as a standard ZIP file for downstream processing.
 * 2. When an automated ETL pipeline must decrypt archived logs, extract the files, and re‑compress them into a ZIP archive for storage in a cloud bucket.
 * 3. When migrating legacy backup archives that are encrypted RAR files into a modern ZIP format to ensure compatibility with current applications.
 * 4. When building a desktop utility that lets users select an encrypted RAR, extracts its files to a folder, and creates a single ZIP for easy sharing.
 * 5. When integrating Aspose.Zip in a C# service to programmatically handle encrypted RAR extraction and then archive the results as ZIP for compliance reporting.
 */
