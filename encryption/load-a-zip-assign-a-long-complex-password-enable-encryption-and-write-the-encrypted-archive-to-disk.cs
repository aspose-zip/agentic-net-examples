// HOW-TO: Encrypt Existing ZIP with AES256 Using Complex Password in C# (Aspose.ZIP for .NET)
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
            string inputPath = @"C:\Data\source.zip";
            string outputPath = @"C:\Data\encrypted\protected.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Complex password for encryption
            string password = "P@55w0rd!_Complex#2023$LongPasswordExample";

            // Load the existing ZIP archive
            using (Archive sourceArchive = new Archive(inputPath))
            {
                // Create a new archive that will hold encrypted entries
                using (Archive encryptedArchive = new Archive())
                {
                    // Iterate over each entry in the source archive
                    foreach (ArchiveEntry entry in sourceArchive.Entries)
                    {
                        // Extract entry to a memory stream
                        using (MemoryStream entryData = new MemoryStream())
                        {
                            entry.Extract(entryData);
                            entryData.Position = 0;

                            // Prepare encryption settings for the entry
                            ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                                null,
                                new AesEcryptionSettings(password, EncryptionMethod.AES256));

                            // Add the entry to the new archive with encryption
                            encryptedArchive.CreateEntry(entry.Name, entryData, entrySettings);
                        }
                    }

                    // Save the encrypted archive to disk
                    using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                    {
                        encryptedArchive.Save(outputStream);
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
 * 1. When you need to protect confidential files before sending them to a client, you can encrypt an existing ZIP with a strong AES‑256 password using C#.
 * 2. When regulatory compliance requires archived data to be stored with strong encryption, this code lets you re‑encrypt legacy ZIP archives with a complex password.
 * 3. When automating nightly backups, you can take the generated ZIP, apply AES‑256 encryption, and save the protected archive to a secure location.
 * 4. When a legacy system creates unencrypted ZIP files, you can use this approach to add encryption without extracting and recompressing the contents.
 * 5. When distributing software packages internally, you can encrypt the package archive with a long password to prevent unauthorized access.
 */
