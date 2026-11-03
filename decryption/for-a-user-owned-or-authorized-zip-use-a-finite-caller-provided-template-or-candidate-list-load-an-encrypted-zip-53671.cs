// HOW-TO: Decrypt Encrypted ZIP with Password List and Backup Extraction in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path and output locations
            string zipPath = "encrypted.zip";
            string backupFolder = "Backup";
            string resultInfoPath = "ExtractionResult.txt";

            // Verify input file exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(backupFolder);
            Directory.CreateDirectory(Path.GetDirectoryName(resultInfoPath));

            // List of candidate passwords to try
            List<string> passwordCandidates = new List<string>
            {
                "password1",
                "12345",
                "secret"
            };

            bool decrypted = false;
            Archive archive = null;

            // Attempt to open the archive with each password
            foreach (string pwd in passwordCandidates)
            {
                try
                {
                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                    loadOptions.DecryptionPassword = pwd;
                    archive = new Archive(zipPath, loadOptions);
                    decrypted = true;
                    Console.WriteLine($"Password found: {pwd}");
                    break;
                }
                catch (Exception)
                {
                    // Continue to next password candidate
                }
            }

            if (!decrypted)
            {
                Console.Error.WriteLine("Failed to decrypt the archive with provided passwords.");
                return;
            }

            // Extract all entries to the backup folder
            using (archive)
            {
                foreach (ArchiveEntry entry in archive.Entries)
                {
                    string destinationPath = Path.Combine(backupFolder, entry.Name);
                    Directory.CreateDirectory(Path.GetDirectoryName(destinationPath));
                    using (FileStream outStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                    {
                        entry.Extract(outStream);
                    }
                }
            }

            // Save non‑secret outcome information
            using (StreamWriter writer = new StreamWriter(resultInfoPath, false, Encoding.UTF8))
            {
                int fileCount = Directory.GetFiles(backupFolder, "*", SearchOption.AllDirectories).Length;
                writer.WriteLine($"Extracted {fileCount} files from {zipPath}.");
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
 * 1. When you need to automatically open a user‑provided encrypted ZIP by trying a known set of passwords and extract its contents to a safe backup location.
 * 2. When a desktop application must recover files from a password‑protected archive without prompting the user for the password each time.
 * 3. When a server process has to validate and decrypt incoming ZIP uploads using a predefined password list before processing the files.
 * 4. When you want to create a simple C# utility that extracts confidential documents from an encrypted archive and stores only a log of the extraction result.
 * 5. When a backup script must handle encrypted ZIP archives, attempt decryption with candidate passwords, and copy the extracted files to a designated backup folder.
 */
