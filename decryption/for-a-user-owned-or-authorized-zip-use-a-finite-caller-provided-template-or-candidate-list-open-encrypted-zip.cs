// HOW-TO: Brute Force Password List to Decrypt and Extract Encrypted ZIP in C# (Aspose.ZIP for .NET)
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
            // Hardcoded input and output paths
            string inputPath = "encrypted.zip";
            string outputDirectory = "ExtractedFiles";
            string outcomePath = "outcome.txt";

            // Validate input file existence
            if (!File.Exists(inputPath))
            {
                Console.Error.WriteLine($"File not found: {inputPath}");
                return;
            }

            // Ensure output directories exist
            Directory.CreateDirectory(outputDirectory);
            string outcomeDir = Path.GetDirectoryName(outcomePath);
            if (!string.IsNullOrEmpty(outcomeDir))
            {
                Directory.CreateDirectory(outcomeDir);
            }

            // List of candidate passwords
            List<string> passwordList = new List<string>
            {
                "password1",
                "password2",
                "secret"
            };

            bool extractionSucceeded = false;
            List<string> extractedFiles = new List<string>();

            // Try each password until successful
            foreach (string pwd in passwordList)
            {
                try
                {
                    ArchiveLoadOptions loadOptions = new ArchiveLoadOptions();
                    loadOptions.DecryptionPassword = pwd;

                    using (Archive archive = new Archive(inputPath, loadOptions))
                    {
                        foreach (ArchiveEntry entry in archive.Entries)
                        {
                            if (!entry.IsDirectory)
                            {
                                string destinationPath = Path.Combine(outputDirectory, entry.Name);
                                string destinationDir = Path.GetDirectoryName(destinationPath);
                                if (!string.IsNullOrEmpty(destinationDir))
                                {
                                    Directory.CreateDirectory(destinationDir);
                                }

                                using (FileStream outStream = new FileStream(destinationPath, FileMode.Create, FileAccess.Write))
                                {
                                    entry.Extract(outStream);
                                }

                                extractedFiles.Add(destinationPath);
                            }
                        }
                    }

                    extractionSucceeded = true;
                    Console.WriteLine($"Extraction succeeded with password: {pwd}");
                    break;
                }
                catch (Exception ex)
                {
                    // Wrong password or other error; continue to next candidate
                    Console.Error.WriteLine($"Failed with password '{pwd}': {ex.Message}");
                }
            }

            if (!extractionSucceeded)
            {
                Console.Error.WriteLine("All passwords failed. Extraction not performed.");
                return;
            }

            // Save non‑secret outcome information
            using (StreamWriter writer = new StreamWriter(outcomePath, false))
            {
                writer.WriteLine("Extraction completed successfully.");
                writer.WriteLine("Extracted files:");
                foreach (string filePath in extractedFiles)
                {
                    writer.WriteLine(filePath);
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
 * 1. When a developer receives an encrypted ZIP from a client but only has a set of possible passwords and needs to automatically try each one to extract the files.
 * 2. When building a file‑processing service that must unpack user‑uploaded encrypted archives without storing the original passwords, logging only the extraction result.
 * 3. When creating a forensic tool that attempts known passwords on a suspect’s encrypted ZIP and extracts its contents for analysis.
 * 4. When implementing a batch job that processes multiple encrypted ZIP backups by trying a predefined password list and saving the extracted documents to a server folder.
 * 5. When developing a migration script that needs to read data from password‑protected archives, extract them, and record a simple outcome report without exposing sensitive information.
 */
