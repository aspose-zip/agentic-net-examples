// HOW-TO: Encrypt a Specific File Inside a ZIP Archive with AES256 in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            string inputZipPath = "input.zip";
            string outputZipPath = "output.zip";
            string fileToEncrypt = "sample.txt";
            string password = "Password123";

            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            Directory.CreateDirectory(Path.GetDirectoryName(outputZipPath));

            using (Archive archive = new Archive(inputZipPath))
            {
                ArchiveEntry entry = archive.Entries.FirstOrDefault(e => e.Name.Equals(fileToEncrypt, StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found in archive: {fileToEncrypt}");
                    return;
                }

                using (MemoryStream entryData = new MemoryStream())
                {
                    using (Stream entryStream = entry.Open())
                    {
                        entryStream.CopyTo(entryData);
                    }
                    entryData.Position = 0;

                    archive.DeleteEntry(entry);

                    ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                        null,
                        new AesEcryptionSettings(password, EncryptionMethod.AES256));

                    archive.CreateEntry(fileToEncrypt, entryData, entrySettings);

                    using (FileStream outStream = File.Open(outputZipPath, FileMode.Create))
                    {
                        archive.Save(outStream);
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
 * 1. When you need to protect a confidential text document inside an existing ZIP before sharing it with partners, you can encrypt that single entry with AES256 using C#.
 * 2. When an application must update a password‑protected archive by adding encryption to a newly generated log file without recreating the whole ZIP, this code shows how to replace the entry with AES256 encryption.
 * 3. When compliance regulations require that only certain files in a backup archive be encrypted, you can selectively encrypt the target file while leaving the rest unchanged.
 * 4. When a developer wants to programmatically secure a specific configuration file inside a deployment package without extracting and repacking the entire archive, this approach encrypts the entry in place.
 * 5. When automating a workflow that sends encrypted reports inside a pre‑existing ZIP to customers, you can encrypt each report file with a unique password using the Aspose.Zip library in C#.
 */
