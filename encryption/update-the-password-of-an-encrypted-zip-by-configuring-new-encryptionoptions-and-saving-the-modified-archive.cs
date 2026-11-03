// HOW-TO: Change Password of Encrypted ZIP Archive Using Aspose.Zip in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.zip";
            string outputPath = "output.zip";

            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            string oldPassword = "oldpass";
            string newPassword = "newpass";

            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = oldPassword;

            using (Archive sourceArchive = new Archive(inputPath, loadOptions))
            {
                ArchiveEntrySettings newEntrySettings = new ArchiveEntrySettings(
                    null,
                    new AesEcryptionSettings(newPassword, EncryptionMethod.AES256));

                using (Archive newArchive = new Archive(newEntrySettings))
                {
                    foreach (ArchiveEntry entry in sourceArchive.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            newArchive.CreateEntry(entry.Name, entryStream);
                        }
                    }

                    using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                    {
                        newArchive.Save(outStream);
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
 * 1. When a company needs to rotate the encryption password of an existing protected ZIP file without extracting and recompressing its contents.
 * 2. When a developer must update the password of a client‑delivered encrypted archive to comply with new security policies.
 * 3. When an automated backup system has to re‑encrypt stored ZIP backups with a new password after a credential change.
 * 4. When a software installer needs to replace the old password of a bundled resource ZIP before distributing it to end users.
 * 5. When a cloud service must re‑secure uploaded encrypted ZIP files with a different password for multi‑tenant isolation.
 */
