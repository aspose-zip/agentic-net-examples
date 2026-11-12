// HOW-TO: Batch Encrypt Multiple ZIP Files with AES‑256 Using a Common Password in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output directories
            string inputDirectory = @"C:\InputZips";
            string outputDirectory = @"C:\EncryptedZips";

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Common password for AES‑256 encryption
            string password = "StrongPassword123!";

            // Get all ZIP files in the input directory
            string[] zipFiles = Directory.GetFiles(inputDirectory, "*.zip");

            foreach (string zipPath in zipFiles)
            {
                // Verify the source file exists
                if (!File.Exists(zipPath))
                {
                    Console.Error.WriteLine($"File not found: {zipPath}");
                    continue;
                }

                // Determine output file path
                string fileNameWithoutExt = Path.GetFileNameWithoutExtension(zipPath);
                string encryptedZipPath = Path.Combine(outputDirectory, fileNameWithoutExt + "_enc.zip");

                // Ensure the directory for the output file exists
                Directory.CreateDirectory(Path.GetDirectoryName(encryptedZipPath));

                // Open the existing (unencrypted) archive
                using (Archive sourceArchive = new Archive(zipPath))
                {
                    // Create a new archive that will contain encrypted entries
                    using (FileStream outputStream = File.Open(encryptedZipPath, FileMode.Create))
                    {
                        using (Archive encryptedArchive = new Archive())
                        {
                            foreach (ArchiveEntry sourceEntry in sourceArchive.Entries)
                            {
                                // Read the source entry into a memory stream
                                using (MemoryStream entryData = new MemoryStream())
                                {
                                    using (Stream entryStream = sourceEntry.Open())
                                    {
                                        entryStream.CopyTo(entryData);
                                    }
                                    entryData.Position = 0;

                                    // Settings for AES‑256 encryption
                                    ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                                        null,
                                        new AesEcryptionSettings(password, EncryptionMethod.AES256));

                                    // Add the entry to the new archive with encryption
                                    encryptedArchive.CreateEntry(sourceEntry.Name, entryData, entrySettings);
                                }
                            }

                            // Save the encrypted archive to disk
                            encryptedArchive.Save(outputStream);
                        }
                    }
                }

                Console.WriteLine($"Encrypted archive created: {encryptedZipPath}");
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
 * 1. When you need to protect a collection of existing ZIP archives before sending them to clients, you can batch encrypt each file with AES‑256 and a shared password.
 * 2. When automating a nightly backup process that creates unencrypted ZIPs, you can secure all archives in one step by encrypting them with a strong password.
 * 3. When complying with data‑privacy regulations that require encrypted transmission of packaged documents, this code lets you quickly encrypt every ZIP in a folder.
 * 4. When distributing software installers that are packaged as ZIP files, you can add AES‑256 protection to each installer without manually opening them.
 * 5. When archiving sensitive logs that were originally stored as plain ZIPs, you can re‑encrypt the entire set with a common password for long‑term storage.
 */
