// HOW-TO: Change Password of AES256 Encrypted ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input_encrypted.zip";
        string outputPath = "output_updated.zip";
        string originalPassword = "oldPass";
        string newPassword = "newPass";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the existing encrypted ZIP with the original password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
            {
                DecryptionPassword = originalPassword
            };

            using (Archive sourceArchive = new Archive(inputPath, loadOptions))
            {
                // Create a new archive to hold entries with the new AES‑256 password
                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    using (Archive targetArchive = new Archive())
                    {
                        foreach (ArchiveEntry entry in sourceArchive.Entries)
                        {
                            // Open the source entry stream
                            using (Stream entryStream = entry.Open())
                            {
                                // Define new encryption settings for the entry
                                ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                                    null,
                                    new AesEcryptionSettings(newPassword, EncryptionMethod.AES256));

                                // Add the entry to the new archive with the new settings
                                targetArchive.CreateEntry(entry.Name, entryStream, entrySettings);
                            }
                        }

                        // Save the updated archive
                        targetArchive.Save(outStream);
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
 * 1. When a company needs to rotate the password of an existing AES‑256 encrypted ZIP file to meet security policy requirements.
 * 2. When a developer must re‑encrypt archived documents with a new password before sending them to a client or partner.
 * 3. When an automated backup system updates its encryption key and must rewrite stored ZIP archives without extracting their contents.
 * 4. When migrating legacy encrypted archives to a new password scheme while preserving the original compression and folder structure.
 * 5. When compliance audits require changing the encryption password of sensitive data bundles without altering the files inside.
 */
