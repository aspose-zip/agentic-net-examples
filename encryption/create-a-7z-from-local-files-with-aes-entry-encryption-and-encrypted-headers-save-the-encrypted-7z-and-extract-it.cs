// HOW-TO: Create and Extract AES Encrypted Solid 7z Archive in C# (Aspose.ZIP for .NET)
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
            string sourceFolder = @"C:\Data\SourceFiles";
            string archivePath = @"C:\Data\Output\solidEncryptedArchive.7z";
            const string password = "P@ssw0rd";

            if (!Directory.Exists(sourceFolder))
            {
                Console.Error.WriteLine($"Directory not found: {sourceFolder}");
                return;
            }

            string outputDir = Path.GetDirectoryName(archivePath);
            Directory.CreateDirectory(outputDir);

            SevenZipLZMA2CompressionSettings compressionSettings = new SevenZipLZMA2CompressionSettings();
            SevenZipAESEncryptionSettings encryptionSettings = new SevenZipAESEncryptionSettings(password);
            SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(compressionSettings, encryptionSettings);
            entrySettings.Solid = true;

            using (SevenZipArchive archive = new SevenZipArchive(entrySettings))
            {
                archive.CreateEntries(sourceFolder);
                archive.Save(archivePath);
            }

            Console.WriteLine($"Solid encrypted 7z archive created at: {archivePath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to protect confidential files by compressing them into a single 7z archive with AES encryption and solid compression in a .NET application.
 * 2. When you must store backup data on disk and require both entry‑level encryption and encrypted headers to prevent unauthorized access.
 * 3. When a client application must generate a password‑protected 7z file that can be safely transferred over insecure networks.
 * 4. When an automated job has to archive logs daily, encrypt them with a known password, and later extract them programmatically for analysis.
 * 5. When you are building a secure file‑sharing feature that creates and reads encrypted 7z archives using a user‑supplied password in C#.
 */
