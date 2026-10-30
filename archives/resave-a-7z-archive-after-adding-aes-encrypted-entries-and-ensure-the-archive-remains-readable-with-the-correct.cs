// HOW-TO: Add AES Encrypted File to 7z Archive and Resave in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Text;
using Aspose.Zip;
using Aspose.Zip.SevenZip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputArchivePath = "input\\original.7z";
            string outputArchivePath = "output\\resaved.7z";

            // Verify input archive exists
            if (!File.Exists(inputArchivePath))
            {
                Console.Error.WriteLine($"File not found: {inputArchivePath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputArchivePath));

            // Password for the encrypted entry
            string entryPassword = "SecretPassword";

            // Load existing 7z archive
            using (SevenZipArchive archive = new SevenZipArchive(inputArchivePath))
            {
                // Prepare data for the new encrypted entry
                string newEntryName = "SecretData.txt";
                byte[] contentBytes = Encoding.UTF8.GetBytes("Sensitive content");
                using (MemoryStream contentStream = new MemoryStream(contentBytes))
                {
                    // Configure compression and AES encryption for the entry
                    SevenZipEntrySettings entrySettings = new SevenZipEntrySettings(
                        new SevenZipLZMACompressionSettings(),
                        new SevenZipAESEncryptionSettings(entryPassword));

                    // Add the encrypted entry to the archive
                    archive.CreateEntry(newEntryName, contentStream, entrySettings);
                }

                // Save the modified archive to the output path
                using (FileStream outStream = File.Open(outputArchivePath, FileMode.Create))
                {
                    archive.Save(outStream);
                }
            }

            // Verify that the saved archive can be opened with the correct password
            using (SevenZipArchive verifyArchive = new SevenZipArchive(outputArchivePath, entryPassword))
            {
                // Locate the encrypted entry
                var encryptedEntry = verifyArchive.Entries.First(e => e.Name == "SecretData.txt");

                // Extract the entry to a memory stream
                using (MemoryStream extractedStream = new MemoryStream())
                {
                    encryptedEntry.Extract(extractedStream);
                    // Display extracted content
                    string extractedText = Encoding.UTF8.GetString(extractedStream.ToArray());
                    Console.WriteLine("Extracted content: " + extractedText);
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
 * 1. When you need to add a confidential text file to an existing 7z archive using AES encryption and then save the updated archive.
 * 2. When you must update a backup archive with new sensitive data while preserving the original archive’s structure and password protection.
 * 3. When a deployment pipeline requires inserting encrypted configuration files into a 7z package before distributing it to clients.
 * 4. When you want to programmatically modify a 7z archive to include encrypted logs and ensure the archive can still be opened with the correct password.
 * 5. When automating archival of personal documents, you need to add a password‑protected entry and rewrite the archive to a new location.
 */
