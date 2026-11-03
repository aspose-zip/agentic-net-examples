// HOW-TO: Find Correct Password for Encrypted ZIP and List Entries in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path
            string inputPath = "encrypted.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Hardcoded output text file path (non‑secret information)
            string outputPath = "output/entries.txt";

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(outputPath));

            // Candidate passwords to try
            List<string> candidatePasswords = new List<string>
            {
                "password1",
                "password2",
                "password3"
            };

            bool decrypted = false;
            List<string> entryNames = new List<string>();

            // Attempt to open the archive with each password
            foreach (string pwd in candidatePasswords)
            {
                try
                {
                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
                    {
                        DecryptionPassword = pwd
                    };

                    using (Archive archive = new Archive(inputPath, loadOptions))
                    {
                        // If we reach here, decryption succeeded
                        foreach (ArchiveEntry entry in archive.Entries)
                        {
                            entryNames.Add(entry.Name);
                        }
                        decrypted = true;
                        break;
                    }
                }
                catch (Exception)
                {
                    // Wrong password, continue to next candidate
                }
            }

            if (!decrypted)
            {
                Console.Error.WriteLine("Failed to decrypt the archive with provided passwords.");
                return;
            }

            // Save non‑secret outcome (list of entry names) to output file
            using (StreamWriter writer = new StreamWriter(outputPath, false))
            {
                foreach (string name in entryNames)
                {
                    writer.WriteLine(name);
                }
            }

            Console.WriteLine($"Decryption succeeded. Entry list saved to: {outputPath}");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you need to programmatically test a set of possible passwords to open a user‑provided encrypted ZIP file and retrieve the list of contained files without exposing the file contents.
 * 2. When an application must verify a client‑supplied archive’s password before allowing further processing, storing only the file names for audit purposes.
 * 3. When you want to automate the extraction of metadata (such as entry names) from a protected ZIP in a C# service while keeping the actual data confidential.
 * 4. When a security tool needs to brute‑force a small password list against an encrypted archive to confirm whether the archive can be accessed and log the successful password.
 * 5. When a backup system must check encrypted ZIP backups for integrity by opening them with known passwords and recording the archive’s directory structure locally.
 */
