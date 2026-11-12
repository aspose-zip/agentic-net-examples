// HOW-TO: Attempt Multiple Passwords on ZIP Entries and Extract with Summary in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Collections.Generic;
using System.Text;
using Aspose.Zip;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            // Hardcoded input ZIP path
            string inputPath = "sample.zip";

            // Verify input file exists
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Output directory for extracted files and summary
            string outputDirectory = "extracted";
            Directory.CreateDirectory(Path.GetDirectoryName(outputDirectory));

            // Path for the decryption summary markdown file
            string summaryPath = Path.Combine(outputDirectory, "decryption_summary.md");
            Directory.CreateDirectory(Path.GetDirectoryName(summaryPath));

            // Candidate passwords to try for each entry
            List<string> passwordCandidates = new List<string>
            {
                "password1",
                "secret123",
                "letmein"
            };

            // Open the ZIP archive
            using (FileStream zipStream = File.Open(inputPath, FileMode.Open, FileAccess.Read))
            {
                using (Archive archive = new Archive(zipStream))
                {
                    // Prepare summary file
                    using (StreamWriter summaryWriter = new StreamWriter(summaryPath, false, Encoding.UTF8))
                    {
                        summaryWriter.WriteLine("# Decryption Summary");
                        summaryWriter.WriteLine();

                        // Iterate over each entry in the archive
                        foreach (ArchiveEntry entry in archive.Entries)
                        {
                            bool extracted = false;

                            // Try each password candidate
                            foreach (string pwd in passwordCandidates)
                            {
                                try
                                {
                                    // Attempt to extract the entry with the current password
                                    entry.Extract(outputDirectory, pwd);
                                    summaryWriter.WriteLine($"- Extracted `{entry.Name}` using a provided password.");
                                    extracted = true;
                                    break; // Stop trying passwords for this entry
                                }
                                catch (Exception)
                                {
                                    // Extraction failed with this password; continue trying others
                                }
                            }

                            if (!extracted)
                            {
                                summaryWriter.WriteLine($"- Failed to extract `{entry.Name}` with the supplied passwords.");
                            }
                        }
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
 * 1. When you need to brute‑force a known list of possible passwords for each file in a protected ZIP and extract the contents automatically.
 * 2. When you must verify whether a user‑provided password list can unlock any entries in an archive before processing the data.
 * 3. When you want to generate a non‑secret markdown report that records which passwords succeeded and which files were extracted.
 * 4. When you are building a migration tool that needs to handle encrypted ZIPs by trying candidate passwords and saving the decrypted files to a target folder.
 * 5. When you need to programmatically handle failed password attempts gracefully while continuing to process remaining entries in the archive.
 */
