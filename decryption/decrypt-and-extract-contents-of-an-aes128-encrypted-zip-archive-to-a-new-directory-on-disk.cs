// HOW-TO: Decrypt AES128 Encrypted ZIP and Extract Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded paths
            string inputPath = "encrypted.zip";
            string outputDirectory = "extracted";
            string password = "MySecretPassword";

            // Validate input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Set load options with the AES128 password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = password;

            // Open the encrypted ZIP archive
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputDirectory);
            }

            Console.WriteLine("Extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you receive a password‑protected AES128 ZIP from a client and need to programmatically unzip its contents to a folder in a .NET application.
 * 2. When automating a nightly batch job that decrypts and extracts encrypted backup archives before processing the files.
 * 3. When building a file‑import feature that must read encrypted ZIP uploads and store the extracted documents on the server.
 * 4. When migrating data from secure ZIP archives to a new system and require a reliable C# solution to handle decryption and extraction.
 * 5. When creating a desktop utility that lets users select an encrypted ZIP and extracts its contents to a chosen directory without manual password entry.
 */
