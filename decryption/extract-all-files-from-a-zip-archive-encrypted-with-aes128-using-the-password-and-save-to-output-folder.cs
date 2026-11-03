// HOW-TO: Extract All Files From AES128 Encrypted Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path (encrypted with AES128) and output directory.
            string inputPath = "encrypted.zip";
            string outputPath = "ExtractedFiles";

            // Verify that the input ZIP file exists.
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory (and its parent) exists.
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));
            Directory.CreateDirectory(outputPath);

            // Load the encrypted ZIP archive with the password.
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
            {
                DecryptionPassword = "MySecretPassword"
            };

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Extract all entries to the output directory.
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
 * 1. When you need to programmatically unpack a password‑protected AES‑128 zip archive received from a client and store its contents on a server.
 * 2. When an automated build process must extract configuration files from a secured zip bundle before deployment.
 * 3. When a desktop application has to read encrypted backup archives and restore the files to a user‑specified folder.
 * 4. When a cloud service processes uploaded encrypted zip files and needs to decrypt and extract them for further analysis.
 * 5. When a data migration script must batch‑extract multiple AES‑encrypted zip packages without manual password entry.
 */
