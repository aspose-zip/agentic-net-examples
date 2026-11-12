// HOW-TO: Build 7z Archive from Folder and Assign Different Passwords per File in C# (Aspose.ZIP for .NET)
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
            string inputDirectory = @"C:\InputFolder";
            string outputArchivePath = @"C:\Output\archive.7z";

            if (!Directory.Exists(inputDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {inputDirectory}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            string[] files = Directory.GetFiles(inputDirectory);
            if (files.Length == 0)
            {
                Console.Error.WriteLine($"No files found in directory: {inputDirectory}");
                return;
            }

            // Use the first three files (or fewer if less are available) with different passwords
            int count = Math.Min(3, files.Length);
            string[] passwords = new string[] { "Password1", "Password2", "Password3" };

            using (FileStream archiveStream = File.Open(outputArchivePath, FileMode.Create))
            using (SevenZipArchive archive = new SevenZipArchive())
            {
                for (int i = 0; i < count; i++)
                {
                    string filePath = files[i];
                    if (!File.Exists(filePath))
                    {
                        Console.Error.WriteLine($"File not found: {filePath}");
                        continue;
                    }

                    FileInfo fileInfo = new FileInfo(filePath);
                    string entryName = Path.GetFileName(filePath);
                    string entryPassword = passwords[i];

                    SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(
                        new SevenZipStoreCompressionSettings(),
                        new SevenZipAESEncryptionSettings(entryPassword)
                    );

                    archive.CreateEntry(entryName, fileInfo, false, entrySettings);
                }

                archive.Save(archiveStream);
            }

            Console.WriteLine($"7z archive created at: {outputArchivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a set of confidential documents and want each file protected with its own password in a single 7z package.
 * 2. When an application must programmatically archive logs from a directory while applying unique passwords to comply with security policies.
 * 3. When a backup utility creates encrypted 7z archives and requires different passwords for individual backup files to limit access.
 * 4. When a SaaS platform generates downloadable bundles where each component must be unlocked separately by different users.
 * 5. When a DevOps script automates packaging of deployment assets and needs per‑file encryption to meet regulatory standards.
 */
