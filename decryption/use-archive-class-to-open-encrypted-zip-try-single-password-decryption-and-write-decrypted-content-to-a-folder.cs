// HOW-TO: Decrypt Encrypted ZIP with Password and Extract Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path (encrypted) and output folder path
            string inputPath = "encrypted.zip";
            string outputPath = "DecryptedContent";

            // Verify that the input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputPath);

            // Load the encrypted ZIP archive with the password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
            {
                DecryptionPassword = "password123"
            };

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Extract all entries to the output directory
                archive.ExtractToDirectory(outputPath);
            }

            Console.WriteLine("Decryption and extraction completed successfully.");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically open a password‑protected ZIP file and extract its contents to a local folder in a .NET application.
 * 2. When automating the processing of confidential archives received from partners, ensuring they are decrypted and unpacked securely using Aspose.Zip.
 * 3. When building a batch job that reads encrypted backup archives, supplies the decryption password, and restores the files to a specified directory.
 * 4. When creating a utility that validates the presence of a ZIP file, creates the output directory if missing, and extracts all entries after decryption.
 * 5. When integrating file extraction into a deployment pipeline that must handle encrypted packages without manual intervention.
 */
