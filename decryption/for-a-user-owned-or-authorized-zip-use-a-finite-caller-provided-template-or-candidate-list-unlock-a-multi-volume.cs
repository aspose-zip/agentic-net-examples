// HOW-TO: Extract Multi‑Volume Encrypted ZIP Using Password List in C# (Aspose.ZIP for .NET)
using System;
using System.IO;
using System.Linq;
using Aspose.Zip;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Hardcoded input directory containing the multi‑volume ZIP segments
            string inputDirectory = "C:\\Input\\MultiVolumeZip";
            // Main segment of the split archive
            string mainSegmentPath = Path.Combine(inputDirectory, "archive.zip");
            if (!File.Exists(mainSegmentPath))
            {
                Console.Error.WriteLine($"File not found: {mainSegmentPath}");
                return;
            }

            // Collect additional split segment files (e.g., archive.zip.001, archive.zip.002, ...)
            string[] segmentPaths = Directory.GetFiles(inputDirectory, "archive.zip.*")
                                             .OrderBy(p => p)
                                             .ToArray();

            // Hardcoded output directory for extracted files
            string outputDirectory = "C:\\Output\\Extracted";
            Directory.CreateDirectory(outputDirectory);

            // Candidate passwords to try
            string[] passwords = new string[] { "Password1", "Password2", "Secret123" };
            bool extractionSucceeded = false;

            foreach (string password in passwords)
            {
                try
                {
                    // Load the multi‑volume encrypted archive with the current password
                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                    loadOptions.DecryptionPassword = password;

                    using (Archive archive = new Archive(mainSegmentPath, segmentPaths, loadOptions))
                    {
                        // Extract all entries to the output directory
                        archive.ExtractToDirectory(outputDirectory);
                    }

                    Console.WriteLine($"Extraction succeeded with password: {password}");
                    extractionSucceeded = true;
                    break;
                }
                catch (Exception ex)
                {
                    // Password failed; try the next one
                    Console.Error.WriteLine($"Password '{password}' failed: {ex.Message}");
                }
            }

            if (!extractionSucceeded)
            {
                Console.Error.WriteLine("Failed to extract archive with provided passwords.");
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
 * 1. When you receive a split encrypted backup archive and need to try several possible passwords to automatically extract all parts in a .NET application.
 * 2. When a corporate compliance tool must process large encrypted zip bundles split across multiple files and extract their contents to a secure folder using Aspose.Zip for C#.
 * 3. When a file‑recovery script has to combine and decrypt multi‑segment zip archives from a user‑provided password list without exposing the extracted data.
 * 4. When an automated deployment pipeline needs to unpack a password‑protected multi‑volume zip package and place the files into a target directory on a Windows server.
 * 5. When a forensic analyst wants to programmatically open and extract entries from a multi‑part encrypted zip using candidate passwords while keeping only non‑sensitive metadata locally.
 */
