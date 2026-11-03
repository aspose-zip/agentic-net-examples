// HOW-TO: Convert Password Protected ZIP Folder to 7z Archive in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path and password
            string zipPath = "input.zip";
            string zipPassword = "Secret123";

            // Folder inside the ZIP to extract (include trailing slash)
            string folderInZip = "Data/";

            // Temporary folder for extracted files
            string tempExtractPath = "tempExtracted";

            // Output 7z archive path
            string sevenZipPath = "output.7z";

            // Validate input ZIP file exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure temporary extraction directory exists
            Directory.CreateDirectory(tempExtractPath);

            // Open the password‑protected ZIP archive
            using (Archive zipArchive = new Archive(zipPath, new ArchiveLoadOptions { DecryptionPassword = zipPassword }))
            {
                // Iterate through entries and extract those belonging to the specified folder
                foreach (ArchiveEntry entry in zipArchive.Entries)
                {
                    if (entry.Name.StartsWith(folderInZip, StringComparison.OrdinalIgnoreCase))
                    {
                        // Compute relative path inside the folder
                        string relativePath = entry.Name.Substring(folderInZip.Length);
                        string destinationPath = Path.Combine(tempExtractPath, relativePath);

                        // Ensure destination directory exists
                        string destinationDir = Path.GetDirectoryName(destinationPath);
                        if (!string.IsNullOrEmpty(destinationDir))
                        {
                            Directory.CreateDirectory(destinationDir);
                        }

                        // Extract entry to the destination file
                        using (FileStream outStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                        {
                            entry.Extract(outStream);
                        }
                    }
                }
            }

            // Ensure output directory for the 7z archive exists
            string outputDir = Path.GetDirectoryName(sevenZipPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Create a new 7z archive and add the extracted folder contents
            using (SevenZipArchive sevenArchive = new SevenZipArchive())
            {
                // Add all files from the temporary extraction folder
                sevenArchive.CreateEntries(tempExtractPath);

                // Save the 7z archive to the specified path
                sevenArchive.Save(sevenZipPath);
            }

            // Optional: clean up temporary extraction folder
            // Directory.Delete(tempExtractPath, true);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to extract a specific directory from an encrypted ZIP file and repack it as a 7z archive for smaller size or compatibility with 7‑Zip tools.
 * 2. When automating a workflow that processes confidential data stored in password‑protected ZIPs and delivers the results in a high‑compression 7z package.
 * 3. When migrating legacy archives that are secured with passwords to a modern 7z format without manually handling each file.
 * 4. When building a C# application that must read a protected ZIP, extract only the required folder, and create a portable 7z bundle for distribution.
 * 5. When integrating Aspose.Zip into a backup system that decrypts ZIP backups, selects a subfolder, and stores it as a compressed 7z file on a server.
 */
