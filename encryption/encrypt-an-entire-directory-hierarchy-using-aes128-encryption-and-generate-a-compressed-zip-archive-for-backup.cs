// HOW-TO: Create AES128 Encrypted ZIP Backup of a Directory Tree in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input directory and output ZIP file paths
            string inputDirectory = @"C:\Data\BackupSource";
            string outputZipPath = @"C:\Data\Backup\backup.zip";

            // Verify input directory exists
            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Password for AES128 encryption
            string password = "MySecretPassword";

            // Create a new ZIP archive
            using (Archive archive = new Archive())
            {
                DirectoryInfo dirInfo = new DirectoryInfo(inputDirectory);

                // Recursively add all files with AES128 encryption
                foreach (FileInfo fileInfo in dirInfo.GetFiles("*", SearchOption.AllDirectories))
                {
                    // Compute the entry name relative to the input directory
                    string entryName = Path.GetRelativePath(inputDirectory, fileInfo.FullName).Replace('\\', '/');

                    // Open the source file stream
                    using (FileStream sourceStream = File.Open(fileInfo.FullName, FileMode.Open, FileAccess.Read))
                    {
                        // Define entry settings with AES128 encryption
                        ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                            null,
                            new AesEcryptionSettings(password, EncryptionMethod.AES128));

                        // Add the entry to the archive
                        archive.CreateEntry(entryName, sourceStream, entrySettings);
                    }
                }

                // Save the archive to the output ZIP file
                using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
                {
                    archive.Save(zipStream);
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
 * 1. When you need to securely back up a project's entire folder structure by creating a password‑protected ZIP file with AES128 encryption using C#.
 * 2. When you want to automate nightly backups of user data directories, ensuring the files are compressed and encrypted before being stored on a remote server.
 * 3. When you must comply with data‑privacy regulations that require archived files to be encrypted with strong AES encryption while preserving the original directory layout.
 * 4. When you are building a desktop utility that lets end‑users select a folder and generate an encrypted ZIP archive for safe transport or cloud storage.
 * 5. When you need to programmatically archive log files from multiple subfolders into a single encrypted ZIP to reduce storage space and protect sensitive information.
 */
