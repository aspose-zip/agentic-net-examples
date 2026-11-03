// HOW-TO: Decrypt AES256 Encrypted ZIP and Extract Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path (AES256 encrypted) and output directory.
            string inputPath = "encrypted.zip";
            string outputPath = "ExtractedFiles";

            // Verify that the input file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists.
            Directory.CreateDirectory(outputPath);

            // Set the password for AES256 decryption.
            string password = "YourPasswordHere";

            // Load the encrypted archive with the decryption password.
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
            {
                DecryptionPassword = password
            };

            // Open the archive and extract all entries to the output directory.
            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to programmatically open a password‑protected ZIP created with AES‑256 encryption and unpack its contents to a folder in a .NET application.
 * 2. When a desktop utility must automatically decrypt secure backup archives before processing the files on Windows.
 * 3. When a server‑side service receives encrypted ZIP uploads and must extract them to a temporary directory for further analysis.
 * 4. When you are building a migration tool that reads AES‑256 encrypted archives from legacy systems and writes the extracted data to a new location.
 * 5. When an automated deployment script has to unpack confidential resource packages that are protected with a password and AES‑256 encryption.
 */
