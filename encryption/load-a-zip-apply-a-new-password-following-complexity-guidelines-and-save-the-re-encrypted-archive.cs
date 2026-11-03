// HOW-TO: Re‑Encrypt Existing ZIP File With New Password Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        string inputPath = "input.zip";
        string outputPath = "output_encrypted.zip";

        try
        {
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

            using (Archive sourceArchive = new Archive(inputPath))
            {
                using (Archive targetArchive = new Archive())
                {
                    string newPassword = "Str0ngP@ssw0rd!2023";

                    foreach (ArchiveEntry entry in sourceArchive.Entries)
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            ArchiveEntrySettings entrySettings = new ArchiveEntrySettings(
                                null,
                                new TraditionalEncryptionSettings(newPassword)
                            );

                            targetArchive.CreateEntry(entry.Name, entryStream, entrySettings);
                        }
                    }

                    using (FileStream outputStream = File.Open(outputPath, FileMode.Create))
                    {
                        targetArchive.Save(outputStream);
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
 * 1. When you need to change the password of a zip archive to meet corporate security policies without extracting and recompressing the files.
 * 2. When you must re‑encrypt an existing backup zip with a stronger password before uploading it to a cloud storage service.
 * 3. When a client requests that all delivered zip packages use a specific password format, and you need to apply it programmatically in a .NET application.
 * 4. When automating a workflow that receives password‑protected zip files and you need to replace the old password with a new one that follows complexity guidelines.
 * 5. When migrating legacy zip archives to a new encryption standard while preserving the original file structure and compression.
 */
