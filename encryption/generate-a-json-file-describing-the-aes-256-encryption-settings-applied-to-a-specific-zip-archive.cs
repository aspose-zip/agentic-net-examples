// HOW-TO: Create AES256 Encrypted ZIP and Export Settings to JSON in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;
using System.Text.Json;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputFilePath = "data\\sample.txt";
            string zipFilePath = "output\\encrypted.zip";
            string jsonFilePath = "output\\aes256settings.json";

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(zipFilePath));
            Directory.CreateDirectory(Path.GetDirectoryName(jsonFilePath));

            // Create AES‑256 encrypted ZIP archive
            using (FileStream sourceStream = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            using (FileStream zipStream = File.Open(zipFilePath, FileMode.Create))
            using (Archive archive = new Archive(new ArchiveEntrySettings(null, new AesEcryptionSettings("StrongPassword123", EncryptionMethod.AES256))))
            {
                // Add the file to the archive
                archive.CreateEntry(Path.GetFileName(inputFilePath), sourceStream);
                // Save the archive
                archive.Save(zipStream);
            }

            // Prepare JSON description of the encryption settings
            var settingsInfo = new
            {
                ArchivePath = zipFilePath,
                Password = "StrongPassword123",
                EncryptionMethod = "AES256"
            };

            // Serialize to JSON and write to file
            string jsonContent = JsonSerializer.Serialize(settingsInfo, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(jsonFilePath, jsonContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to securely distribute a confidential text file by packaging it into an AES‑256 encrypted ZIP archive and also provide a JSON file describing the encryption parameters for automated processing.
 * 2. When an application must generate password‑protected archives on the fly in C# and log the encryption method and password in a machine‑readable format for compliance auditing.
 * 3. When a backup utility creates encrypted ZIP backups of important documents and stores the encryption settings alongside the archive to simplify future decryption scripts.
 * 4. When a cloud service uploads encrypted ZIP files and needs to send accompanying metadata in JSON so that downstream services can verify the encryption algorithm and password without inspecting the archive.
 * 5. When developers are testing Aspose.Zip’s AES‑256 support and want to programmatically verify the applied settings by reading a generated JSON description of the archive’s security configuration.
 */
