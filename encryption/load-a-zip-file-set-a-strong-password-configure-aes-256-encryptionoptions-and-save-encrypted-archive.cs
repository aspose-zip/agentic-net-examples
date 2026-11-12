// HOW-TO: Encrypt A Zip Archive With AES‑256 Password Protection In C# (Aspose.ZIP for .NET)
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
            // Hardcoded input file and output zip paths
            string inputFilePath = "data/input.txt";
            string outputZipPath = "output/encrypted.zip";

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            // Open source file stream
            using (FileStream sourceStream = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            // Open output zip stream
            using (FileStream zipStream = File.Open(outputZipPath, FileMode.Create))
            {
                // Define a strong password and AES‑256 encryption settings
                string password = "Str0ngP@ssw0rd!2024";
                ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                    null,
                    new AesEcryptionSettings(password, EncryptionMethod.AES256));

                // Create a new archive with the encryption settings
                using (Archive archive = new Archive(entrySettings))
                {
                    // Add the input file as an entry
                    archive.CreateEntry(Path.GetFileName(inputFilePath), sourceStream);

                    // Save the encrypted archive
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
 * 1. When you need to securely share a confidential text file over email by creating an AES‑256 encrypted ZIP in C#.
 * 2. When your application must store sensitive configuration files on disk and protect them with a strong password.
 * 3. When compliance regulations require data at rest to be encrypted before archiving it in a .zip container.
 * 4. When you want to automate the creation of password‑protected backup archives for automated deployment pipelines.
 * 5. When a client requests that downloaded resources be delivered in an encrypted ZIP to prevent unauthorized access.
 */
