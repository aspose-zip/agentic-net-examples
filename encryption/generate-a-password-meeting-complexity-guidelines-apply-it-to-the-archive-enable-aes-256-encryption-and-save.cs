// HOW-TO: Create AES‑256 Encrypted ZIP With Complex Password In C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string dataDir = "C:\\Data\\";
            string inputFilePath = dataDir + "sample.txt";
            string outputFilePath = dataDir + "encrypted.zip";

            // Verify input file exists
            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputFilePath));

            // Password meeting complexity guidelines
            string password = "P@ssw0rd!Complex123";

            // Open source file stream
            using (FileStream sourceStream = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                // Create archive with AES‑256 encryption
                using (Archive archive = new Archive(new ArchiveEntrySettings(null, new AesEcryptionSettings(password, EncryptionMethod.AES256))))
                {
                    // Add entry to the archive
                    archive.CreateEntry("sample.txt", sourceStream);

                    // Save the encrypted archive
                    using (FileStream zipStream = File.Open(outputFilePath, FileMode.Create))
                    {
                        archive.Save(zipStream);
                    }
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
 * 1. When a developer needs to securely package confidential text files for transmission by creating an AES‑256 encrypted ZIP with a strong, policy‑compliant password using C#.
 * 2. When compliance requirements demand that archived data be encrypted with industry‑standard AES‑256 and the password must meet complexity rules before storage.
 * 3. When an application must generate encrypted backups of logs or reports on the fly, ensuring the archive cannot be opened without the generated complex password.
 * 4. When integrating Aspose.Zip into a .NET service that delivers protected documents to clients, requiring automatic password creation and AES‑256 encryption.
 * 5. When automating the preparation of files for cloud upload, and the developer wants to encrypt them with a robust password to prevent unauthorized access.
 */
