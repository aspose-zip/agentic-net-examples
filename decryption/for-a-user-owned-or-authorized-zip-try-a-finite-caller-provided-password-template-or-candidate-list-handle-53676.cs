// HOW-TO: Attempt Multiple Passwords to Decrypt ZIP Entries and Save Extraction Metadata in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input ZIP file path
            string inputPath = "sample.zip";
            // Hardcoded output directory for extracted files
            string outputDirectory = "Extracted";
            // Hardcoded metadata output file path
            string metadataPath = "decryption_metadata.json";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);
            // Ensure directory for metadata file exists (if any)
            string metadataDir = Path.GetDirectoryName(metadataPath);
            if (!string.IsNullOrEmpty(metadataDir))
            {
                Directory.CreateDirectory(metadataDir);
            }

            // Candidate passwords to try for each entry
            string[] passwordCandidates = new string[] { "password1", "password2", "password3" };

            // List to hold decryption outcome information
            List<string> metadataEntries = new List<string>();

            // Open the ZIP archive
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    foreach (ArchiveEntry entry in archive.Entries)
                    {
                        bool extracted = false;
                        string usedPassword = null;

                        foreach (string pwd in passwordCandidates)
                        {
                            try
                            {
                                // Attempt extraction with the current password
                                string destinationPath = Path.Combine(outputDirectory, entry.Name);
                                entry.Extract(destinationPath, pwd);
                                extracted = true;
                                usedPassword = pwd;
                                break;
                            }
                            catch
                            {
                                // Extraction failed with this password; continue trying others
                            }
                        }

                        // Record outcome for this entry
                        string escapedName = entry.Name.Replace("\\", "\\\\").Replace("\"", "\\\"");
                        string passwordValue = extracted ? $"\"{usedPassword}\"" : "null";
                        string entryJson = $"{{\"EntryName\":\"{escapedName}\",\"Extracted\":{extracted.ToString().ToLower()},\"Password\":{passwordValue}}}";
                        metadataEntries.Add(entryJson);
                    }
                }
            }

            // Build JSON array string
            string jsonContent = "[" + string.Join(",", metadataEntries) + "]";

            // Write metadata to file
            File.WriteAllText(metadataPath, jsonContent);
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Error: {ex.Message}");
        }
    }
}

/*
 * Real-World Use Cases:
 * 1. When a developer receives a password‑protected ZIP from a client and must try a list of possible passwords to extract its contents without exposing the actual password.
 * 2. When an automated batch job needs to process encrypted archives, attempt each candidate password, and log which password succeeded for auditing purposes.
 * 3. When building a migration tool that extracts files from user‑owned encrypted ZIPs while generating a JSON report of successful and failed decryption attempts.
 * 4. When implementing a secure file‑import feature that validates a set of known passwords before extracting data and records non‑secret outcome details for compliance.
 * 5. When creating a forensic utility that systematically tries common passwords on each entry of a ZIP, extracts the files that can be opened, and stores a metadata summary for later analysis.
 */
