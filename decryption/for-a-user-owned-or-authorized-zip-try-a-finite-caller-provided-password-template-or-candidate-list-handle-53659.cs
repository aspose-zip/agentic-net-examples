// HOW-TO: Try Multiple Passwords on Encrypted ZIP and Extract Files in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path
            string zipPath = "input.zip";

            // Hardcoded output directory
            string outputDir = "output";

            // Path for status report
            string statusFilePath = Path.Combine(outputDir, "decryption_status.txt");

            // Ensure the output directory exists
            Directory.CreateDirectory(outputDir);

            // Verify the input ZIP file exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Candidate passwords to try
            List<string> candidatePasswords = new List<string>
            {
                "password1",
                "password2",
                "secret"
            };

            bool decryptionSucceeded = false;
            string successfulPassword = null;

            // Attempt each password until one works
            foreach (string pwd in candidatePasswords)
            {
                try
                {
                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                    loadOptions.DecryptionPassword = pwd;

                    // Try opening the archive with the current password
                    using (Archive archive = new Archive(zipPath, loadOptions))
                    {
                        // Access each entry to force password validation
                        foreach (ArchiveEntry entry in archive.Entries)
                        {
                            using (Stream entryStream = entry.Open())
                            {
                                // Read zero bytes; just trigger decryption
                            }
                        }
                    }

                    // If no exception, password is correct
                    decryptionSucceeded = true;
                    successfulPassword = pwd;
                    break;
                }
                catch (Exception)
                {
                    // Wrong password or other error; continue to next candidate
                }
            }

            if (decryptionSucceeded)
            {
                // Extract all entries using the successful password
                ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                loadOptions.DecryptionPassword = successfulPassword;

                using (Archive archive = new Archive(zipPath, loadOptions))
                {
                    archive.ExtractToDirectory(outputDir);
                }

                // Write non‑secret status information
                File.WriteAllText(statusFilePath, $"Decryption succeeded with password: {successfulPassword}");
                Console.WriteLine("Extraction completed successfully.");
            }
            else
            {
                // All passwords failed; report status
                File.WriteAllText(statusFilePath, "Decryption failed for all candidate passwords.");
                Console.WriteLine("All password attempts failed.");
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
 * 1. When a developer receives a password‑protected ZIP from a client and must attempt a known list of possible passwords to unlock and extract its contents.
 * 2. When an automated script needs to process user‑uploaded encrypted archives, trying each candidate password until one succeeds before extracting files.
 * 3. When a backup system stores archives with rotating passwords and the restoration routine must try the current password set to recover the data.
 * 4. When a security audit tool checks whether any of a predefined password list can open an encrypted ZIP and logs the outcome without exposing the password.
 * 5. When a file‑processing service must extract files from an encrypted archive and generate a non‑secret status report indicating success or failure.
 */
