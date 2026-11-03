// HOW-TO: Decrypt AES Encrypted ZIP and Extract Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path (AES‑encrypted) and output directory
            string inputPath = "encrypted.zip";
            string outputDirectory = "DecryptedOutput";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Set the password for the encrypted archive
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "MySecretPassword";

            // Open the encrypted ZIP file with the specified password
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream, loadOptions))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputDirectory);
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
 * 1. When you need to programmatically open a password‑protected ZIP file received from a client and extract its contents to a server folder using C#.
 * 2. When an automated batch job must verify the correct password for an AES‑encrypted archive before processing the extracted documents.
 * 3. When a desktop application has to let users import encrypted backup archives and restore the files to a chosen directory.
 * 4. When a cloud service processes secure file uploads and must decrypt the ZIP payload without exposing the password in plain text.
 * 5. When a migration script moves encrypted archives from legacy storage to a new system by decrypting and extracting them with Aspose.Zip for .NET.
 */
