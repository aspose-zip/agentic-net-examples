// HOW-TO: Extract Encrypted Multi-Volume ZIP with Password List in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing ZIP segments
            string segmentsDirectory = @"C:\ZipSegments";
            // Hardcoded output directory for extracted files
            string outputDirectory = @"C:\Extracted";

            // Validate input directory
            if (!Directory.Exists(segmentsDirectory))
            {
                Console.Error.WriteLine($"Directory not found: {segmentsDirectory}");
                return;
            }

            // Collect and order all segment files
            string[] allFiles = Directory.GetFiles(segmentsDirectory);
            string[] orderedFiles = allFiles.OrderBy(f => f).ToArray();

            // Identify main .zip file
            string mainZip = orderedFiles.FirstOrDefault(f => Path.GetExtension(f).Equals(".zip", StringComparison.OrdinalIgnoreCase));
            if (string.IsNullOrEmpty(mainZip))
            {
                Console.Error.WriteLine("Main .zip file not found in the segments directory.");
                return;
            }

            // Validate main zip file existence
            if (!File.Exists(mainZip))
            {
                Console.Error.WriteLine($"File not found: {mainZip}");
                return;
            }

            // Prepare other segment files (if any) and validate each
            string[] otherSegments = orderedFiles.Where(f => f != mainZip).ToArray();
            foreach (string segment in otherSegments)
            {
                if (!File.Exists(segment))
                {
                    Console.Error.WriteLine($"File not found: {segment}");
                    return;
                }
            }

            // Candidate passwords to try
            string[] passwordCandidates = new string[] { "password1", "12345", "secret" };
            bool extractionSucceeded = false;

            foreach (string pwd in passwordCandidates)
            {
                try
                {
                    // Load encrypted multi‑volume ZIP with the current password
                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                    loadOptions.DecryptionPassword = pwd;

                    using (Archive archive = new Archive(mainZip, otherSegments, loadOptions))
                    {
                        // Access entries to confirm successful decryption
                        int entryCount = archive.Entries.Count;
                        if (entryCount == 0)
                        {
                            // No entries means decryption likely failed; try next password
                            continue;
                        }

                        // Ensure output directory exists
                        Directory.CreateDirectory(outputDirectory);

                        // Extract all entries preserving their internal paths
                        archive.ExtractToDirectory(outputDirectory);

                        // Log extracted entry names
                        string logPath = Path.Combine(outputDirectory, "extraction_log.txt");
                        using (StreamWriter writer = new StreamWriter(logPath, false))
                        {
                            foreach (ArchiveEntry entry in archive.Entries)
                            {
                                writer.WriteLine(entry.Name);
                            }
                        }

                        extractionSucceeded = true;
                        break; // Stop trying further passwords
                    }
                }
                catch
                {
                    // Ignore exceptions and try the next password
                }
            }

            if (!extractionSucceeded)
            {
                Console.Error.WriteLine("Failed to decrypt the archive with the provided passwords.");
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
 * 1. When a developer needs to automatically unpack a split encrypted archive received from a partner, trying a set of possible passwords to recover the files.
 * 2. When an application must process large encrypted backup archives that are stored as multiple .zip parts and extract their contents while preserving the original folder hierarchy.
 * 3. When a security tool has to verify and extract non‑sensitive metadata from password‑protected zip volumes without exposing the secret data.
 * 4. When a migration script has to combine segmented zip files, attempt known passwords, and place the extracted documents into their correct subfolders on a new server.
 * 5. When a CI/CD pipeline must unpack an encrypted multi‑part zip artifact using a predefined password list to continue downstream build steps.
 */
