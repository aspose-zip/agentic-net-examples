// HOW-TO: Create 7z Archive With Individual Entry Passwords And Extract In C# (Aspose.ZIP for .NET)
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
            string sourceFile1 = "file1.txt";
            string sourceFile2 = "file2.txt";
            string sourceFile3 = "file3.txt";
            string archivePath = "output.7z";

            // Verify source files exist
            if (!File.Exists(sourceFile1))
            {
                Console.Error.WriteLine($"File not found: {sourceFile1}");
                return;
            }
            if (!File.Exists(sourceFile2))
            {
                Console.Error.WriteLine($"File not found: {sourceFile2}");
                return;
            }
            if (!File.Exists(sourceFile3))
            {
                Console.Error.WriteLine($"File not found: {sourceFile3}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            // Create 7z archive with different passwords for each entry
            using (FileStream archiveStream = File.Open(archivePath, FileMode.Create))
            {
                FileInfo fi1 = new FileInfo(sourceFile1);
                FileInfo fi2 = new FileInfo(sourceFile2);
                FileInfo fi3 = new FileInfo(sourceFile3);

                using (SevenZipArchive archive = new SevenZipArchive())
                {
                    archive.CreateEntry("file1.txt", fi1, false,
                        new SevenZipEntrySettings(
                            new SevenZipStoreCompressionSettings(),
                            new SevenZipAESEncryptionSettings("pwd1")));

                    archive.CreateEntry("file2.txt", fi2, false,
                        new SevenZipEntrySettings(
                            new SevenZipStoreCompressionSettings(),
                            new SevenZipAESEncryptionSettings("pwd2")));

                    archive.CreateEntry("file3.txt", fi3, false,
                        new SevenZipEntrySettings(
                            new SevenZipStoreCompressionSettings(),
                            new SevenZipAESEncryptionSettings("pwd3")));

                    archive.Save(archiveStream);
                }
            }

            // Verify archive was created
            if (!File.Exists(archivePath))
            {
                Console.Error.WriteLine($"File not found: {archivePath}");
                return;
            }

            // Ensure extraction directory exists
            string extractDir = "extracted";
            Directory.CreateDirectory(extractDir);

            // Extract each entry using its corresponding password
            using (SevenZipArchive archive = new SevenZipArchive(archivePath))
            {
                foreach (var entry in archive.Entries)
                {
                    string password = entry.Name switch
                    {
                        "file1.txt" => "pwd1",
                        "file2.txt" => "pwd2",
                        "file3.txt" => "pwd3",
                        _ => null
                    };

                    if (password == null)
                        continue;

                    string outputPath = Path.Combine(extractDir, entry.Name);
                    entry.Extract(outputPath, password);
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
 * 1. When you need to protect each file in a 7z package with its own password while keeping the archive header unencrypted, such as distributing confidential documents to different recipients.
 * 2. When you want to programmatically generate a 7z file where each entry uses a separate AES password and later extract them automatically using the corresponding passwords in a .NET application.
 * 3. When you must comply with security policies that require per‑file encryption without exposing the archive’s file list, enabling selective access to files inside a single archive.
 * 4. When building a backup tool that stores multiple files in one 7z archive but assigns unique passwords to each file for granular restoration control.
 * 5. When creating a software installer that bundles several components in a 7z archive, each protected by a different password, and the installer extracts each component using its specific password.
 */
