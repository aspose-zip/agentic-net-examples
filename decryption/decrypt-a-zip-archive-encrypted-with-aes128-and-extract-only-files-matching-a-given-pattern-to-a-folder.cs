// HOW-TO: Decrypt AES128 Encrypted ZIP and Extract Specific Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path and output directory
            string inputPath = @"C:\Input\encrypted.zip";
            string outputDir = @"C:\Output\Extracted";
            string password = "Password123";
            string pattern = ".txt"; // files ending with .txt

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDir);

            // Open the encrypted ZIP archive with the password
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
                {
                    DecryptionPassword = password
                };

                using (Archive archive = new Archive(zipStream, loadOptions))
                {
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        // Skip directories
                        if (entry.IsDirectory)
                            continue;

                        // Match files based on the pattern
                        if (!entry.Name.EndsWith(pattern, StringComparison.OrdinalIgnoreCase))
                            continue;

                        // Build destination path and ensure its directory exists
                        string destPath = Path.Combine(outputDir, entry.Name);
                        string destDir = Path.GetDirectoryName(destPath);
                        if (!string.IsNullOrEmpty(destDir))
                        {
                            Directory.CreateDirectory(destDir);
                        }

                        // Extract the entry to the destination file
                        entry.Extract(destPath);
                        Console.WriteLine($"Extracted: {entry.Name}");
                    }
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
 * 1. When you need to programmatically open a password‑protected ZIP created with AES‑128 encryption and pull only certain file types (e.g., .txt) to a local directory.
 * 2. When an automated data‑processing pipeline must securely retrieve only the required documents from an encrypted archive without extracting the entire contents.
 * 3. When a desktop application offers users the ability to select a zip file, provide a password, and extract only matching files for compliance or reporting purposes.
 * 4. When a server‑side service processes incoming encrypted backups and needs to extract only configuration files matching a pattern to a staging folder.
 * 5. When a scheduled job scans encrypted zip archives, decrypts them with a known password, and copies only log files that meet a naming pattern to an analysis folder.
 */
