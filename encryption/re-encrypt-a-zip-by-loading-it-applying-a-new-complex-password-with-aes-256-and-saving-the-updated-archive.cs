// HOW-TO: Re‑encrypt Existing ZIP File with AES‑256 Password in C# (Aspose.ZIP for .NET)
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
            string inputPath = "input.zip";
            string outputPath = "output.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Load the existing ZIP archive (no password assumed)
            using (Archive sourceArchive = new Archive(inputPath))
            {
                // Create a new archive that will hold re‑encrypted entries
                using (Archive targetArchive = new Archive())
                {
                    // Define encryption settings with a complex AES‑256 password
                    ArchiveEntrySettings aesSettings = new ArchiveEntrySettings(
                        null,
                        new AesEcryptionSettings("ComplexP@ssw0rd!#2026", EncryptionMethod.AES256));

                    // Copy each entry from the source archive to the target archive with encryption
                    foreach (ArchiveEntry entry in sourceArchive.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            targetArchive.CreateEntry(entry.Name, entryStream, aesSettings);
                        }
                    }

                    // Save the re‑encrypted archive to the output file
                    using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                    {
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
 * 1. When a company needs to upgrade an old unprotected ZIP archive to meet security policies by adding a strong AES‑256 password.
 * 2. When a developer must rotate the encryption password of a ZIP file that is distributed to clients without recreating the archive from scratch.
 * 3. When compliance regulations require all stored archives to be encrypted with a specific algorithm and key length, and existing files must be re‑encrypted accordingly.
 * 4. When a backup system needs to re‑encrypt previously saved ZIP backups with a new complex password before uploading them to cloud storage.
 * 5. When an application needs to protect sensitive documents inside a ZIP by applying AES‑256 encryption after the files have already been packaged.
 */
