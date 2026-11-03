// HOW-TO: Create Mixed AES128 and AES192 Encrypted ZIP in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;
using Aspose.Zip.Saving;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputFile1 = "input/file1.txt";
            string inputFile2 = "input/file2.txt";
            string zipPath = "output/mixed_encryption.zip";

            // Verify input files exist
            if (!File.Exists(inputFile1))
            {
                Console.Error.WriteLine($"File not found: {inputFile1}");
                return;
            }
            if (!File.Exists(inputFile2))
            {
                Console.Error.WriteLine($"File not found: {inputFile2}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(zipPath));

            // -----------------------------------------------------------------
            // Step 1: Create a ZIP archive with an AES128‑encrypted entry (file1.txt)
            // -----------------------------------------------------------------
            using (FileStream zipStream = File.Open(zipPath, FileMode.Create, FileAccess.Write))
            {
                using (FileStream source1 = File.Open(inputFile1, FileMode.Open, FileAccess.Read))
                {
                    // AES128 encryption settings for the first entry
                    ArchiveEntrySettings aes128Settings = new ArchiveEntrySettings(
                        null,
                        new AesEcryptionSettings("Password123", EncryptionMethod.AES128));

                    using (Archive archive = new Archive(aes128Settings))
                    {
                        archive.CreateEntry("file1.txt", source1);
                        archive.Save(zipStream);
                    }
                }
            }

            // -----------------------------------------------------------------
            // Step 2: Open the existing archive and add an AES192‑encrypted entry (file2.txt)
            // -----------------------------------------------------------------
            using (FileStream source2 = File.Open(inputFile2, FileMode.Open, FileAccess.Read))
            {
                // Load the existing archive
                using (Archive archive = new Archive(zipPath, new ArchiveLoadOptions()))
                {
                    // AES192 encryption settings for the new entry
                    ArchiveEntrySettings aes192Settings = new ArchiveEntrySettings(
                        null,
                        new AesEcryptionSettings("Password123", EncryptionMethod.AES192));

                    // Add the new entry with AES192 encryption
                    archive.CreateEntry("file2.txt", source2, aes192Settings);

                    // Save changes back to the same file
                    archive.Save(zipPath);
                }
            }

            Console.WriteLine("Mixed‑encryption ZIP archive created successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to distribute a ZIP file where some files must stay encrypted with the legacy AES128 key while adding new files protected with stronger AES192 encryption.
 * 2. When compliance regulations require using different encryption strengths for different data categories within the same archive.
 * 3. When you are migrating existing AES128‑encrypted archives to a higher security level without re‑encrypting the original entries.
 * 4. When a client application must read older AES128 entries but also verify newer files encrypted with AES192 in a single package.
 * 5. When you want to create a single ZIP that can be opened by tools supporting mixed AES encryption methods for backward compatibility.
 */
