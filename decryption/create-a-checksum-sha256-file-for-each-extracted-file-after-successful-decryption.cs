// HOW-TO: Generate SHA256 Checksums for Extracted Files from Encrypted ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Security.Cryptography;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path and output directory
            string inputPath = "encrypted.zip";
            string outputDirectory = "ExtractedFiles";
            // Password for the encrypted ZIP archive
            string password = "Password123";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the encrypted ZIP archive with the decryption password
            using (Archive archive = new Archive(inputPath, new ArchiveLoadOptions { DecryptionPassword = password }))
            {
                // Iterate through each entry in the archive
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    // Skip directories
                    if (entry.IsDirectory)
                    {
                        continue;
                    }

                    // Determine the full path for the extracted file
                    string destinationPath = Path.Combine(outputDirectory, entry.Name);
                    // Ensure the directory for the entry exists (handles nested folders)
                    string destinationDir = Path.GetDirectoryName(destinationPath);
                    Directory.CreateDirectory(destinationDir);

                    // Extract the entry to the destination path
                    entry.Extract(destinationPath);

                    // Compute SHA256 checksum of the extracted file
                    using (FileStream fileStream = File.OpenRead(destinationPath))
                    using (SHA256 sha256 = SHA256.Create())
                    {
                        byte[] hashBytes = sha256.ComputeHash(fileStream);
                        string hashString = BitConverter.ToString(hashBytes).Replace("-", "").ToLowerInvariant();

                        // Write the checksum to a .sha256 file alongside the extracted file
                        string checksumPath = destinationPath + ".sha256";
                        File.WriteAllText(checksumPath, hashString);
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
 * 1. When you need to verify the integrity of files extracted from a password‑protected ZIP archive in a .NET application.
 * 2. When you must automate the creation of SHA‑256 hash files for each extracted document to support downstream validation processes.
 * 3. When you are building a deployment pipeline that extracts encrypted archives and records checksums for security auditing.
 * 4. When you want to ensure that extracted configuration files have not been tampered with by comparing their SHA‑256 hashes.
 * 5. When you need to generate checksum files for backup verification after decrypting and extracting archived data.
 */
