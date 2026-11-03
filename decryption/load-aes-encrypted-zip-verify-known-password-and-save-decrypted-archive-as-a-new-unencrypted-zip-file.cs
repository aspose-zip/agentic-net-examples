// HOW-TO: Decrypt AES Encrypted ZIP With Password And Save Unencrypted In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input and output paths
            string inputPath = "encrypted.zip";
            string outputPath = "decrypted.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            string outputDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outputDir))
            {
                Directory.CreateDirectory(outputDir);
            }

            // Load the AES‑encrypted ZIP with the known password
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "Password123";

            using (Archive archive = new Archive(inputPath, loadOptions))
            {
                // Save the archive as an unencrypted ZIP
                archive.Save(outputPath);
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
 * 1. When you receive a password‑protected ZIP from a client and need to remove encryption before processing the files in a .NET application.
 * 2. When a scheduled job must batch‑decrypt multiple AES‑encrypted archives and store them as regular ZIPs for downstream systems that cannot handle encrypted archives.
 * 3. When migrating legacy data that was stored in encrypted ZIPs to a new storage solution that only accepts unencrypted archives.
 * 4. When integrating with third‑party tools that require plain ZIP files, you can programmatically decrypt the archive using the known password and re‑save it without encryption.
 * 5. When performing automated testing of extraction logic, you may need to create an unencrypted copy of an AES‑encrypted ZIP to compare results.
 */
