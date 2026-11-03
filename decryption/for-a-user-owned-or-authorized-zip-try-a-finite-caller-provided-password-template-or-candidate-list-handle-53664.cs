// HOW-TO: Try Multiple Passwords to Decrypt a ZIP and Extract Files in C# (Aspose.ZIP for .NET)
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
            string zipPath = "input.zip";

            // Verify input file exists
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Hardcoded output directory for extracted files
            string extractDirectory = "extracted";

            // Hardcoded output path for outcome report
            string outcomePath = "decryption_outcome.txt";

            // Ensure output directories exist
            Directory.CreateDirectory(extractDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(outcomePath));

            // Candidate passwords to try
            List<string> passwordCandidates = new List<string>
            {
                "password1",
                "password2",
                "123456"
            };

            bool extractionSucceeded = false;
            string successfulPassword = null;

            foreach (string candidate in passwordCandidates)
            {
                try
                {
                    // Attempt to open the archive with the candidate password
                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                    loadOptions.DecryptionPassword = candidate;

                    using (Archive archive = new Archive(zipPath, loadOptions))
                    {
                        // If no exception, password is correct; extract contents
                        archive.ExtractToDirectory(extractDirectory);
                        extractionSucceeded = true;
                        successfulPassword = candidate;
                    }
                }
                catch (Exception)
                {
                    // Password failed; continue to next candidate
                }

                if (extractionSucceeded)
                {
                    break;
                }
            }

            // Write outcome information (non-secret)
            using (StreamWriter writer = new StreamWriter(outcomePath, false))
            {
                if (extractionSucceeded)
                {
                    writer.WriteLine("Extraction succeeded with a valid password.");
                }
                else
                {
                    writer.WriteLine("Failed to decrypt the archive with provided passwords.");
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
 * 1. When you receive a password‑protected ZIP from a client and need to programmatically test a list of possible passwords to unlock and extract its contents in a .NET application.
 * 2. When an automated ETL pipeline must process encrypted archives by trying known default passwords before failing gracefully and logging the result.
 * 3. When you want to build a forensic tool that attempts common passwords on a suspect ZIP file, extracts files on success, and records the decryption outcome without exposing the password.
 * 4. When deploying a batch job that extracts files from user‑owned encrypted ZIPs using Aspose.Zip, handling incorrect passwords and generating a non‑secret report file.
 * 5. When creating a self‑service utility that helps end‑users recover data from forgotten ZIP passwords by iterating through a candidate list and saving a summary of the decryption attempt.
 */
