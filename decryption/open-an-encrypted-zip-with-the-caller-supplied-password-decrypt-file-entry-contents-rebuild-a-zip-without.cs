// HOW-TO: Decrypt Encrypted ZIP with Password and Save as Unencrypted ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "encrypted.zip";
        string outputPath = "decrypted.zip";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        string outputDir = Path.GetDirectoryName(outputPath);
        if (!string.IsNullOrEmpty(outputDir))
        {
            Directory.CreateDirectory(outputDir);
        }

        try
        {
            // Password supplied by the caller (example value)
            string password = "myPassword";

            // Load the encrypted ZIP with the password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = password;

            using (Archive encryptedArchive = new Archive(inputPath, loadOptions))
            {
                // Create a new unencrypted archive
                using (Archive newArchive = new Archive())
                {
                    // Keep memory streams alive until the archive is saved
                    List<MemoryStream> entryStreams = new List<MemoryStream>();

                    foreach (ArchiveEntry entry in encryptedArchive.Entries)
                    {
                        // Open the encrypted entry (automatically decrypted)
                        using (Stream entryStream = entry.Open())
                        {
                            MemoryStream ms = new MemoryStream();
                            entryStream.CopyTo(ms);
                            ms.Position = 0;

                            // Store the stream to keep it alive
                            entryStreams.Add(ms);

                            // Add the entry to the new archive without encryption settings
                            newArchive.CreateEntry(entry.Name, ms);
                        }
                    }

                    // Save the unencrypted ZIP
                    newArchive.Save(outputPath);

                    // Dispose the temporary memory streams
                    foreach (MemoryStream ms in entryStreams)
                    {
                        ms.Dispose();
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
 * 1. When you need to programmatically remove password protection from a ZIP received from a client before further processing.
 * 2. When you must extract confidential files from an encrypted archive, repackage them without encryption for downstream systems that don’t support encrypted ZIPs.
 * 3. When automating a migration of legacy encrypted backup archives to a new storage solution that requires unencrypted ZIP files.
 * 4. When integrating with third‑party tools that cannot handle encrypted archives, you can decrypt and recreate a plain ZIP on the fly.
 * 5. When performing batch processing of multiple password‑protected ZIPs and need to store the decrypted versions locally for auditing or indexing.
 */
