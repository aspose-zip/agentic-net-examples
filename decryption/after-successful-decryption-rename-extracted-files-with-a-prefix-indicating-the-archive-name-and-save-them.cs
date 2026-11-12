// HOW-TO: Decrypt Encrypted ZIP and Rename Extracted Files with Archive Prefix in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path (encrypted) and output directory
            string inputPath = "encrypted.zip";
            string outputDirectory = "Extracted";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Password for the encrypted archive
            string archivePassword = "password";

            // Derive a prefix from the archive file name (without extension)
            string archiveNamePrefix = Path.GetFileNameWithoutExtension(inputPath);

            // Open the encrypted archive with the decryption password
            using (Archive archive = new Archive(inputPath, new ArchiveLoadOptions { DecryptionPassword = archivePassword }))
            {
                // Iterate through each entry in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Skip directories
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Build the new file name with the archive name prefix
                    string newFileName = $"{archiveNamePrefix}_{entry.Name}";
                    string destinationPath = Path.Combine(outputDirectory, newFileName);

                    // Extract the entry to the destination path
                    using (FileStream outputStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                    {
                        using (Stream entryStream = entry.Open())
                        {
                            entryStream.CopyTo(outputStream);
                        }
                    }
                }
            }

            Console.WriteLine("Extraction and renaming completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to automatically extract password‑protected ZIP archives and add the archive name as a prefix to each file for easy identification in a batch processing pipeline.
 * 2. When a deployment script must unpack encrypted backup archives and rename the contents so they can be traced back to the original archive without manual renaming.
 * 3. When a data‑ingestion service receives encrypted ZIP uploads and must decrypt them, extract only files, and store them with a consistent naming convention that includes the source archive name.
 * 4. When you are building a file‑management tool that extracts confidential documents from encrypted archives and prefixes each document with the archive’s name to avoid naming collisions.
 * 5. When an automated reporting system extracts encrypted ZIP reports each day and adds the date‑based archive prefix to each extracted file for version control and audit trails.
 */
