// HOW-TO: Extract a File from Password Protected ZIP and Convert to 7z in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;
using Aspose.Zip.SevenZip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string zipPath = "input.zip";
            string sevenZipPath = "output.7z";
            string entryName = "file.txt";
            string zipPassword = "password123";

            // Verify input ZIP exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(sevenZipPath));

            // Load password‑protected ZIP archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = zipPassword;
            using (Archive zipArchive = new Archive(zipPath, loadOptions))
            {
                // Find the desired entry
                ArchiveEntry entry = zipArchive.Entries.FirstOrDefault(e => e.Name.Equals(entryName, StringComparison.OrdinalIgnoreCase));
                if (entry == null)
                {
                    Console.Error.WriteLine($"Entry not found: {entryName}");
                    return;
                }

                // Open the entry stream
                using (Stream entryStream = entry.Open())
                {
                    // Create a new 7z archive and add the entry
                    using (SevenZipArchive sevenArchive = new SevenZipArchive())
                    {
                        sevenArchive.CreateEntry(entryName, entryStream);

                        // Save the 7z archive to disk
                        using (FileStream outStream = File.Open(sevenZipPath, FileMode.Create))
                        {
                            sevenArchive.Save(outStream);
                        }
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
 * 1. When you need to retrieve a confidential document from a password‑protected ZIP and store it in a more efficient 7z archive for downstream processing.
 * 2. When a migration script must unpack a specific file from an encrypted backup ZIP and repackage it as a 7z file to meet new storage policies.
 * 3. When an application automates the conversion of a single log file inside a secured ZIP into a 7z archive before uploading it to a cloud repository.
 * 4. When a DevOps pipeline extracts a configuration file from a protected ZIP and creates a lightweight 7z package for distribution across servers.
 * 5. When a data‑archiving tool reads a password‑locked ZIP, extracts one entry, and saves it as a 7z archive to reduce disk usage and improve compression.
 */
