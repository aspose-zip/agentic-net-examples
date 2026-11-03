// HOW-TO: Decrypt AES256 Encrypted ZIP and Re‑Save as Unencrypted ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;
using Aspose.Zip.Saving;

public class Program
{
    public static void Main(string[] args)
    {
        // Hardcoded input and output paths
        string inputPath = "encrypted.zip";
        string outputPath = "decrypted.zip";
        string password = "MyPassword";

        // Verify input file exists
        if (!File.Exists(inputPath))
        {
            Console.Error.WriteLine($"File not found: {inputPath}");
            return;
        }

        // Ensure output directory exists
        Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

        try
        {
            // Load the encrypted ZIP with the provided password
            using (Archive encryptedArchive = new Archive(inputPath, new ArchiveLoadOptions() { DecryptionPassword = password }))
            {
                // Collect entry data in memory streams
                List<(string Name, MemoryStream Stream)> extractedEntries = new List<(string, MemoryStream)>();

                foreach (ArchiveEntry entry in encryptedArchive.Entries)
                {
                    // Extract entry content to a memory stream
                    MemoryStream ms = new MemoryStream();
                    entry.Extract(ms);
                    ms.Position = 0; // Reset position for reading
                    extractedEntries.Add((entry.Name, ms));
                }

                // Create a new ZIP archive without encryption
                using (Archive newArchive = new Archive())
                {
                    // Add each extracted entry to the new archive
                    foreach (var item in extractedEntries)
                    {
                        newArchive.CreateEntry(item.Name, item.Stream);
                    }

                    // Save the new archive to the output file
                    using (FileStream outStream = File.Open(outputPath, FileMode.Create))
                    {
                        newArchive.Save(outStream, new ArchiveSaveOptions());
                    }
                }

                // Dispose all memory streams after saving
                foreach (var item in extractedEntries)
                {
                    item.Stream.Dispose();
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
 * 1. When you receive a password‑protected ZIP from a client and need to store its files in a regular archive for downstream processing.
 * 2. When a scheduled job must remove encryption from backup archives before uploading them to a cloud storage service that does not support encrypted ZIPs.
 * 3. When an application has to extract confidential documents from an AES‑256 ZIP, modify them, and then repack them without encryption for distribution.
 * 4. When migrating legacy encrypted archives to a new system that only accepts unencrypted ZIP files for compatibility.
 * 5. When automating compliance checks that require reading the contents of encrypted archives and saving them in a plain ZIP for audit logging.
 */
