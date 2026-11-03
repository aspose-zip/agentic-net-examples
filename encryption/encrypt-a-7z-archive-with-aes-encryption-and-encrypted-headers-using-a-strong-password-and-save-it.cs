// HOW-TO: Create AES Encrypted 7z Archive With Encrypted Headers In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string sourceFolder = @"C:\Data\Source";
            string outputFolder = @"C:\Data\Output";
            string archivePath = Path.Combine(outputFolder, "EncryptedArchive.7z");
            const string password = "StrongPassword123!";

            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(archivePath));

            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();
            SevenZipAESEncryptionSettings encryptionSettings = new SevenZipAESEncryptionSettings(password);
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings, encryptionSettings)
            {
                Solid = true
            };

            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(sourceFolder);
                archive.Save(archivePath);
            }

            Console.WriteLine($"Encrypted 7z archive created at: {archivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer needs to securely back up confidential files by compressing them into a password‑protected 7z archive with AES encryption and hidden headers.
 * 2. When an application must transmit sensitive data over an untrusted network and wants to ensure the payload is both compressed and encrypted using a strong password.
 * 3. When a software solution must meet regulatory compliance that requires encrypted archives with solid compression for audit‑ready storage.
 * 4. When a developer wants to automate the creation of encrypted 7z packages for distributing proprietary resources to clients without exposing the contents.
 * 5. When a system needs to archive log files daily while preventing unauthorized access by encrypting the archive and its metadata with AES.
 */
