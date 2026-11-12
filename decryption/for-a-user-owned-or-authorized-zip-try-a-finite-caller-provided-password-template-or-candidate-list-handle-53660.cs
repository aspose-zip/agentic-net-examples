// HOW-TO: Attempt Multiple Passwords to Decrypt Zip and Extract Files in C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string zipPath = "input.zip";
            string extractDir = "extracted";
            string statusPath = "candidate_status.json";

            // Validate input zip file
            if (!File.Exists(zipPath))
            {
                Console.Error.WriteLine($"File not found: {zipPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(Path.GetDirectoryName(extractDir) ?? ".");
            Directory.CreateDirectory(Path.GetDirectoryName(statusPath) ?? ".");

            // Candidate passwords
            List<string> candidatePasswords = new List<string>
            {
                "password1",
                "123456",
                "letmein"
            };

            bool success = false;
            int extractedCount = 0;

            foreach (string pwd in candidatePasswords)
            {
                try
                {
                    // Attempt to open the archive with the current password
                    using (Archive archive = new Archive(zipPath, new ArchiveLoadOptions { DecryptionPassword = pwd }))
                    {
                        // Extraction succeeded
                        archive.ExtractToDirectory(extractDir);
                        extractedCount = archive.Entries.Count;
                        success = true;
                        break;
                    }
                }
                catch (Exception)
                {
                    // Failed with this password, continue to next candidate
                    continue;
                }
            }

            // Prepare status JSON (non-secret information only)
            string json = $"{{\"Success\":{success.ToString().ToLower()},\"ExtractedFilesCount\":{extractedCount}}}";
            File.WriteAllText(statusPath, json);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When you have a user‑provided zip file protected with an unknown password and you want to try a list of possible passwords to unlock it.
 * 2. When you need to programmatically extract the contents of a password‑protected archive after successfully guessing the correct password.
 * 3. When you want to log the outcome of a password‑cracking attempt without exposing the actual passwords, by writing a status JSON file.
 * 4. When you must handle missing or invalid zip files gracefully before attempting decryption in a C# application.
 * 5. When you need to automate batch extraction of encrypted zip archives while ensuring the extraction directory exists.
 */
