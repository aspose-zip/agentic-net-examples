// HOW-TO: Guess Passwords for Multi‑Volume Encrypted ZIP and Extract with C# (Aspose.ZIP for .NET)
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
            string mainSegmentPath = @"C:\Archives\myarchive.zip";
            string segmentsDirectory = @"C:\Archives";
            string outputDirectory = @"C:\Extracted";

            // Verify main segment exists
            if (!File.Exists(mainSegmentPath))
            {
                Console.Error.WriteLine($"File not found: {mainSegmentPath}");
                return;
            }

            // Ensure output directory exists
            Directory.CreateDirectory(outputDirectory);

            // Collect split segment files (exclude the main .zip file)
            string[] allSegmentFiles = Directory.GetFiles(segmentsDirectory, "myarchive.zip.*");
            List<string> segmentFilesList = new List<string>();
            foreach (string file in allSegmentFiles)
            {
                if (!string.Equals(file, mainSegmentPath, StringComparison.OrdinalIgnoreCase))
                {
                    segmentFilesList.Add(file);
                }
            }
            // Order segments to maintain correct sequence
            segmentFilesList.Sort();
            string[] segmentFiles = segmentFilesList.ToArray();

            // Candidate passwords for guessing
            List<string> passwordCandidates = new List<string>
            {
                "password1",
                "password2",
                "123456"
            };

            bool extracted = false;

            foreach (string password in passwordCandidates)
            {
                // Prepare load options with the current password
                ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                loadOptions.DecryptionPassword = password;

                try
                {
                    // Open the multi‑volume encrypted archive with the candidate password
                    using (Archive archive = new Archive(mainSegmentPath, segmentFiles, loadOptions))
                    {
                        // Extract all entries to the output directory
                        archive.ExtractToDirectory(outputDirectory);
                        Console.WriteLine($"Extraction succeeded with password: {password}");
                        extracted = true;
                        break; // Stop trying further passwords
                    }
                }
                catch (Exception)
                {
                    // Password failed; continue to next candidate
                    Console.WriteLine($"Password '{password}' failed.");
                }
            }

            if (!extracted)
            {
                Console.Error.WriteLine("Failed to extract archive: none of the provided passwords were correct.");
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
 * 1. When a developer needs to automatically try a list of possible passwords to open a split encrypted ZIP archive and extract its contents in a .NET application.
 * 2. When an automated backup system stores large encrypted archives across multiple volume files and must combine and unpack them without manual password entry.
 * 3. When a forensic tool must process a multi‑part password‑protected ZIP received from a client, testing known passwords and extracting files for analysis.
 * 4. When a deployment script has to retrieve configuration files from a segmented encrypted archive using predefined password candidates before installing software.
 * 5. When a data migration utility needs to consolidate and extract files from a split encrypted ZIP archive while only logging non‑sensitive extraction results.
 */
