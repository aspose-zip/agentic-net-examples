// HOW-TO: Create AES256 Encrypted ZIP with Password Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputFilePath = "data\\sample.txt";
            string outputZipPath = "output\\encrypted.zip";

            if (!File.Exists(inputFilePath))
            {
                Console.Error.WriteLine($"File not found: {inputFilePath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (FileStream sourceStream = File.Open(inputFilePath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive())
                {
                    ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                        null,
                        new AesEcryptionSettings("S3cureP@ssw0rd!", EncryptionMethod.AES256));

                    archive.CreateEntry(Path.GetFileName(inputFilePath), sourceStream, entrySettings);
                    archive.Save(outputZipPath);
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
 * 1. When you need to securely share a confidential text file over email by creating a password‑protected AES‑256 encrypted ZIP archive in a C# application.
 * 2. When your software must store sensitive configuration files on disk and you want to encrypt them with a strong password using Aspose.Zip before saving.
 * 3. When complying with data‑protection regulations requires encrypting backup archives, and you need to generate an AES‑256 ZIP with a custom password in .NET.
 * 4. When automating a deployment pipeline that packages logs or reports, and you must ensure the packaged ZIP cannot be opened without a known password.
 * 5. When building a client‑side utility that lets users download protected documents, you can create an encrypted ZIP on the fly using C# and Aspose.Zip.
 */
