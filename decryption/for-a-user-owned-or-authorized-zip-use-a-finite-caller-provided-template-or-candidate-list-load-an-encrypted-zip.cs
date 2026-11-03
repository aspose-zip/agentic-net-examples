// HOW-TO: Decrypt Encrypted ZIP with Multiple Passwords and Log Extraction in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path and output folder
            string inputPath = "encrypted.zip";
            string outputDirectory = "ExtractedFiles";
            string logPath = "extraction_log.txt";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(outputDirectory);
            Directory.CreateDirectory(Path.GetDirectoryName(logPath) ?? ".");

            // Candidate passwords to try
            string[] candidatePasswords = new string[] { "password1", "password2", "password3" };
            bool extracted = false;

            foreach (string pwd in candidatePasswords)
            {
                try
                {
                    // Attempt to open the encrypted archive with the current password
                    using (Archive archive = new Archive(inputPath, new ArchiveLoadOptions { DecryptionPassword = pwd }))
                    {
                        // Extract all entries to the output directory
                        archive.ExtractToDirectory(outputDirectory);

                        // Write non‑secret outcome information to a log file
                        using (StreamWriter writer = new StreamWriter(logPath, false))
                        {
                            writer.WriteLine($"Successfully extracted using password: {pwd}");
                            foreach (ArchiveEntry entry in archive.Entries)
                            {
                                writer.WriteLine($"Extracted: {entry.Name}");
                            }
                        }

                        extracted = true;
                        break; // Stop after successful extraction
                    }
                }
                catch (Exception)
                {
                    // Incorrect password or other error – try next candidate
                    continue;
                }
            }

            if (!extracted)
            {
                // Log failure if none of the passwords worked
                using (StreamWriter writer = new StreamWriter(logPath, false))
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
 * 1. When a client sends a password‑protected ZIP and you need to try a list of possible passwords to extract the files automatically.
 * 2. When you must extract confidential documents from an encrypted archive in a scheduled C# service while recording which password succeeded.
 * 3. When migrating legacy backup archives that were encrypted with unknown passwords and you want to programmatically test candidate passwords and save the extracted data.
 * 4. When building a forensic tool that attempts decryption of a suspect’s ZIP file using a dictionary of passwords and logs the extraction results for evidence.
 * 5. When creating an automated deployment pipeline that unpacks encrypted resource bundles, tries known passwords, and writes a simple log for audit purposes.
 */
