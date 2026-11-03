// HOW-TO: Encrypt an Existing ZIP File with AES‑256 Password Protection in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.zip";
        string outputPath = "encrypted.zip";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        string password = "Str0ngP@ssw0rd!2024";

        try
        {
            // Load source ZIP and read entries into memory streams
            List<(string Name, MemoryStream Stream)> entryData = new List<(string, MemoryStream)>();
            using (Archive sourceArchive = new Archive(inputPath))
            {
                foreach (ArchiveEntry entry in sourceArchive.Entries)
                {
                    MemoryStream ms = new MemoryStream();
                    using (Stream entryStream = entry.Open())
                    {
                        entryStream.CopyTo(ms);
                    }
                    ms.Position = 0;
                    entryData.Add((entry.Name, ms));
                }
            }

            // Create new encrypted archive with AES‑256
            using (Archive encryptedArchive = new Archive(new ArchiveEntrySettings(null, new AesEcryptionSettings(password, EncryptionMethod.AES256))))
            {
                foreach (var (name, stream) in entryData)
                {
                    encryptedArchive.CreateEntry(name, stream);
                }

                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    encryptedArchive.Save(outStream);
                }
            }

            // Dispose memory streams after saving
            foreach (var (_, stream) in entryData)
            {
                stream.Dispose();
            }

            Console.WriteLine("Encrypted ZIP created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to securely share a collection of documents by encrypting an existing ZIP archive with a strong AES‑256 password before sending it over email.
 * 2. When a backup system must protect stored ZIP backups with industry‑standard encryption to prevent unauthorized access to sensitive files.
 * 3. When a web application generates downloadable reports as ZIP files and must apply password‑based AES‑256 encryption to comply with data‑privacy regulations.
 * 4. When a file‑transfer service needs to re‑encrypt user‑uploaded ZIP archives with a new password to enforce consistent security policies.
 * 5. When a desktop utility processes legacy ZIP archives and adds AES‑256 encryption to meet corporate security standards without altering the original file contents.
 */
