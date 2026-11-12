// HOW-TO: Create ZIP With Uncompressed And AES‑Encrypted Files In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath1 = "data/file1.txt";
            string inputPath2 = "data/file2.txt";
            string outputPath = "output/mixed.zip";

            // Verify input files exist
            if (!File.Exists(inputPath1))
            {
                Console.Error.WriteLine($"File not found: {inputPath1}");
                return;
            }
            if (!File.Exists(inputPath2))
            {
                Console.Error.WriteLine($"File not found: {inputPath2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Open source files
            using (FileStream sourceStream1 = File.Open(inputPath1, FileMode.Open, FileAccess.Read))
            using (FileStream sourceStream2 = File.Open(inputPath2, FileMode.Open, FileAccess.Read))
            // Create the ZIP archive
            using (Archive archive = new Archive())
            {
                // Create a stored (uncompressed) entry without encryption
                ArchiveEntrySettings storedSettings = new ArchiveEntrySettings(new StoreCompressionSettings());
                archive.CreateEntry("file1.txt", sourceStream1, storedSettings);

                // Create a stored entry with AES‑256 encryption
                AesEcryptionSettings aesSettings = new AesEcryptionSettings("Password123", EncryptionMethod.AES256);
                ArchiveEntrySettings encryptedSettings = new ArchiveEntrySettings(new StoreCompressionSettings(), aesSettings);
                archive.CreateEntry("file2.txt", sourceStream2, encryptedSettings);

                // Save the archive to the output file
                using (FileStream zipFile = File.Open(outputPath, FileMode.Create))
                {
                    archive.Save(zipFile);
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
 * 1. When you need to package log files for quick access while encrypting confidential configuration files in the same archive.
 * 2. When distributing a software bundle that includes a readable license file and a protected API key file together.
 * 3. When backing up large media assets uncompressed for fast restore but securing personal data with AES‑256 encryption.
 * 4. When sending mixed content over a network where some documents must remain instantly viewable and others must be password‑protected.
 * 5. When complying with data‑privacy regulations that require certain files to be encrypted while keeping other files stored without compression for compatibility.
 */
