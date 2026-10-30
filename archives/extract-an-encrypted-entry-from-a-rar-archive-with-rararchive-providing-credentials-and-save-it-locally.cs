// HOW-TO: Extract Encrypted RAR Entry With Password Using Aspose.Zip In C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip.Rar;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input RAR archive path (encrypted)
            string inputPath = @"C:\Data\encrypted.rar";
            // Hardcoded output directory for extracted file
            string outputDirectory = @"C:\Data\Extracted";
            // Password for the encrypted entry
            string password = "myPassword";

            // Verify that the input archive exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Open the RAR archive with decryption password
            using (FileStream fileStream = File.OpenRead(inputPath))
            using (RarArchive archive = new RarArchive(fileStream, new RarArchiveLoadOptions() { DecryptionPassword = password }))
            {
                // Check that the archive contains at least one entry
                if (archive.Entries.Count == 0)
                {
                    Console.WriteLine("The archive does not contain any entries.");
                    return;
                }

                // Select the first entry (replace index or name as needed)
                RarArchiveEntry entry = archive.Entries[0];

                // Build the full path for the extracted file
                string outputPath = Path.Combine(outputDirectory, entry.Name);

                // Extract the encrypted entry to the specified location
                entry.Extract(outputPath);

                Console.WriteLine($"Entry '{entry.Name}' extracted to '{outputPath}'.");
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
 * 1. When you need to programmatically retrieve a password‑protected file from a RAR archive and save it to a local folder in a C# application.
 * 2. When an automated backup system must decrypt and extract specific files from encrypted RAR backups using Aspose.Zip for .NET.
 * 3. When a desktop utility has to open user‑provided encrypted RAR archives, supply the password, and extract the first document for further processing.
 * 4. When a server‑side service processes incoming encrypted RAR uploads, validates the password, and extracts contents to a secure directory.
 * 5. When a migration script moves data from legacy encrypted RAR archives to a new file repository by programmatically extracting each entry with a known password.
 */
