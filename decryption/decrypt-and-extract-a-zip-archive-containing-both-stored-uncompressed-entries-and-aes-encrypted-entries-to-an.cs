// HOW-TO: Decrypt and Extract AES Encrypted and Stored ZIP Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP file path
            string inputPath = "C:\\Data\\encryptedArchive.zip";
            // Hardcoded output directory path
            string outputPath = "C:\\Data\\Extracted";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory (or its parent) exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Set the password for AES‑encrypted entries
            ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
            loadOptions.DecryptionPassword = "Password123";

            // Open the ZIP archive with the load options
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            using (Archive archive = new Archive(zipStream, loadOptions))
            {
                // Extract all entries (both stored and encrypted) to the output directory
                archive.ExtractToDirectory(outputPath);
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
 * 1. When you need to programmatically unpack a ZIP archive that contains both uncompressed files and AES‑protected entries using a known password in a .NET application.
 * 2. When a desktop utility must automatically extract confidential documents from a password‑secured ZIP bundle while preserving the original folder structure.
 * 3. When a server‑side service processes uploaded backup archives that mix stored and encrypted files and must decrypt them before further processing.
 * 4. When an automated deployment script has to retrieve configuration files from a mixed‑type ZIP archive without manual intervention.
 * 5. When a data migration tool has to read and extract files from a ZIP archive that includes both plain and encrypted entries to move them to a new location.
 */
