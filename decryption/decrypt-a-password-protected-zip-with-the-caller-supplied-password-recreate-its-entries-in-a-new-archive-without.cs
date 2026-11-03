// HOW-TO: Decrypt Password Protected ZIP and Save Unencrypted Copy in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input/encrypted.zip";
        string outputPath = "output/decrypted.zip";
        string password = "Password123";

        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions()
            {
                DecryptionPassword = password
            };

            using (Archive encryptedArchive = new Archive(inputPath, loadOptions))
            using (Archive unencryptedArchive = new Archive())
            {
                List<MemoryStream> entryStreams = new List<MemoryStream>();

                foreach (ArchiveEntry entry in encryptedArchive.Entries)
                {
                    MemoryStream ms = new MemoryStream();
                    using (Stream entryStream = entry.Open())
                    {
                        entryStream.CopyTo(ms);
                    }
                    ms.Position = 0;
                    unencryptedArchive.CreateEntry(entry.Name, ms);
                    entryStreams.Add(ms);
                }

                using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                {
                    unencryptedArchive.Save(outStream, new ArchiveSaveOptions());
                }

                foreach (MemoryStream ms in entryStreams)
                {
                    ms.Dispose();
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
 * 1. When you receive a password‑protected ZIP from a client and need to create an unencrypted version for downstream processing in a .NET application.
 * 2. When an automated workflow must extract files from a secured archive, repackage them without encryption, and store the result for compliance reporting.
 * 3. When a migration script has to convert legacy encrypted ZIP backups into plain ZIP files before uploading them to a cloud storage service.
 * 4. When a desktop utility needs to open a protected archive, modify its contents in memory, and save a new ZIP that can be opened by users without a password.
 * 5. When a CI/CD pipeline must validate the integrity of a secured ZIP and produce an unencrypted artifact for further testing or deployment.
 */
