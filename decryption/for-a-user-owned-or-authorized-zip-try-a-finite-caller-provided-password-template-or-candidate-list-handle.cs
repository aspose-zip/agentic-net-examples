// HOW-TO: Unlock Password-Protected Zip With Candidate List And Extract Files In C# (Aspose.ZIP for .NET)
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
            // Hardcoded paths
            string inputZipPath = @"C:\Temp\protected.zip";
            string outputDirectory = @"C:\Temp\Extracted";
            string statusFilePath = Path.Combine(outputDirectory, "unlock_status.txt");

            // Verify input file exists
            if (!File.Exists(inputZipPath))
            {
                Console.Error.WriteLine($"File not found: {inputZipPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(Path.GetDirectoryName(statusFilePath));

            // Candidate passwords
            List<string> passwordCandidates = new List<string>
            {
                "password123",
                "letmein",
                "secret!",
                "admin",
                "123456"
            };

            bool unlocked = false;
            string usedPassword = null;

            foreach (string pwd in passwordCandidates)
            {
                try
                {
                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions
                    {
                        DecryptionPassword = pwd
                    };

                    using (Archive archive = new Archive(inputZipPath, loadOptions))
                    {
                        // If we reach here, password is correct
                        archive.ExtractToDirectory(outputDirectory);
                        unlocked = true;
                        usedPassword = pwd;
                    }

                    // Stop trying after successful extraction
                    break;
                }
                catch (Exception)
                {
                    // Wrong password or other load error, continue to next candidate
                    continue;
                }
            }

            // Write status file
            using (StreamWriter writer = new StreamWriter(statusFilePath, false))
            {
                if (unlocked)
                {
                    writer.WriteLine($"Password found: {usedPassword}");
                    writer.WriteLine("Archive extracted successfully.");
                }
                else
                {
                    writer.WriteLine("Failed to unlock the archive with provided passwords.");
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
 * 1. When a developer receives a user‑provided ZIP that may be protected with one of several known passwords and needs to programmatically try each password until the archive opens.
 * 2. When an application must automatically extract files from a secured archive without prompting the user, using a predefined list of possible passwords.
 * 3. When a batch process has to handle many encrypted ZIPs and log whether each one was successfully unlocked, storing only non‑secret status information.
 * 4. When a security audit tool needs to verify that a ZIP can be opened with any password from a policy‑defined template before further analysis.
 * 5. When a deployment script must unpack configuration files from a protected archive on a server, using Aspose.Zip to manage decryption and extraction.
 */
